using OnlineMarket.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Service.Dtos.Accounts;
public class AccountLoginDto
{
    [Required(ErrorMessage = "Email kiritish majburiy")]
    [EmailAddress(ErrorMessage = "Email xato kiritildi")]
    public string Email { get; set; } = String.Empty;

    [Required(ErrorMessage = "Parol kiritish majburiy")]
    [StrongPassword]
    public string Password { get; set; } = String.Empty;
}
