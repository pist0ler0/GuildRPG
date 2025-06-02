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

        public GuildController(GuildService guild, GuildRPGContext context)
        {
            this.guild = guild;
            this._context = context;
        }

        public IActionResult Index()
        {
            var guildMercenaries = guild.Mercenaries;
            return View(guildMercenaries);
        }
        public IActionResult HireMercenary(Mercenary merc)
        {
            var merc2 =  _context.Mercenary.FirstOrDefault(m => m.Id == merc.Id);
            guild.addMercenary(merc2);
            return RedirectToAction("Index");
        }

        public IActionResult HireMercenaryList()
        {
            var mercenaries = _context.Mercenary
                .Where(m => !guild.Mercenaries.Contains(m))
                .ToList();
            
            return View("HireMercenaryList", mercenaries);
        }
        public IActionResult Delete(int id)
        {
            var mercenary = _context.Mercenary.Find(id);
            if (mercenary != null)
            {
                guild.Mercenaries.Remove(mercenary);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
