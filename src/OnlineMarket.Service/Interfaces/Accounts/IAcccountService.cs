using OnlineMarket.Service.Dtos.Accounts;

namespace OnlineMarket.Service.Interfaces.Accounts;
public interface IAccountService
{
    public Task<bool> RegisterAsync(AccountRegisterDto accountRegisterDto);

    public Task<string> LoginAsync(AccountLoginDto accountLoginDto);
}
