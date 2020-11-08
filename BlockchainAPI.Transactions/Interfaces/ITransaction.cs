namespace BlockchainAPI.Transactions.Interfaces
{
    public interface ITransaction
    {
        /// <summary>
        ///     Address of a miner, transaction comes from
        /// </summary>
        public string FromAddress { get; set; }

        /// <summary>
        /// Address of a miner, transaction comes to
        /// </summary>
        public string ToAddress { get; set; }

        /// <summary>
        ///     Amount of transaction
        /// </summary>
        public double Amount { get; set; }
    }
}