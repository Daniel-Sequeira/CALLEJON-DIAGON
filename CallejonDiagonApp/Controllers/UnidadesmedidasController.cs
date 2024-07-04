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
    public class UnidadesmedidasController : Controller
    {
        private readonly CallejondiagonContext _context;

        public UnidadesmedidasController(CallejondiagonContext context)
        {
            _context = context;
        }

        // GET: Unidadesmedidas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Unidadesmedidas.ToListAsync());
        }

        // GET: Unidadesmedidas/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadesmedida = await _context.Unidadesmedidas
                .FirstOrDefaultAsync(m => m.IdUnidadMedida == id);
            if (unidadesmedida == null)
            {
                return NotFound();
            }

            return View(unidadesmedida);
        }

        // GET: Unidadesmedidas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Unidadesmedidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUnidadMedida,AbreviaturaMedida,DescripcionMedida,MedidaStatus")] Unidadesmedida unidadesmedida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadesmedida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadesmedida);
        }

        // GET: Unidadesmedidas/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadesmedida = await _context.Unidadesmedidas.FindAsync(id);
            if (unidadesmedida == null)
            {
                return NotFound();
            }
            return View(unidadesmedida);
        }

        // POST: Unidadesmedidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("IdUnidadMedida,AbreviaturaMedida,DescripcionMedida,MedidaStatus")] Unidadesmedida unidadesmedida)
        {
            if (id != unidadesmedida.IdUnidadMedida)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadesmedida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadesmedidaExists(unidadesmedida.IdUnidadMedida))
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
            return View(unidadesmedida);
        }

        // GET: Unidadesmedidas/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadesmedida = await _context.Unidadesmedidas
                .FirstOrDefaultAsync(m => m.IdUnidadMedida == id);
            if (unidadesmedida == null)
            {
                return NotFound();
            }

            return View(unidadesmedida);
        }

        // POST: Unidadesmedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var unidadesmedida = await _context.Unidadesmedidas.FindAsync(id);
            if (unidadesmedida != null)
            {
                _context.Unidadesmedidas.Remove(unidadesmedida);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadesmedidaExists(byte id)
        {
            return _context.Unidadesmedidas.Any(e => e.IdUnidadMedida == id);
        }
    }
}
