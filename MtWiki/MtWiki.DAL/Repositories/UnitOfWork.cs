using MtWiki.DAL.Interfaces;

namespace MtWiki.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private ICuratorRepository? curatorRepository;
        private IDepartmentRepository? departmentRepository;
        private IEmployeeRepository? employeeRepository;
        private IRkcRepository? rkcRepository;
        private ILeadershipPositionRepository? leadershipPositionRepository;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICuratorRepository Curators
        {
            get
            {
                if (curatorRepository == null)
                    curatorRepository = new CuratorRepository(_dbContext);
                return curatorRepository;
            }
        }

        public IDepartmentRepository Departments
        {
            get
            {
                if (departmentRepository == null)
                    departmentRepository = new DepartmentRepository(_dbContext);

                return departmentRepository;
            }
        }

        public IEmployeeRepository Employees
        {
            get
            {
                if (employeeRepository == null)
                    employeeRepository = new EmployeeRepository(_dbContext);

                return employeeRepository;
            }
        }

        public IRkcRepository Rkcs
        {
            get
            {
                if (rkcRepository == null)
                    rkcRepository = new RkcRepository(_dbContext);

                return rkcRepository;
            }
        }

        public ILeadershipPositionRepository LeadershipPositions
        {
            get
            {
                if (leadershipPositionRepository == null)
                    leadershipPositionRepository = new LeadershipPositionRepository(_dbContext);

                return leadershipPositionRepository;
            }
        }

        public void Commit()
             => _dbContext.SaveChanges();
        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();
        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();


        private bool disposed = false;


        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }


                disposed = true;
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
