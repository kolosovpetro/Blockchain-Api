namespace BlockchainAPI.Responses.Models
{
    public class ValidateChainResponse
    {
        public int Code { get; set; } = 200;
        public bool IsValidBlockchain { get; set; }
    }
}