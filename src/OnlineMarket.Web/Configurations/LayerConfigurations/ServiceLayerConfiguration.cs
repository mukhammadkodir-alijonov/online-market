using OnlineMarket.Service.Interfaces.Accounts;
using OnlineMarket.Service.Interfaces.Common;
using OnlineMarket.Service.Interfaces.Products;
using OnlineMarket.Service.Services.Accounts;
using OnlineMarket.Service.Services.Common;
using OnlineMarket.Service.Services.Products;

namespace OnlineMarket.Web.Configurations.LayerConfigurations;
public static class ServiceLayerConfiguration
{
    public static void AddService(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IIdentityService, IdentityService>();
    }
}
