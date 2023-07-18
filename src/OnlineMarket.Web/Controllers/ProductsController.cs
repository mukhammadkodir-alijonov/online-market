using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Service.Common.Utils;
using OnlineMarket.Service.Interfaces.Products;

namespace OnlineMarket.Web.Controllers;

[Route("products")]
[Authorize]
public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly int _pageSize = 2;
    public ProductsController(IProductService productService)
    {
        this._productService = productService;
    }
    public async Task<IActionResult> Index(int page = 1)
    {
        var products = await _productService.GetAllAsync(new PaginationParams(page, _pageSize));
        return View("Index", products);
    }

    [HttpGet("{productId}")]
    public async Task<ViewResult> GetAsync(long productId)
    {
        var product = await _productService.GetAsync(productId);
        return View(product);
    }
}
