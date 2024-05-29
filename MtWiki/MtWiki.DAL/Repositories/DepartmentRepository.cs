using MtWiki.DAL.Entities;
using MtWiki.DAL.Interfaces;

namespace MtWiki.DAL.Repositories
{
    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
