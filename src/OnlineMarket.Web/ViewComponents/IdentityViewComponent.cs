using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Service.Interfaces.Common;
using OnlineMarket.Service.ViewModels.Accounts;

namespace OnlineMarket.Web.ViewComponents;
public class IdentityViewComponent : ViewComponent
{
    private readonly IIdentityService _identityService;
    public IdentityViewComponent(IIdentityService identity)
    {
        this._identityService = identity;
    }
    public IViewComponentResult Invoke()
    {
        AccountBaseViewModel accountBaseViewModel = new AccountBaseViewModel()
        {
            Id = _identityService.Id!.Value,
            Email = _identityService.Email,
            FirstName = _identityService.FirstName,
            LastName = _identityService.LastName,
            ImagePath = _identityService.ImagePath
        };
        return View(accountBaseViewModel);
    }
}
