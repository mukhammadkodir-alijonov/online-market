using OnlineMarket.Domain.Entities.Categories;
using OnlineMarket.Service.Common.Utils;

namespace OnlineMarket.Service.Interfaces.Categories
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllAsync(PaginationParams @params);
    }
}
