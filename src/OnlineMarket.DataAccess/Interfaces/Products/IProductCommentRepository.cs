using OnlineMarket.Domain.Entities.Products;

namespace OnlineMarket.DataAccess.Interfaces.Products;
public interface IProductCommentRepository : IRepository<ProductComment>
{
    IQueryable<ProductComment> GetAll(long productId);
}
