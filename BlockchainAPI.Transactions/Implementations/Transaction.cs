using BlockchainAPI.Transactions.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace BlockchainAPI.Transactions.Implementations
{
    public class Transaction : ITransaction
    {
        [BsonElement("from_address")] public string FromAddress { get; set; }
        [BsonElement("to_address")] public string ToAddress { get; set; }
        [BsonElement("amount")] public double Amount { get; set; }

        public Transaction(string fromAddress, string toAddress, double amount)
        {
            FromAddress = fromAddress;
            ToAddress = toAddress;
            Amount = amount;
        }

        public Transaction()
        {
        }
    }
}