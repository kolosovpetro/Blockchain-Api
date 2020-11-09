using System.Threading.Tasks;
using BlockchainAPI.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BlockchainAPI.Controllers
{
    [ApiController]
    [Route("api/blockchain")]
    public class BlockchainController : Controller, IBlockchainController
    {
        private readonly Blockchain.Implementations.Blockchain
            _blockchain = new Blockchain.Implementations.Blockchain(2, 10);

        [HttpGet]
        public IActionResult GetAllBlocks()
        {
            return Ok(_blockchain.Chain);
        }

        [HttpGet("/GetBalance/{address}", Name = "GetBalance")]
        public IActionResult GetBalance(string address)
        {
            return Ok(_blockchain.GetBalance(address));
        }

        [HttpPost("/MineBlock/{address}", Name = "MineBlock")]
        public async Task<IActionResult> MineBlock(string address)
        {
            await _blockchain.MineBlock(address);
            return Ok();
        }

        [HttpGet("/IsValidChain", Name = "IsValidChain")]
        public IActionResult IsValidChain()
        {
            return Ok(_blockchain.IsValidChain());
        }
    }
}