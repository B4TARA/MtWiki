using MtWiki.DAL.Entities;
using MtWiki.DAL.Interfaces;

namespace MtWiki.DAL.Repositories
{
    public class CuratorRepository : RepositoryBase<Curator>, ICuratorRepository
    {
        public CuratorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
