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
    public class ComprasdetallesController : Controller
    {
        private readonly CallejondiagonContext _context;

        public ComprasdetallesController(CallejondiagonContext context)
        {
            _context = context;
        }

        // GET: Comprasdetalles
        public async Task<IActionResult> Index()
        {
            var callejondiagonContext = _context.Comprasdetalles.Include(c => c.Compra);
            return View(await callejondiagonContext.ToListAsync());
        }

        // GET: Comprasdetalles/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprasdetalle = await _context.Comprasdetalles
                .Include(c => c.Compra)
                .FirstOrDefaultAsync(m => m.IdCompraDetalle == id);
            if (comprasdetalle == null)
            {
                return NotFound();
            }

            return View(comprasdetalle);
        }

        // GET: Comprasdetalles/Create
        public IActionResult Create()
        {
            ViewData["ComprasIdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra");
            return View();
        }

        // POST: Comprasdetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompraDetalle,IdCompra,IdProducto,PrecioCostoUnitario,Cantidad,ImporteTotalCompra,ComprasIdCompra,ComprasProveedoresIdProveedor")] Comprasdetalle comprasdetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comprasdetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComprasIdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", comprasdetalle.ComprasIdCompra);
            return View(comprasdetalle);
        }

        // GET: Comprasdetalles/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprasdetalle = await _context.Comprasdetalles.FindAsync(id);
            if (comprasdetalle == null)
            {
                return NotFound();
            }
            ViewData["ComprasIdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", comprasdetalle.ComprasIdCompra);
            return View(comprasdetalle);
        }

        // POST: Comprasdetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdCompraDetalle,IdCompra,IdProducto,PrecioCostoUnitario,Cantidad,ImporteTotalCompra,ComprasIdCompra,ComprasProveedoresIdProveedor")] Comprasdetalle comprasdetalle)
        {
            if (id != comprasdetalle.IdCompraDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comprasdetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComprasdetalleExists(comprasdetalle.IdCompraDetalle))
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
            ViewData["ComprasIdCompra"] = new SelectList(_context.Compras, "IdCompra", "IdCompra", comprasdetalle.ComprasIdCompra);
            return View(comprasdetalle);
        }

        // GET: Comprasdetalles/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comprasdetalle = await _context.Comprasdetalles
                .Include(c => c.Compra)
                .FirstOrDefaultAsync(m => m.IdCompraDetalle == id);
            if (comprasdetalle == null)
            {
                return NotFound();
            }

            return View(comprasdetalle);
        }

        // POST: Comprasdetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var comprasdetalle = await _context.Comprasdetalles.FindAsync(id);
            if (comprasdetalle != null)
            {
                _context.Comprasdetalles.Remove(comprasdetalle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComprasdetalleExists(long id)
        {
            return _context.Comprasdetalles.Any(e => e.IdCompraDetalle == id);
        }
    }
}
