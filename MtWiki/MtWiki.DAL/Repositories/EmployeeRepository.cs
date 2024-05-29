using MtWiki.DAL.Entities;
using MtWiki.DAL.Interfaces;

namespace MtWiki.DAL.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
