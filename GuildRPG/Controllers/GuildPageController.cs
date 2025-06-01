using Microsoft.AspNetCore.Mvc;

namespace GuildRPG.Controllers
{
    public class GuildPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
