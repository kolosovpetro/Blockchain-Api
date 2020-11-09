namespace BlockchainAPI.Responses.Models
{
    public class BalanceResponse
    {
        public int Code { get; set; } = 200;
        public string Address { get; set; }
        public double Balance { get; set; }
    }
}