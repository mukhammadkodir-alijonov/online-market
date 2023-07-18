using OnlineMarket.Domain.Common;
using OnlineMarket.Domain.Entities.Users;

namespace OnlineMarket.Domain.Entities.Products;
public class ProductComment : Auditable
{
    public long UserId { get; set; }

    public virtual User User { get; set; } = default!;

    public long ProductId { get; set; }

    public virtual Product Product { get; set; } = default!;

    public string Comment { get; set; } = String.Empty;

    public bool Updated { get; set; } = false;
}
