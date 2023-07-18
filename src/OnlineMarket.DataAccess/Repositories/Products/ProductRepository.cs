using OnlineMarket.DataAccess.DbContexts;
using OnlineMarket.DataAccess.Interfaces.Products;
using OnlineMarket.Domain.Entities.Products;

namespace OnlineMarket.DataAccess.Repositories.Products;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
}
