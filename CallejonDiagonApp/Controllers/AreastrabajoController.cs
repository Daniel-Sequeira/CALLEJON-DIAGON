using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CallejonDiagonApp.Models;

namespace CallejonDiagonApp.Controllers
{
    public class AreastrabajoController : Controller
    {
        private readonly CallejondiagonContext _context;

        public AreastrabajoController(CallejondiagonContext context)
        {
            _context = context;
        }

        // GET: Areastrabajo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Areastrabajos.ToListAsync());
        }

        // GET: Areastrabajo/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areastrabajo = await _context.Areastrabajos
                .FirstOrDefaultAsync(m => m.IdArea == id);
            if (areastrabajo == null)
            {
                return NotFound();
            }

            return View(areastrabajo);
        }

        // GET: Areastrabajo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Areastrabajo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArea,NombreArea")] Areastrabajo areastrabajo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areastrabajo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(areastrabajo);
        }

        // GET: Areastrabajo/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areastrabajo = await _context.Areastrabajos.FindAsync(id);
            if (areastrabajo == null)
            {
                return NotFound();
            }
            return View(areastrabajo);
        }

        // POST: Areastrabajo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("IdArea,NombreArea")] Areastrabajo areastrabajo)
        {
            if (id != areastrabajo.IdArea)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areastrabajo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreastrabajoExists(areastrabajo.IdArea))
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
            return View(areastrabajo);
        }

        // GET: Areastrabajo/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areastrabajo = await _context.Areastrabajos
                .FirstOrDefaultAsync(m => m.IdArea == id);
            if (areastrabajo == null)
            {
                return NotFound();
            }

            return View(areastrabajo);
        }

        // POST: Areastrabajo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var areastrabajo = await _context.Areastrabajos.FindAsync(id);
            if (areastrabajo != null)
            {
                _context.Areastrabajos.Remove(areastrabajo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreastrabajoExists(byte id)
        {
            return _context.Areastrabajos.Any(e => e.IdArea == id);
        }
    }
}
