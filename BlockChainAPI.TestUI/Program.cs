using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlockchainAPI.Repository.Repositories;
using BlockchainAPI.Transactions.Implementations;

namespace BlockchainAPI.TestUI
{
    public static class Program
    {
        public static async Task Main()
        {
            // var transactions = new List<Transaction> {new Transaction("", "", 0)};
            // var t = new Block.Implementations.Block(transactions, "0");
            // Console.WriteLine(t.Hash);
            // var repo = new BlockRepository(Environment.GetEnvironmentVariable("DATABASE_URL"));
            // var ins = repo.Insert(t);
            // Task.WaitAll(ins);
            // Console.WriteLine("Done");
            // var coll = await repo.GetAll();
            // var first = coll.First();
            // Console.WriteLine(first.Hash);
            // Console.WriteLine(first.CreateHash());
            // Console.WriteLine(first.Hash == first.CreateHash());
            //
            // // foreach (var block in coll)
            // // {
            // //     Console.WriteLine(block.Hash);
            // //     Console.WriteLine(block.Transactions.Count);
            // // }

            var blockChain = new Blockchain.Implementations.Blockchain(2, 10);
            // const string address = "address 1";
            // await blockChain.MineBlock(address);
            // Console.WriteLine($"Current balance: {blockChain.GetBalance(address)}");
            // await blockChain.MineBlock(address);
            // Console.WriteLine($"Current balance: {blockChain.GetBalance(address)}");
            // await blockChain.MineBlock(address);
            // Console.WriteLine($"Current balance: {blockChain.GetBalance(address)}");
            Console.WriteLine($"Is valid blockchain: {blockChain.IsValidChain()}");
        }
    }
}