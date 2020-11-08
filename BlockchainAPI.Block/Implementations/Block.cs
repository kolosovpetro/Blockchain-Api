using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using BlockchainAPI.Block.Interfaces;
using BlockchainAPI.Transactions.Implementations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlockchainAPI.Block.Implementations
{
    public class Block : IBlock
    {
        [BsonId] public ObjectId Id { get; set; }
        [BsonElement("previous_hash")] public string PreviousHash { get; set; }
        [BsonElement("time_stamp")] public long Timestamp { get; set; }
        [BsonElement("nonce")] public long Nonce { get; set; }

        [BsonElement("transactions")] public List<Transaction> Transactions { get; set; }
        [BsonElement("hash")] public string Hash { get; set; }

        public Block()
        {
        }

        public Block(List<Transaction> transactions, string previousHash = "")
        {
            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            Transactions = transactions;
            PreviousHash = previousHash;
            Nonce = 0;
            Hash = CreateHash();
        }

        /// <summary>
        ///     Mines new block.
        /// </summary>
        public void MineBlock(int proofOfWorkDifficulty)
        {
            var hashValidationTemplate = new string('0', proofOfWorkDifficulty);

            while (Hash.Substring(0, proofOfWorkDifficulty) != hashValidationTemplate)
            {
                Nonce++;
                Hash = CreateHash();
            }
        }

        /// <summary>
        ///     Generates hash of current block. Used to find hash which satisfies blockchain rule.
        /// </summary>
        public string CreateHash()
        {
            using var sha256 = SHA256.Create();
            var rawData = PreviousHash + Timestamp + Transactions + Nonce;
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
            return Encoding.Default.GetString(bytes);
        }
    }
}