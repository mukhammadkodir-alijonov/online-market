using OnlineMarket.Domain.Common;
using OnlineMarket.Domain.Entities.Products;

namespace OnlineMarket.Domain.Entities.Orders;
public class OrderDetail : BaseEntity
{
    public long OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;

    public long ProductId { get; set; }
    public virtual Product Product { get; set; } = default!;
    
    public int Amount { get; set; }

    public double Price { get; set; }
}
