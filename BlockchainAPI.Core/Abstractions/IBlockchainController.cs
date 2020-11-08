using System.Threading.Tasks;
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
        Task<IActionResult> MineBlock(string address);
        
        // get
        Task<IActionResult> IsValidChain();
    }
}