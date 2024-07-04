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
    public class MetodopagoController : Controller
    {
        private readonly CallejondiagonContext _context;

        public MetodopagoController(CallejondiagonContext context)
        {
            _context = context;
        }

        // GET: Metodopago
        public async Task<IActionResult> Index()
        {
            return View(await _context.Metodopagos.ToListAsync());
        }

        // GET: Metodopago/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodopago = await _context.Metodopagos
                .FirstOrDefaultAsync(m => m.IdMetodoPago == id);
            if (metodopago == null)
            {
                return NotFound();
            }

            return View(metodopago);
        }

        // GET: Metodopago/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Metodopago/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMetodoPago,TipoPago")] Metodopago metodopago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metodopago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metodopago);
        }

        // GET: Metodopago/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodopago = await _context.Metodopagos.FindAsync(id);
            if (metodopago == null)
            {
                return NotFound();
            }
            return View(metodopago);
        }

        // POST: Metodopago/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("IdMetodoPago,TipoPago")] Metodopago metodopago)
        {
            if (id != metodopago.IdMetodoPago)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metodopago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetodopagoExists(metodopago.IdMetodoPago))
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
            return View(metodopago);
        }

        // GET: Metodopago/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metodopago = await _context.Metodopagos
                .FirstOrDefaultAsync(m => m.IdMetodoPago == id);
            if (metodopago == null)
            {
                return NotFound();
            }

            return View(metodopago);
        }

        // POST: Metodopago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var metodopago = await _context.Metodopagos.FindAsync(id);
            if (metodopago != null)
            {
                _context.Metodopagos.Remove(metodopago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetodopagoExists(byte id)
        {
            return _context.Metodopagos.Any(e => e.IdMetodoPago == id);
        }
    }
}
