using System.Collections.Generic;
using BlockchainAPI.Transactions.Implementations;
using MongoDB.Bson;

namespace BlockchainAPI.Block.Interfaces
{
    public interface IBlock
    {
        ObjectId Id { get; set; }
        
        /// <summary>
        ///     Hash of the previous block in chain
        /// </summary>
        string PreviousHash { get; set; }
        
        /// <summary>
        ///     Timestamp when block has been created.
        /// </summary>
        long Timestamp { get; set; }
        
        /// <summary>
        ///     Artificial value in order to generate hash by rule.
        /// </summary>
        long Nonce { get; set; }
        
        /// <summary>
        ///     List of transactions of current block.
        /// </summary>
        List<Transaction> Transactions { get; set; }

        /// <summary>
        ///     Hash of current block
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        ///     Method used in order to mine in blockchain.
        /// </summary>
        void MineBlock(int proofOfWorkDifficulty);

        string CreateHash();
    }
}