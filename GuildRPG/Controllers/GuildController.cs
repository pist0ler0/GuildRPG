using GuildRPG.Data;
using GuildRPG.Models;
using GuildRPG.Services;
using GuildRPG.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult SelectMercAndQuest()
        {
            var mercAndQuestVM = new MercQuestViewModel
            {
                Mercenaries = _context.Mercenary
                .Where(m => guild.Mercenaries.Contains(m))
                .ToList(),
                Quests = _context.Quest.ToList()
            };
           
            return View(mercAndQuestVM);
        }

        public async Task<IActionResult> SendMercToQuest(MercQuestViewModel vm)
        {
            guild.sendMercenaryToQuest(vm.MercName, vm.QuestName);
            var mercenary = await _context.Mercenary.FirstOrDefaultAsync(m => m.Name == vm.MercName);
            _context.Mercenary.Update(mercenary);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
