using OnlineMarket.DataAccess.DbContexts;
using OnlineMarket.DataAccess.Interfaces.Employees;
using OnlineMarket.Domain.Entities.Employees;

namespace OnlineMarket.DataAccess.Repositories.Employees;

public class AdministratorRepository : GenericRepository<Administator>,
    IAdministratorRepository
{
    public AdministratorRepository(AppDbContext context) : base(context)
    {
    }
}
