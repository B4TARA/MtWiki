namespace MtWiki.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICuratorRepository Curators { get; }
        IDepartmentRepository Departments { get; }
        IEmployeeRepository Employees { get; }
        IRkcRepository Rkcs { get; }
        ILeadershipPositionRepository LeadershipPositions { get; }

        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
