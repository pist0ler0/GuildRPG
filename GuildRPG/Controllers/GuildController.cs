using GuildRPG.Models;
using GuildRPG.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuildRPG.Controllers
{
    public class GuildController : Controller
    {
        private readonly Guild guild;

        public GuildController(Guild guild)
        {
            this.guild = guild;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HireMercenary(Mercenary merc)
        {
            guild.addMercenary(merc);
            return RedirectToAction("Index");
        }
    }
}
