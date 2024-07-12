using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniverseRepo.Data;
using UniverseRepo.Models;

namespace UniverseRepo.Controllers
{
    public class UniversesController : Controller
    {
        private readonly UniverseRepoContext _context;

        public UniversesController(UniverseRepoContext context)
        {
            _context = context;
        }

        // GET: Universes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Universe.ToListAsync());
        }

        // GET: Universes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universe = await _context.Universe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universe == null)
            {
                return NotFound();
            }

            return View(universe);
        }

        // GET: Universes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Universes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,universe_Name,created_by,description")] Universe universe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(universe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(universe);
        }

        // GET: Universes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universe = await _context.Universe.FindAsync(id);
            if (universe == null)
            {
                return NotFound();
            }
            return View(universe);
        }

        // POST: Universes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,universe_Name,created_by,description")] Universe universe)
        {
            if (id != universe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniverseExists(universe.Id))
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
            return View(universe);
        }

        // GET: Universes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universe = await _context.Universe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universe == null)
            {
                return NotFound();
            }

            return View(universe);
        }

        // POST: Universes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var universe = await _context.Universe.FindAsync(id);
            if (universe != null)
            {
                _context.Universe.Remove(universe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniverseExists(int id)
        {
            return _context.Universe.Any(e => e.Id == id);
        }
    }
}
