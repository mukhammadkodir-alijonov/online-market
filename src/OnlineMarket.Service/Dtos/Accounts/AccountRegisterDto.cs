using OnlineMarket.Domain.Entities.Users;
using OnlineMarket.Service.Common.Attributes;
using OnlineMarket.Service.Common.Helpers;
using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Service.Dtos.Accounts;
public class AccountRegisterDto : AccountLoginDto
{
    [Required(ErrorMessage = "Ismingizni kiriting!")]
    public string FirstName { get; set; } = String.Empty;

    [Required(ErrorMessage = "familiyangizni kiriting!")]
    public string LastName { get; set; } = String.Empty;

    [Required(ErrorMessage = "Telefon raqamingizni kiriting!")]
    [PhoneNumber]
    public string PhoneNumber { get; set; } = String.Empty;

    public static implicit operator User(AccountRegisterDto accountRegisterDto)
    {
        return new User()
        {
            FirstName = accountRegisterDto.FirstName,
            LastName = accountRegisterDto.LastName,
            Email = accountRegisterDto.Email,
            EmailConfirmed = false,
            PhoneNumber = accountRegisterDto.PhoneNumber,
            PhoneNumberConfirmed = false,
            CreatedAt = TimeHelper.GetCurrentServerTime(),
            UpdatedAt = TimeHelper.GetCurrentServerTime()
        };
    }
}
