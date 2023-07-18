using OnlineMarket.DataAccess.DbContexts;
using OnlineMarket.DataAccess.Interfaces.Categories;
using OnlineMarket.Domain.Entities.Categories;

namespace OnlineMarket.DataAccess.Repositories.Categories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
