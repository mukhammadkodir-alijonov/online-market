using Microsoft.AspNetCore.Mvc;

namespace OnlineMarket.Web.Areas.Administrator.Controllers;
public class HomeController : ControllerBase
{
    public IActionResult Index()
    {
        return View();
    }
}
