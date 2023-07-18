using OnlineMarket.Service.Common.Utils;
using OnlineMarket.Service.ViewModels.Products;

namespace OnlineMarket.Service.Interfaces.Products;
public interface IProductService
{
    public Task<IEnumerable<ProductBaseViewModel>> GetAllAsync(PaginationParams @params);

    public Task<ProductViewModel> GetAsync(long productId);
}
