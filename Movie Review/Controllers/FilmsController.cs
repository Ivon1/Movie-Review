using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie_Review.Data;
using Movie_Review.Models;
using Microsoft.AspNetCore.Hosting;
using Movie_Review.ViewModels;

namespace Movie_Review.Controllers
{
    public class FilmsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _host;

        public FilmsController(ApplicationDbContext context, IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }

        // GET: Films
        public async Task<IActionResult> Index(int? cid, int? pid, int page = 1)
        {
            int pageSize = 4;
            IQueryable<Film> films = _context.Film.Include(f => f.Janre).Include(f => f.Producer);

            if (cid != null && cid != 0)
                films = films.Where(f => f.JanreId == cid);
            if (pid != null && pid != 0)
                films = films.Where(f => f.ProducerId == pid);

            List<Janre> jenres = _context.Janre.ToList();
            List<Producer> producers = _context.Producer.ToList();

            jenres.Insert(0, new Janre() { Id = 0, JanreName = "All jenres" });
            producers.Insert(0, new Producer() { Id = 0, ProducerName = "All directors" });

            var count = await films.CountAsync();
            var items = await films.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);

            FilterViewModel viewModel = new FilterViewModel()
            {
                Films = items,
                Janres = new SelectList(jenres, "Id", "JenreName"),
                Producers = new SelectList(producers, "Id", "ProducerName"),
                PageViewModel = pageViewModel
            };

            return View(viewModel);
            //var applicationDbContext = _context.Film.Include(f => f.Country).Include(f => f.Janre).Include(f => f.Producer);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .Include(f => f.Country)
                .Include(f => f.Janre)
                .Include(f => f.Producer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "CountryName");
            ViewData["JanreId"] = new SelectList(_context.Janre, "Id", "JanreName");
            ViewData["ProducerId"] = new SelectList(_context.Producer, "Id", "ProducerName");
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FimlTitle,MovieDescription,PathToPhoto,Rate,ProducerId,CountryId,JanreId,Url")] Film film, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                //if (image != null)
                //{
                //    var name = Path.Combine(_host.WebRootPath + "/img/Films/", Path.GetFileName(image.FileName));
                //    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                //    film.PathToPhoto = image.FileName;
                //} else
                //{
                //    film.PathToPhoto = "default.png";
                //}

                _context.Add(film);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "CountryName", film.CountryId);
            ViewData["JanreId"] = new SelectList(_context.Janre, "Id", "JanreName", film.JanreId);
            ViewData["ProducerId"] = new SelectList(_context.Producer, "Id", "ProducerName", film.ProducerId);
            return View(film);
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "CountryName", film.CountryId);
            ViewData["JanreId"] = new SelectList(_context.Janre, "Id", "JanreName", film.JanreId);
            ViewData["ProducerId"] = new SelectList(_context.Producer, "Id", "ProducerName", film.ProducerId);
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FimlTitle,MovieDescription,PathToPhoto,Rate,ProducerId,CountryId,JanreId,Url")] Film film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(film);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Country, "Id", "CountryName", film.CountryId);
            ViewData["JanreId"] = new SelectList(_context.Janre, "Id", "JanreName", film.JanreId);
            ViewData["ProducerId"] = new SelectList(_context.Producer, "Id", "ProducerName", film.ProducerId);
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .Include(f => f.Country)
                .Include(f => f.Janre)
                .Include(f => f.Producer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Film.FindAsync(id);
            _context.Film.Remove(film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return _context.Film.Any(e => e.Id == id);
        }
    }
}
