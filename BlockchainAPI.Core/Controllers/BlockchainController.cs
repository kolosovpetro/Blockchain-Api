using System.Threading.Tasks;
using BlockchainAPI.Abstractions;
using BlockchainAPI.Models.Models;
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
        public async Task<IActionResult> GetAllBlocks()
        {
            return Ok(_blockchain.Chain);
        }

        [HttpGet("/getbalance/{address}", Name = "GetBalance")]
        public async Task<IActionResult> GetBalance(string address)
        {
            return Ok(_blockchain.GetBalance(address));
        }
        
        [HttpPost("/mineblock/{address}", Name = "MineBlock")]
        public async Task<IActionResult> MineBlock(string address)
        {
            await _blockchain.MineBlock(address);
            return Ok();
        }
        
        [HttpGet("/isvalidchain", Name = "IsValidChain")]
        public async Task<IActionResult> IsValidChain()
        {
            return Ok(_blockchain.IsValidChain());
        }
    }
}