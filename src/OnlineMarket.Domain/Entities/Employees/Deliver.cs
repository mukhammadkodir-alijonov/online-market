namespace OnlineMarket.Domain.Entities.Employees;

public class Deliver : Human
{
    public string PassportSeria { get; set; } = String.Empty;

    public int PassportNumber { get; set; }
}
