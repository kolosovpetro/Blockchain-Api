using BlockchainAPI.Repository.BaseRepository;

namespace BlockchainAPI.Repository.Repositories
{
    public class BlockRepository : BaseRepository<BlockchainAPI.Block.Implementations.Block>
    {
        public BlockRepository(string connectionString) : base(connectionString)
        {
        }
    }
}