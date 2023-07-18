using OnlineMarket.DataAccess.DbContexts;
using OnlineMarket.DataAccess.Interfaces.Orders;
using OnlineMarket.Domain.Entities.Orders;

namespace OnlineMarket.DataAccess.Repositories.Orders;
public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }
}
