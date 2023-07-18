using OnlineMarket.DataAccess.DbContexts;
using OnlineMarket.DataAccess.Interfaces.Users;
using OnlineMarket.Domain.Entities.Users;

namespace OnlineMarket.DataAccess.Repositories.Users;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}
