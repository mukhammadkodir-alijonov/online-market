namespace OnlineMarket.Domain.Entities.Employees;
public class Administator : Human
{
    public string PasswordHash { get; set; } = String.Empty;

    public string Salt { get; set; } = String.Empty;

    public bool IsHead { get; set; } = false;

    public string PassportSeria { get; set; } = String.Empty;

    public int PassportNumber { get; set; }
}
