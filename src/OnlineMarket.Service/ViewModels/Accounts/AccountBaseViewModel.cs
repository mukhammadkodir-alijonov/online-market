namespace OnlineMarket.Service.ViewModels.Accounts;
public class AccountBaseViewModel
{
    public long Id { get; set; }

    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public string Email { get; set; } = String.Empty;

    public string ImagePath { get; set; } = String.Empty;
}
