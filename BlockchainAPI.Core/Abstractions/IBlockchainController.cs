using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlockchainAPI.Abstractions
{
    public interface IBlockchainController
    {
        // get
        Task<IActionResult> GetAllBlocks();
        
        // get
        Task<IActionResult> GetBalance(string address);
        
        // post
        Task<IActionResult> MineBlock();
        
        // get
        Task<IActionResult> IsValidChain();
    }
}