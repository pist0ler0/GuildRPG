using GuildRPG.Data;
using GuildRPG.Models;
using GuildRPG.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuildRPG.Controllers
{
    public class GuildController : Controller
    {
        private readonly GuildService guild;
        private readonly GuildRPGContext _context;

        public GuildController(GuildService guild)
        {
            this.guild = guild;
        }

        public IActionResult Index()
        {
            var guildMercenaries = guild.Mercenaries;
            return View(guildMercenaries);
        }
        public IActionResult HireMercenary(Mercenary merc)
        {
            guild.addMercenary(merc);
            return RedirectToAction("Index");
        }
    }
}
