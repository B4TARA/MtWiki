using MtWiki.DAL.Entities;
using MtWiki.DAL.Interfaces;

namespace MtWiki.DAL.Repositories
{
    public class RkcRepository : RepositoryBase<Rkc>, IRkcRepository
    {
        public RkcRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
