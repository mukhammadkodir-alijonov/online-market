namespace OnlineMarket.Domain.Entities.Users
{
    public class User : Human
    {
        public string PasswordHash { get; set; } = String.Empty;

        public string Salt { get; set; } = String.Empty;
    }
}
