using OnlineMarket.DataAccess.DbContexts;
using OnlineMarket.DataAccess.Interfaces.Products;
using OnlineMarket.Domain.Entities.Products;

namespace OnlineMarket.DataAccess.Repositories.Products;
public class ProductDiscountRepository : GenericRepository<ProductDiscount>, 
    IProductDiscountRepository
{
    public ProductDiscountRepository(AppDbContext context) : base(context)
    {
    }
}
