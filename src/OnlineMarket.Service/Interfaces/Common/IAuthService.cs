using OnlineMarket.Domain.Entities.Users;

namespace OnlineMarket.Service.Interfaces.Common;
public interface IAuthService
{
    public string GenerateToken(User user);
}
