using OnlineMarket.DataAccess.Interfaces.Categories;
using OnlineMarket.DataAccess.Interfaces.Employees;
using OnlineMarket.DataAccess.Interfaces.Orders;
using OnlineMarket.DataAccess.Interfaces.Products;
using OnlineMarket.DataAccess.Interfaces.Users;

namespace OnlineMarket.DataAccess.Interfaces;
public interface IUnitOfWork
{
    public ICategoryRepository Categories { get; }

    public IAdministratorRepository Administrators { get;  }
    public IDeliverRepository Delivers { get;  }
    public IOperatorRepository Operators { get; }

    public IOrderCommentRepository OrderComments { get; }
    public IOrderDetailRepository OrderDetails { get; }
    public IOrderRepository Orders { get; }

    public IProductRepository Products { get; }
    public IProductCommentRepository ProductComments { get; }
    public IProductDiscountRepository ProductDiscounts { get; }

    public IUserRepository Users { get; }

    public Task<int> SaveChangesAsync();
}
