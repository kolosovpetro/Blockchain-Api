using System.Collections.Generic;
using System.Threading.Tasks;
using BlockchainAPI.Transactions.Implementations;

namespace BlockchainAPI.Blockchain.Interfaces
{
    public interface IBlockchain
    {
        List<BlockchainAPI.Block.Implementations.Block> Chain { get; }
        void CreateTransaction(Transaction transaction);
        Task MineBlock(string minerAddress);
        bool IsValidChain();
        double GetBalance(string address);
    }
}