using OnlineMarket.Domain.Entities.Orders;

namespace OnlineMarket.DataAccess.Interfaces.Orders;
public interface IOrderCommentRepository : IRepository<OrderComment>
{
    IQueryable<OrderComment> GetAll(long orderId);
}
