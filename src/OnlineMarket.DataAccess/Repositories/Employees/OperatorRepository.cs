using OnlineMarket.DataAccess.DbContexts;
using OnlineMarket.DataAccess.Interfaces.Employees;
using OnlineMarket.Domain.Entities.Employees;

namespace OnlineMarket.DataAccess.Repositories.Employees;

public class OperatorRepository : GenericRepository<Operator>,
    IOperatorRepository
{
    public OperatorRepository(AppDbContext context) : base(context)
    {
    }
}
