using MtSmart.BLL.Interfaces;
using MtSmart.BLL.Services;
using MtWiki.DAL.Interfaces;
using MtWiki.DAL.Repositories;

namespace MtWiki.WEB
{
    public static class Initializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICuratorRepository, CuratorRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ILeadershipPositionRepository, LeadershipPositionRepository>();
            services.AddScoped<IRkcRepository, RkcRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ICuratorService, CuratorService>();
            services.AddScoped<ILeadershipPositionService, LeadershipPositionService>();
        }
    }
}
