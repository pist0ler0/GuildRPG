using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuildRPG.Data;
using GuildRPG.Models;

namespace GuildRPG.Controllers
{
    public class MonstersController : Controller
    {
        private readonly GuildRPGContext _context;

        public MonstersController(GuildRPGContext context)
        {
            _context = context;
        }

        // GET: Monsters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Monster.ToListAsync());
        }

        // GET: Monsters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = await _context.Monster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monster == null)
            {
                return NotFound();
            }

            return View(monster);
        }

        // GET: Monsters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monsters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Health,Damage")] Monster monster, IFormFile? imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                using var ms = new MemoryStream();
                await imageFile.CopyToAsync(ms);
                monster.ImageData = ms.ToArray();
                monster.ImageType = imageFile.ContentType;
            }
            if (ModelState.IsValid)
            {
                _context.Add(monster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monster);
        }

        // GET: Monsters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = await _context.Monster.FindAsync(id);
            if (monster == null)
            {
                return NotFound();
            }
            return View(monster);
        }

        // POST: Monsters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Health,Damage")] Monster monster, IFormFile? imageFile)
        {
            Console.WriteLine($"Plik: {imageFile?.FileName}, Rozmiar: {imageFile?.Length}");
            if (id != monster.Id)
            {
                return NotFound();
            }
            if (imageFile != null && imageFile.Length > 0)
            {
                using var ms = new MemoryStream();
                await imageFile.CopyToAsync(ms);
                monster.ImageData = ms.ToArray();
                monster.ImageType = imageFile.ContentType;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonsterExists(monster.Id))
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
            return View(monster);
        }

        // GET: Monsters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = await _context.Monster
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monster == null)
            {
                return NotFound();
            }

            return View(monster);
        }

        // POST: Monsters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monster = await _context.Monster.FindAsync(id);
            if (monster != null)
            {
                _context.Monster.Remove(monster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonsterExists(int id)
        {
            return _context.Monster.Any(e => e.Id == id);
        }
        public IActionResult GetImage(int id)
        {
            var monster = _context.Monster.FirstOrDefault(m => m.Id == id);
            if (monster?.ImageData == null || monster.ImageType == null)
                return NotFound();

            return File(monster.ImageData, monster.ImageType);
        }
    }
}
