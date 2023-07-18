using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataAccess.Interfaces;
using OnlineMarket.Service.Common.Exceptions;
using OnlineMarket.Service.Common.Helpers;
using OnlineMarket.Service.Common.Utils;
using OnlineMarket.Service.Interfaces.Products;
using OnlineMarket.Service.ViewModels.Products;
using System.Diagnostics;

namespace OnlineMarket.Service.Services.Products;
public class ProductService : IProductService
{
    private readonly IUnitOfWork _repository;
    public ProductService(IUnitOfWork unitOfWork)
    {
        this._repository = unitOfWork;
    }
    public async Task<PagedList<ProductBaseViewModel>> GetAllAsync(PaginationParams @params)
    {
        var query = from product in _repository.Products.GetAll()
                    let discountPrice = _repository.ProductDiscounts.GetAll().Where(discount =>
                        discount.StartDate < TimeHelper.GetCurrentServerTime() 
                        && discount.EndDate > TimeHelper.GetCurrentServerTime()
                        && discount.ProductId == product.Id).Sum(x=>x.Price)
                    orderby product.CreatedAt descending
                    select new ProductBaseViewModel()
                    {
                        Id=product.Id,
                        Name = product.Name,
                        ImagePath = product.ImagePath,
                        OriginalPrice = product.Price,
                        DiscountPrice = discountPrice,
                        ResultPrice = product.Price - discountPrice
                    };

        var result =  await PagedList<ProductBaseViewModel>.ToPagedListAsync(query, @params);
        return result;
    }

    public async Task<ProductViewModel> GetAsync(long productId)
    {
        var product = await _repository.Products.GetAll().Include(x=>
            x.Category).FirstOrDefaultAsync(product=>product.Id==productId);
        if (product is null) throw new NotFoundException("Maxsulot", "Ushbu id bilan maxsulot topilmadi!");

        double discount = _repository.ProductDiscounts.GetAll().Where(discount =>
                        discount.StartDate < TimeHelper.GetCurrentServerTime()
                        && discount.EndDate > TimeHelper.GetCurrentServerTime()
                        && discount.ProductId == product.Id).Sum(x => x.Price);

        return new ProductViewModel()
        {
            Id = product.Id,
            Name = product.Name,
            ImagePath = product.ImagePath,
            OriginalPrice = product.Price,
            DiscountPrice = discount,
            ResultPrice = product.Price - discount,
            Category=product.Category,
            Description = product.Description
        };
    }
}
