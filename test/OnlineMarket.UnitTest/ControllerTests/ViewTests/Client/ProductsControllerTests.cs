using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineMarket.Service.Interfaces.Products;
using OnlineMarket.Web.Controllers;

namespace OnlineMarket.UnitTest.ControllerTests.ViewTests.Client;

public class ProductsControllerTests
{
    private readonly Mock<IProductService> _productService;
    private readonly ProductsController _controller;
    public ProductsControllerTests()
    {
        this._productService = new Mock<IProductService>();
        this._controller = new ProductsController(_productService.Object);
    }

    [Fact]
    public async Task ReturnIndexViewAsync()
    {
        int page = 2;
        var result = await _controller.Index(page);
        var type = Assert.IsType<ViewResult>(result);
        Assert.Equal("Index", type.ViewName);
    }
}
