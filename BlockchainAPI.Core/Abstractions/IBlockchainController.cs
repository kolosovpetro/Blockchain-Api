using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlockchainAPI.Abstractions
{
    public interface IBlockchainController
    {
        // get
        IActionResult GetAllBlocks();
        
        // get
        IActionResult GetBalance(string address);
        
        // post
        Task<IActionResult> MineBlock(string address);
        
        // get
        IActionResult IsValidChain();
    }
}