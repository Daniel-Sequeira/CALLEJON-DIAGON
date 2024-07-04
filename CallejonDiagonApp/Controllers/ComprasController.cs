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
    public class ComprasController : Controller
    {
        private readonly CallejondiagonContext _context;

        public ComprasController(CallejondiagonContext context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index()
        {
            var callejondiagonContext = _context.Compras.Include(c => c.IdEmpleadoNavigation).Include(c => c.IdMetodoPagoNavigation).Include(c => c.ProveedoresIdProveedorNavigation);
            return View(await callejondiagonContext.ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.IdEmpleadoNavigation)
                .Include(c => c.IdMetodoPagoNavigation)
                .Include(c => c.ProveedoresIdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado");
            ViewData["IdMetodoPago"] = new SelectList(_context.Metodopagos, "IdMetodoPago", "IdMetodoPago");
            ViewData["ProveedoresIdProveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "IdProveedor");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompra,IdProveedor,FechaCompra,SubtotalCompra,Iva,ImporteTotalCompra,IdEmpleado,CompraStatus,ProveedoresIdProveedor,IdMetodoPago")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", compra.IdEmpleado);
            ViewData["IdMetodoPago"] = new SelectList(_context.Metodopagos, "IdMetodoPago", "IdMetodoPago", compra.IdMetodoPago);
            ViewData["ProveedoresIdProveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "IdProveedor", compra.ProveedoresIdProveedor);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", compra.IdEmpleado);
            ViewData["IdMetodoPago"] = new SelectList(_context.Metodopagos, "IdMetodoPago", "IdMetodoPago", compra.IdMetodoPago);
            ViewData["ProveedoresIdProveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "IdProveedor", compra.ProveedoresIdProveedor);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("IdCompra,IdProveedor,FechaCompra,SubtotalCompra,Iva,ImporteTotalCompra,IdEmpleado,CompraStatus,ProveedoresIdProveedor,IdMetodoPago")] Compra compra)
        {
            if (id != compra.IdCompra)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.IdCompra))
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
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", compra.IdEmpleado);
            ViewData["IdMetodoPago"] = new SelectList(_context.Metodopagos, "IdMetodoPago", "IdMetodoPago", compra.IdMetodoPago);
            ViewData["ProveedoresIdProveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "IdProveedor", compra.ProveedoresIdProveedor);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.IdEmpleadoNavigation)
                .Include(c => c.IdMetodoPagoNavigation)
                .Include(c => c.ProveedoresIdProveedorNavigation)
                .FirstOrDefaultAsync(m => m.IdCompra == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            var compra = await _context.Compras.FindAsync(id);
            if (compra != null)
            {
                _context.Compras.Remove(compra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(ulong id)
        {
            return _context.Compras.Any(e => e.IdCompra == id);
        }
    }
}
