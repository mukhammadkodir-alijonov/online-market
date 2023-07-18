using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataAccess.DbContexts;
using OnlineMarket.DataAccess.Interfaces;
using OnlineMarket.DataAccess.Repositories;

namespace OnlineMarket.Web.Configurations.LayerConfigurations;
public static class DataAccessConfiguration
{
    public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("DatabaseConnection")!;
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
