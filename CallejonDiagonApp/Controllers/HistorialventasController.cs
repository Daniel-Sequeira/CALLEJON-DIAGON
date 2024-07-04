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
    public class HistorialventasController : Controller
    {
        private readonly CallejondiagonContext _context;

        public HistorialventasController(CallejondiagonContext context)
        {
            _context = context;
        }

        // GET: Historialventas
        public async Task<IActionResult> Index()
        {
            var callejondiagonContext = _context.Historialventas.Include(h => h.IdClienteNavigation).Include(h => h.IdEmpleadoNavigation).Include(h => h.IdMetodoPagoNavigation);
            return View(await callejondiagonContext.ToListAsync());
        }

        // GET: Historialventas/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialventa = await _context.Historialventas
                .Include(h => h.IdClienteNavigation)
                .Include(h => h.IdEmpleadoNavigation)
                .Include(h => h.IdMetodoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdHistorialVentas == id);
            if (historialventa == null)
            {
                return NotFound();
            }

            return View(historialventa);
        }

        // GET: Historialventas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado");
            ViewData["IdMetodoPago"] = new SelectList(_context.Metodopagos, "IdMetodoPago", "IdMetodoPago");
            return View();
        }

        // POST: Historialventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHistorialVentas,FechaVenta,IdEmpleado,IdCliente,IdProducto,IdMetodoPago,TotalVenta")] Historialventa historialventa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historialventa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", historialventa.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", historialventa.IdEmpleado);
            ViewData["IdMetodoPago"] = new SelectList(_context.Metodopagos, "IdMetodoPago", "IdMetodoPago", historialventa.IdMetodoPago);
            return View(historialventa);
        }

        // GET: Historialventas/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialventa = await _context.Historialventas.FindAsync(id);
            if (historialventa == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", historialventa.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", historialventa.IdEmpleado);
            ViewData["IdMetodoPago"] = new SelectList(_context.Metodopagos, "IdMetodoPago", "IdMetodoPago", historialventa.IdMetodoPago);
            return View(historialventa);
        }

        // POST: Historialventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("IdHistorialVentas,FechaVenta,IdEmpleado,IdCliente,IdProducto,IdMetodoPago,TotalVenta")] Historialventa historialventa)
        {
            if (id != historialventa.IdHistorialVentas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historialventa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialventaExists(historialventa.IdHistorialVentas))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", historialventa.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", historialventa.IdEmpleado);
            ViewData["IdMetodoPago"] = new SelectList(_context.Metodopagos, "IdMetodoPago", "IdMetodoPago", historialventa.IdMetodoPago);
            return View(historialventa);
        }

        // GET: Historialventas/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialventa = await _context.Historialventas
                .Include(h => h.IdClienteNavigation)
                .Include(h => h.IdEmpleadoNavigation)
                .Include(h => h.IdMetodoPagoNavigation)
                .FirstOrDefaultAsync(m => m.IdHistorialVentas == id);
            if (historialventa == null)
            {
                return NotFound();
            }

            return View(historialventa);
        }

        // POST: Historialventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            var historialventa = await _context.Historialventas.FindAsync(id);
            if (historialventa != null)
            {
                _context.Historialventas.Remove(historialventa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialventaExists(ulong id)
        {
            return _context.Historialventas.Any(e => e.IdHistorialVentas == id);
        }
    }
}
