using OnlineMarket.DataAccess.DbContexts;
using OnlineMarket.DataAccess.Interfaces.Orders;
using OnlineMarket.Domain.Entities.Orders;

namespace OnlineMarket.DataAccess.Repositories.Orders;
public class OrderCommentRepository : GenericRepository<OrderComment>, IOrderCommentRepository
{
    public OrderCommentRepository(AppDbContext context) : base(context)
    {
    }

    public IQueryable<OrderComment> GetAll(long orderId)
    {
        throw new NotImplementedException();
    }
}
