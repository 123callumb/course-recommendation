using Library.EntityFramework;
using Library.EntityFramework.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.GenericRepository;
using Services.GenericRepository.Implementation;

namespace Services
{
    public static class Services
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<IDatabaseContext, DatabaseContext>(opt => opt.UseMySql(config.GetConnectionString("default"), ServerVersion.Parse(config.GetConnectionString("ServerVersion"))));
            services.AddScoped<IGenericQuerier, GenericQuerier>();
            services.AddScoped<IGenericRepo, GenericRepo>();
        }
    }
}
