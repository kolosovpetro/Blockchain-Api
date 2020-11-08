using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockchainAPI.Blockchain.Interfaces;
using BlockchainAPI.Repository.Repositories;
using BlockchainAPI.Transactions.Implementations;

namespace BlockchainAPI.Blockchain.Implementations
{
    public class Blockchain : IBlockchain
    {
        private readonly int _proofOfWorkDifficulty;
        private readonly double _miningReward;
        private List<Transaction> _pendingTransactions;
        private readonly BlockRepository _blockRepository;

        public List<BlockchainAPI.Block.Implementations.Block> Chain { get; }

        public Blockchain(int proofOfWorkDifficulty, double miningReward)
        {
            var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
            _blockRepository = new BlockRepository(connectionString);
            _proofOfWorkDifficulty = proofOfWorkDifficulty;
            _miningReward = miningReward;
            Chain = _blockRepository.GetAll().Result;
            _pendingTransactions = new List<Transaction>();
        }

        public void CreateTransaction(Transaction transaction)
        {
            _pendingTransactions.Add(transaction);
        }

        public async Task MineBlock(string minerAddress)
        {
            var minerRewardTransaction = new Transaction(null, minerAddress, _miningReward);
            _pendingTransactions.Add(minerRewardTransaction);
            var prevHash = Chain.Last().Hash;
            var block = new BlockchainAPI.Block.Implementations.Block(_pendingTransactions, prevHash);
            block.MineBlock(_proofOfWorkDifficulty);
            Chain.Add(block);
            await _blockRepository.Insert(block);
            _pendingTransactions = new List<Transaction>();
            Console.WriteLine("Block has been mined");
        }

        public bool IsValidChain()
        {
            for (var i = 1; i < Chain.Count; i++)
            {
                var previousBlock = Chain[i - 1];
                var currentBlock = Chain[i];
                if (currentBlock.Hash != currentBlock.CreateHash())
                    return false;
                if (currentBlock.PreviousHash != previousBlock.Hash)
                    return false;
            }

            return true;
        }

        public double GetBalance(string address)
        {
            double balance = 0;
            foreach (var block in Chain)
            {
                foreach (var transaction in block.Transactions)
                {
                    if (transaction.FromAddress == address)
                        balance -= transaction.Amount;

                    if (transaction.ToAddress == address)
                        balance += transaction.Amount;
                }
            }

            return balance;
        }

        private static BlockchainAPI.Block.Implementations.Block CreateGenesisBlock()
        {
            var transactions = new List<Transaction> {new Transaction("", "", 0)};
            return new BlockchainAPI.Block.Implementations.Block(transactions, "0");
        }
    }
}