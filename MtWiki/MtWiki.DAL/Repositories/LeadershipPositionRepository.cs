using MtWiki.DAL.Entities;
using MtWiki.DAL.Interfaces;

namespace MtWiki.DAL.Repositories
{
    public class LeadershipPositionRepository : RepositoryBase<LeadershipPosition>, ILeadershipPositionRepository
    {
        public LeadershipPositionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
