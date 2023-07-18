using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Service.Common.Utils;
using OnlineMarket.Service.Interfaces.Products;

namespace OnlineMarket.Web.Areas.Administrator.Controllers;
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly int _pageSize = 30;
    public ProductsController(IProductService productService)
    {
        this._productService = productService;
    }
    public async Task<ViewResult> Index(int page = 1)
    {
        var products = await _productService.GetAllAsync(new PaginationParams(page, _pageSize));
        return View(products);
    }
}
