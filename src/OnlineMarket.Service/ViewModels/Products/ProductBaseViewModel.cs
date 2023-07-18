namespace OnlineMarket.Service.ViewModels.Products;
public class ProductBaseViewModel
{
    public long Id { get; set; }

    public string Name { get; set; } = String.Empty;

    public double OriginalPrice { get; set; }

    public double DiscountPrice { get; set; }

    public double ResultPrice { get; set; }

    public string ImagePath { get; set; } = String.Empty;

}
