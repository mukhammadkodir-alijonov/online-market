using OnlineMarket.Domain.Entities.Categories;

namespace OnlineMarket.Service.ViewModels.Products;
public class ProductViewModel : ProductBaseViewModel
{
    public string Description { get; set; } = String.Empty;

    public Category Category { get; set; } = default!;
}
