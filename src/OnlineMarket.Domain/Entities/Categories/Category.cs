using OnlineMarket.Domain.Common;

namespace OnlineMarket.Domain.Entities.Categories;
public class Category : Auditable
{
    public string Title { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public string? ImagePath { get; set; }
}
