namespace OnlineMarket.Domain.Entities.Employees;
public class Operator : Human
{
    public string PasswordHash { get; set; } = String.Empty;

    public string Salt { get; set; } = String.Empty;

    public string PassportSeria { get; set; } = String.Empty;

    public int PassportNumber { get; set; }
}
