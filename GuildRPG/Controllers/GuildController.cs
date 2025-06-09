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
            var guildMercenaries = _context.Mercenary
            .Where(m => guild.Mercenaries.Select(x => x.Id).Contains(m.Id))
            .ToList();
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
                .Where(m => guild.Mercenaries.Contains(m) && m.CurrentHealth > 0)
                .ToList(),
                Quests = _context.Quest.ToList()
            };
           
            return View(mercAndQuestVM);
        }

        public IActionResult SendMercToQuest(MercQuestViewModel vm)
        {
            guild.sendMercenaryToQuest(vm.MercName, vm.QuestName);
           var merc = _context.Mercenary.FirstOrDefault(x => x.Name.Equals(vm.MercName));
            if (merc.CurrentHealth <= 0)
            {
                return RedirectToAction("Lose");
            }
            else
            {
                return RedirectToAction("Win");
            }
        }

        public IActionResult Win()
        {
            return View();
        }

        public IActionResult Lose() { return View(); }
    }
}
