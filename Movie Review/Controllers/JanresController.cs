using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie_Review.Data;
using Movie_Review.Models;

namespace Movie_Review.Controllers
{
    public class JanresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JanresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Janres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Janre.ToListAsync());
        }

        // GET: Janres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var janre = await _context.Janre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (janre == null)
            {
                return NotFound();
            }

            return View(janre);
        }

        // GET: Janres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Janres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JanreName")] Janre janre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(janre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(janre);
        }

        // GET: Janres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var janre = await _context.Janre.FindAsync(id);
            if (janre == null)
            {
                return NotFound();
            }
            return View(janre);
        }

        // POST: Janres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JanreName")] Janre janre)
        {
            if (id != janre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(janre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JanreExists(janre.Id))
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
            return View(janre);
        }

        // GET: Janres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var janre = await _context.Janre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (janre == null)
            {
                return NotFound();
            }

            return View(janre);
        }

        // POST: Janres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var janre = await _context.Janre.FindAsync(id);
            _context.Janre.Remove(janre);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JanreExists(int id)
        {
            return _context.Janre.Any(e => e.Id == id);
        }
    }
}
