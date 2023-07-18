using OnlineMarket.DataAccess.DbContexts;
using OnlineMarket.DataAccess.Interfaces.Orders;
using OnlineMarket.Domain.Entities.Orders;

namespace OnlineMarket.DataAccess.Repositories.Orders;

public class OrderDetailRepository : GenericRepository<OrderDetail>, IOrderDetailRepository
{
    public OrderDetailRepository(AppDbContext context) : base(context)
    {
    }

    public IQueryable<OrderDetail> GetAll(long orderId)
        => _dbSet.Where(x => x.OrderId == orderId);
}
