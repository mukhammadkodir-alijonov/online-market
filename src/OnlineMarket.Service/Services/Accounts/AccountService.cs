using OnlineMarket.DataAccess.Interfaces;
using OnlineMarket.Domain.Entities.Users;
using OnlineMarket.Service.Common.Exceptions;
using OnlineMarket.Service.Common.Security;
using OnlineMarket.Service.Dtos.Accounts;
using OnlineMarket.Service.Interfaces.Accounts;
using OnlineMarket.Service.Interfaces.Common;

namespace OnlineMarket.Service.Services.Accounts;
public class AccountService : IAccountService
{
    private readonly IUnitOfWork _repository;
    private readonly IAuthService _authService;
    public AccountService(IUnitOfWork unitOfWork, IAuthService authService)
    {
        this._repository = unitOfWork;
        this._authService = authService;
    }
    public async Task<string> LoginAsync(AccountLoginDto accountLoginDto)
    {
        var emailedUser = await _repository.Users.FirstOrDefaultAsync(x => x.Email == accountLoginDto.Email);
        if (emailedUser is null) throw new ModelErrorException(nameof(accountLoginDto.Email), "Bunday email bilan foydalanuvchi mavjud emas!");

        var hasherResult = PasswordHasher.Verify(accountLoginDto.Password, emailedUser.Salt, emailedUser.PasswordHash);
        if (hasherResult)
        {
            string token = _authService.GenerateToken(emailedUser);
            return token;
        }
        else throw new ModelErrorException(nameof(accountLoginDto.Password), "Parol xato terildi!");
    }

    public async Task<bool> RegisterAsync(AccountRegisterDto accountRegisterDto)
    {
        var emailedUser = await _repository.Users.FirstOrDefaultAsync(x => x.Email == accountRegisterDto.Email);
        if (emailedUser is not null) throw new Exception();

        var phonedUser = await _repository.Users.FirstOrDefaultAsync(x => x.PhoneNumber == accountRegisterDto.PhoneNumber);
        if (phonedUser is not null) throw new Exception();

        var hasherResult = PasswordHasher.Hash(accountRegisterDto.Password);
        var user = (User) accountRegisterDto;
        user.PasswordHash = hasherResult.Hash;
        user.Salt = hasherResult.Salt;

        _repository.Users.Add(user);
        var dbResult = await _repository.SaveChangesAsync();
        return dbResult > 0;
    }
}
