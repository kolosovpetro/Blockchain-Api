namespace BlockchainAPI.Responses.Models
{
    public class MineBlockResponse
    {
        public int Code { get; set; } = 200;
        public string ToAddress { get; set; }
        public bool Success { get; set; }
    }
}