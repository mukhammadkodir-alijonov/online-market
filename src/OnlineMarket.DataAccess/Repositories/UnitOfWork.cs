using OnlineMarket.DataAccess.DbContexts;
using OnlineMarket.DataAccess.Interfaces;
using OnlineMarket.DataAccess.Interfaces.Categories;
using OnlineMarket.DataAccess.Interfaces.Employees;
using OnlineMarket.DataAccess.Interfaces.Orders;
using OnlineMarket.DataAccess.Interfaces.Products;
using OnlineMarket.DataAccess.Interfaces.Users;
using OnlineMarket.DataAccess.Repositories.Categories;
using OnlineMarket.DataAccess.Repositories.Employees;
using OnlineMarket.DataAccess.Repositories.Orders;
using OnlineMarket.DataAccess.Repositories.Products;
using OnlineMarket.DataAccess.Repositories.Users;

namespace OnlineMarket.DataAccess.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext dbContext;
    public ICategoryRepository Categories { get; }

    public IAdministratorRepository Administrators { get; }
    public IDeliverRepository Delivers { get; }
    public IOperatorRepository Operators { get; }
    
    public IOrderCommentRepository OrderComments { get; }
    public IOrderDetailRepository OrderDetails { get; }
    public IOrderRepository Orders { get; }
    
    public IProductRepository Products { get; }
    public IProductCommentRepository ProductComments { get; }
    public IProductDiscountRepository ProductDiscounts { get; }
    
    public IUserRepository Users { get; }

    public UnitOfWork(AppDbContext appDbContext)
    {
        this.dbContext = appDbContext;
        Categories = new CategoryRepository(appDbContext);

        Administrators = new AdministratorRepository(appDbContext);
        Delivers = new DeliverRepository(appDbContext);
        Operators = new OperatorRepository(appDbContext);

        Orders = new OrderRepository(appDbContext);
        OrderDetails = new OrderDetailRepository(appDbContext);
        OrderComments = new OrderCommentRepository(appDbContext);

        ProductDiscounts = new ProductDiscountRepository(appDbContext);
        ProductComments = new ProductCommentRepository(appDbContext);
        Products = new ProductRepository(appDbContext);

        Users = new UserRepository(appDbContext);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await dbContext.SaveChangesAsync();
    }
}
