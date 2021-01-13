using System.Threading.Tasks;
using BlockchainAPI.Abstractions;
using BlockchainAPI.Responses.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BlockchainAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BlockchainController : Controller, IBlockchainController
    {
        private readonly Blockchain.Implementations.Blockchain
            _blockchain = new Blockchain.Implementations.Blockchain();

        /// <summary>
        /// Returns the list of all blocks in blockchain.
        /// </summary>
        [HttpGet("blockchain", Name = "GetAllBlocks")]
        [SwaggerOperation(Summary = "Returns the list of all blocks in blockchain.")]
        public IActionResult GetAllBlocks()
        {
            return Ok(_blockchain.Chain);
        }

        /// <summary>
        /// Returns balance of particular miner address. Address is a string. 
        /// </summary>
        [HttpGet("blockchain/{address}", Name = "GetBalance")]
        [SwaggerOperation(Summary = "Returns balance of particular miner address. Address is a string.")]
        public IActionResult GetBalance(string address)
        {
            var balanceResponse = new BalanceResponse
            {
                Address = address,
                Balance = _blockchain.GetBalance(address)
            };

            return Ok(balanceResponse);
        }

        /// <summary>
        /// Mines new block and creates a transaction to particular miner address. Keep the address in order
        /// to check balance later.
        /// </summary>
        [HttpPost("blockchain/{address}", Name = "MineBlock")]
        [SwaggerOperation(Summary =
            "Mines new block and creates a transaction to particular miner address. " +
            "Keep the address in order to check balance later.")]
        public async Task<IActionResult> MineBlock(string address)
        {
            await _blockchain.MineBlock(address);
            var mineResponse = new MineBlockResponse
            {
                ToAddress = address,
                Success = true
            };

            return Ok(mineResponse);
        }

        /// <summary>
        /// Checks whenever blockchain is valid.
        /// </summary>
        [HttpGet("blockchain/validate", Name = "IsValidChain")]
        [SwaggerOperation(Summary = "Checks whenever blockchain is valid.")]
        public IActionResult IsValidChain()
        {
            var validateResponse = new ValidateChainResponse
            {
                IsValidBlockchain = _blockchain.IsValidChain()
            };

            return Ok(validateResponse);
        }
    }
}