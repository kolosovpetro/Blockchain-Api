using System.Threading.Tasks;
using BlockchainAPI.Abstractions;
using BlockchainAPI.Responses.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlockchainAPI.Controllers
{
    [ApiController]
    [Route("api/blockchain")]
    public class BlockchainController : Controller, IBlockchainController
    {
        private readonly Blockchain.Implementations.Blockchain
            _blockchain = new Blockchain.Implementations.Blockchain();

        /// <summary>
        /// Returns the list of all blocks in blockchain.
        /// </summary>
        [HttpGet]
        public IActionResult GetAllBlocks()
        {
            return Ok(_blockchain.Chain);
        }

        /// <summary>
        /// Returns balance of particular miner address. Address is a string. 
        /// </summary>
        [HttpGet("/GetBalance/{address}", Name = "GetBalance")]
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
        /// Mines new block and creates a transaction to particular miner address.
        /// </summary>
        [HttpPost("/MineBlock/{address}", Name = "MineBlock")]
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
        [HttpGet("/IsValidChain", Name = "IsValidChain")]
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