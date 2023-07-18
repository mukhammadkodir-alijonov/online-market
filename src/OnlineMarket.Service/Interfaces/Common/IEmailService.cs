using OnlineMarket.Service.Dtos.Common;

namespace OnlineMarket.Service.Interfaces.Common;
public interface IEmailService
{
    public Task<bool> SendAsync(EmailMessage emailMessage);
}
