using OnlineMarket.DataAccess.DbContexts;
using OnlineMarket.DataAccess.Interfaces.Employees;
using OnlineMarket.Domain.Entities.Employees;

namespace OnlineMarket.DataAccess.Repositories.Employees;

public class DeliverRepository : GenericRepository<Deliver>,
    IDeliverRepository
{
    public DeliverRepository(AppDbContext context) : base(context)
    {
    }
}
