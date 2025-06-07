using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuildRPG.Data;
using GuildRPG.Models;
using GuildRPG.ViewModels;

namespace GuildRPG.Controllers
{
    public class MercenariesController : Controller
    {
        private readonly GuildRPGContext _context;

        public MercenariesController(GuildRPGContext context)
        {
            _context = context;
        }

        // GET: Mercenaries
        public async Task<IActionResult> Index(string sortOrder, int pageNumber = 1, int pageSize = 5)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["LevelSortParm"] = sortOrder == "Level" ? "level_desc" : "Level";

            var query = _context.Mercenary.AsQueryable();

            // Sortowanie
            switch (sortOrder)
            {
                case "Level":
                    query = query.OrderBy(m => m.Level);
                    break;
                case "level_desc":
                    query = query.OrderByDescending(m => m.Level);
                    break;
                default:
                    query = query.OrderBy(m => m.Id);
                    break;
            }

            var totalMercenaries = await query.CountAsync();

            var mercenaries = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var vm = new MercPageViewModel
            {
                Mercenaries = mercenaries,
                PageNumber = pageNumber,
                TotalPages = (int)Math.Ceiling((double)totalMercenaries / pageSize),
                CurrentSort = sortOrder // Dodaj do ViewModelu
            };

            return View(vm);
        }
        // GET: Mercenaries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mercenary = await _context.Mercenary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mercenary == null)
            {
                return NotFound();
            }

            return View(mercenary);
        }

        // GET: Mercenaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mercenaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Level,ExperiencePoints,MaxHealth,CurrentHealth,Damage,Gold")] Mercenary mercenary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mercenary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mercenary);
        }

        // GET: Mercenaries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mercenary = await _context.Mercenary.FindAsync(id);
            if (mercenary == null)
            {
                return NotFound();
            }
            return View(mercenary);
        }

        // POST: Mercenaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Level,ExperiencePoints,MaxHealth,CurrentHealth,Damage,Gold")] Mercenary mercenary)
        {
            if (id != mercenary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mercenary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MercenaryExists(mercenary.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(mercenary);
        }

        // GET: Mercenaries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mercenary = await _context.Mercenary
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mercenary == null)
            {
                return NotFound();
            }

            return View(mercenary);
        }

        // POST: Mercenaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mercenary = await _context.Mercenary.FindAsync(id);
            if (mercenary != null)
            {
                _context.Mercenary.Remove(mercenary);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MercenaryExists(int id)
        {
            return _context.Mercenary.Any(e => e.Id == id);
        }
    }
}
