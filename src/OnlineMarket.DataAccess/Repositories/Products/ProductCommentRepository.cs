using OnlineMarket.DataAccess.DbContexts;
using OnlineMarket.DataAccess.Interfaces.Products;
using OnlineMarket.Domain.Entities.Products;

namespace OnlineMarket.DataAccess.Repositories.Products;
public class ProductCommentRepository : GenericRepository<ProductComment>, IProductCommentRepository
{
    public ProductCommentRepository(AppDbContext context) : base(context)
    {
    }

    public IQueryable<ProductComment> GetAll(long productId)
        => _dbcontext.ProductComments.Where(productComment => productComment.ProductId == productId);
}
