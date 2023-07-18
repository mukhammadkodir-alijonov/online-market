global using OnlineMarket.Service.Interfaces.Categories;
using Microsoft.EntityFrameworkCore;
using OnlineMarket.DataAccess.Interfaces;
using OnlineMarket.Domain.Entities.Categories;
using OnlineMarket.Service.Common.Utils;

namespace OnlineMarket.Service.Services.Categories;
public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _repository;
    public CategoryService(IUnitOfWork unitOfWork)
    {
        this._repository = unitOfWork;
    }
    public async Task<IEnumerable<Category>> GetAllAsync(PaginationParams @params)
    {
        return await _repository.Categories.GetAll()
            .Skip((@params.PageNumber - 1) * @params.PageSize)
            .Take(@params.PageSize).ToListAsync();
    }
}
