using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VozniRedVlakova.Data;
using VozniRedVlakova.Models;

namespace VozniRedVlakova.Controllers
{
    public class VlakController : Controller
    {
        private readonly VozniRedVlakovaContext _context;

        public VlakController(VozniRedVlakovaContext context)
        {
            _context = context;
        }

        // GET: Vlak
        public async Task<IActionResult> Index()
        {
              return _context.Vlak != null ? 
                          View(await _context.Vlak.ToListAsync()) :
                          Problem("Entity set 'VozniRedVlakovaContext.Vlak'  is null.");
        }

        // GET: Vlak/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vlak == null)
            {
                return NotFound();
            }

            var vlak = await _context.Vlak
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vlak == null)
            {
                return NotFound();
            }

            return View(vlak);
        }

        // GET: Vlak/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vlak/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,MaxBrzina,MjestaPoVagonu")] Vlak vlak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vlak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vlak);
        }

        // GET: Vlak/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vlak == null)
            {
                return NotFound();
            }

            var vlak = await _context.Vlak.FindAsync(id);
            if (vlak == null)
            {
                return NotFound();
            }
            return View(vlak);
        }

        // POST: Vlak/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,MaxBrzina,MjestaPoVagonu")] Vlak vlak)
        {
            if (id != vlak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vlak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VlakExists(vlak.Id))
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
            return View(vlak);
        }

        // GET: Vlak/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vlak == null)
            {
                return NotFound();
            }

            var vlak = await _context.Vlak
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vlak == null)
            {
                return NotFound();
            }

            return View(vlak);
        }

        // POST: Vlak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vlak == null)
            {
                return Problem("Entity set 'VozniRedVlakovaContext.Vlak'  is null.");
            }
            var vlak = await _context.Vlak.FindAsync(id);
            if (vlak != null)
            {
                _context.Vlak.Remove(vlak);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VlakExists(int id)
        {
          return (_context.Vlak?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
