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
    public class VentasController : Controller
    {
        private readonly CallejondiagonContext _context;

        public VentasController(CallejondiagonContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var callejondiagonContext = _context.Ventas.Include(v => v.ClientesIdClienteNavigation).Include(v => v.IdEmpleadoNavigation).Include(v => v.IdMetodoPagoNavigation);
            return View(await callejondiagonContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.ClientesIdClienteNavigation)
                .Include(v => v.IdEmpleadoNavigation)
                .Include(v => v.IdMetodoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["ClientesIdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado");
            ViewData["IdMetodoPago"] = new SelectList(_context.Metodopagos, "IdMetodoPago", "IdMetodoPago");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenta,IdCliente,IdMetodoPago,FechaVenta,SubttotalVenta,Iva,ImporteTotalVenta,IdEmpleado,VentaStatus,ClientesIdCliente")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientesIdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", venta.ClientesIdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", venta.IdEmpleado);
            ViewData["IdMetodoPago"] = new SelectList(_context.Metodopagos, "IdMetodoPago", "IdMetodoPago", venta.IdMetodoPago);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["ClientesIdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", venta.ClientesIdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", venta.IdEmpleado);
            ViewData["IdMetodoPago"] = new SelectList(_context.Metodopagos, "IdMetodoPago", "IdMetodoPago", venta.IdMetodoPago);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("IdVenta,IdCliente,IdMetodoPago,FechaVenta,SubttotalVenta,Iva,ImporteTotalVenta,IdEmpleado,VentaStatus,ClientesIdCliente")] Venta venta)
        {
            if (id != venta.IdVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.IdVenta))
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
            ViewData["ClientesIdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", venta.ClientesIdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", venta.IdEmpleado);
            ViewData["IdMetodoPago"] = new SelectList(_context.Metodopagos, "IdMetodoPago", "IdMetodoPago", venta.IdMetodoPago);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.ClientesIdClienteNavigation)
                .Include(v => v.IdEmpleadoNavigation)
                .Include(v => v.IdMetodoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdVenta == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(ulong id)
        {
            return _context.Ventas.Any(e => e.IdVenta == id);
        }
    }
}
