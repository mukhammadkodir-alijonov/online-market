using OnlineMarket.Domain.Entities.Orders;

namespace OnlineMarket.DataAccess.Interfaces.Orders;
public interface IOrderDetailRepository : IRepository<OrderDetail>
{
    IQueryable<OrderDetail> GetAll(long orderId);
}
