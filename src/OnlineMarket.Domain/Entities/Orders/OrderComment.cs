using OnlineMarket.Domain.Common;
using OnlineMarket.Domain.Entities.Employees;

namespace OnlineMarket.Domain.Entities.Orders;
public class OrderComment : Auditable
{
    public long OperatorId { get; set; }
    public virtual Operator Operator { get; set; } = default!;

    public long OrderId { get; set; }
    public virtual Order Order { get; set; } = default!;

    public string Comment { get; set; } = String.Empty;
}
