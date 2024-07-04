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
    public class VentasdetallesController : Controller
    {
        private readonly CallejondiagonContext _context;

        public VentasdetallesController(CallejondiagonContext context)
        {
            _context = context;
        }

        // GET: Ventasdetalles
        public async Task<IActionResult> Index()
        {
            var callejondiagonContext = _context.Ventasdetalles.Include(v => v.VentasIdVentaNavigation);
            return View(await callejondiagonContext.ToListAsync());
        }

        // GET: Ventasdetalles/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasdetalle = await _context.Ventasdetalles
                .Include(v => v.VentasIdVentaNavigation)
                .FirstOrDefaultAsync(m => m.IdVentaDetalle == id);
            if (ventasdetalle == null)
            {
                return NotFound();
            }

            return View(ventasdetalle);
        }

        // GET: Ventasdetalles/Create
        public IActionResult Create()
        {
            ViewData["VentasIdVenta"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta");
            return View();
        }

        // POST: Ventasdetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVentaDetalle,IdVenta,IdProducto,PrecioVentaUnitario,Cantidad,ImporteTotalVenta,VentasIdVenta,VentasClientesIdCliente,ProductosIdProducto,ProductosUnidadesMedidasIdUnidadMedida,ProductosProveedoresIdProveedor")] Ventasdetalle ventasdetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventasdetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VentasIdVenta"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta", ventasdetalle.VentasIdVenta);
            return View(ventasdetalle);
        }

        // GET: Ventasdetalles/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasdetalle = await _context.Ventasdetalles.FindAsync(id);
            if (ventasdetalle == null)
            {
                return NotFound();
            }
            ViewData["VentasIdVenta"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta", ventasdetalle.VentasIdVenta);
            return View(ventasdetalle);
        }

        // POST: Ventasdetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("IdVentaDetalle,IdVenta,IdProducto,PrecioVentaUnitario,Cantidad,ImporteTotalVenta,VentasIdVenta,VentasClientesIdCliente,ProductosIdProducto,ProductosUnidadesMedidasIdUnidadMedida,ProductosProveedoresIdProveedor")] Ventasdetalle ventasdetalle)
        {
            if (id != ventasdetalle.IdVentaDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventasdetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasdetalleExists(ventasdetalle.IdVentaDetalle))
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
            ViewData["VentasIdVenta"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta", ventasdetalle.VentasIdVenta);
            return View(ventasdetalle);
        }

        // GET: Ventasdetalles/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventasdetalle = await _context.Ventasdetalles
                .Include(v => v.VentasIdVentaNavigation)
                .FirstOrDefaultAsync(m => m.IdVentaDetalle == id);
            if (ventasdetalle == null)
            {
                return NotFound();
            }

            return View(ventasdetalle);
        }

        // POST: Ventasdetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            var ventasdetalle = await _context.Ventasdetalles.FindAsync(id);
            if (ventasdetalle != null)
            {
                _context.Ventasdetalles.Remove(ventasdetalle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentasdetalleExists(ulong id)
        {
            return _context.Ventasdetalles.Any(e => e.IdVentaDetalle == id);
        }
    }
}
