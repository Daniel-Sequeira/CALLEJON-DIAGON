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
    public class DetallesalariosController : Controller
    {
        private readonly CallejondiagonContext _context;

        public DetallesalariosController(CallejondiagonContext context)
        {
            _context = context;
        }

        // GET: Detallesalarios
        public async Task<IActionResult> Index()
        {
            var callejondiagonContext = _context.Detallesalarios.Include(d => d.IdSalarioNavigation);
            return View(await callejondiagonContext.ToListAsync());
        }

        // GET: Detallesalarios/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallesalario = await _context.Detallesalarios
                .Include(d => d.IdSalarioNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleSalario == id);
            if (detallesalario == null)
            {
                return NotFound();
            }

            return View(detallesalario);
        }

        // GET: Detallesalarios/Create
        public IActionResult Create()
        {
            ViewData["IdSalario"] = new SelectList(_context.Salarios, "IdSalario", "IdSalario");
            return View();
        }

        // POST: Detallesalarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleSalario,IdSalario,Fecha,SubtotalSalario,TotalSalario")] Detallesalario detallesalario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallesalario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSalario"] = new SelectList(_context.Salarios, "IdSalario", "IdSalario", detallesalario.IdSalario);
            return View(detallesalario);
        }

        // GET: Detallesalarios/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallesalario = await _context.Detallesalarios.FindAsync(id);
            if (detallesalario == null)
            {
                return NotFound();
            }
            ViewData["IdSalario"] = new SelectList(_context.Salarios, "IdSalario", "IdSalario", detallesalario.IdSalario);
            return View(detallesalario);
        }

        // POST: Detallesalarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("IdDetalleSalario,IdSalario,Fecha,SubtotalSalario,TotalSalario")] Detallesalario detallesalario)
        {
            if (id != detallesalario.IdDetalleSalario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallesalario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallesalarioExists(detallesalario.IdDetalleSalario))
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
            ViewData["IdSalario"] = new SelectList(_context.Salarios, "IdSalario", "IdSalario", detallesalario.IdSalario);
            return View(detallesalario);
        }

        // GET: Detallesalarios/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallesalario = await _context.Detallesalarios
                .Include(d => d.IdSalarioNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleSalario == id);
            if (detallesalario == null)
            {
                return NotFound();
            }

            return View(detallesalario);
        }

        // POST: Detallesalarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            var detallesalario = await _context.Detallesalarios.FindAsync(id);
            if (detallesalario != null)
            {
                _context.Detallesalarios.Remove(detallesalario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallesalarioExists(ulong id)
        {
            return _context.Detallesalarios.Any(e => e.IdDetalleSalario == id);
        }
    }
}
