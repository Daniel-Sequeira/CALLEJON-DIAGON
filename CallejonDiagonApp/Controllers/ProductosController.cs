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
    public class ProductosController : Controller
    {
        private readonly CallejondiagonContext _context;

        public ProductosController(CallejondiagonContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var callejondiagonContext = _context.Productos.Include(p => p.IdProveedorNavigation).Include(p => p.UnidadesMedidasIdUnidadMedidaNavigation);
            return View(await callejondiagonContext.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdProveedorNavigation)
                .Include(p => p.UnidadesMedidasIdUnidadMedidaNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            ViewData["IdProveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "IdProveedor");
            ViewData["UnidadesMedidasIdUnidadMedida"] = new SelectList(_context.Unidadesmedidas, "IdUnidadMedida", "IdUnidadMedida");
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,NombreProducto,DescripcionProducto,IdProveedor,IdUnidadMedida,IdCategoria,PrecioCosto,PrecioVenta,Descuento,IdEmpleado,FechaCreacion,FechaModificacion,ProductoStatus,ImagenProducto,Existencias,UnidadesMedidasIdUnidadMedida,ProveedoresIdProveedor")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "IdProveedor", producto.IdProveedor);
            ViewData["UnidadesMedidasIdUnidadMedida"] = new SelectList(_context.Unidadesmedidas, "IdUnidadMedida", "IdUnidadMedida", producto.UnidadesMedidasIdUnidadMedida);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["IdProveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "IdProveedor", producto.IdProveedor);
            ViewData["UnidadesMedidasIdUnidadMedida"] = new SelectList(_context.Unidadesmedidas, "IdUnidadMedida", "IdUnidadMedida", producto.UnidadesMedidasIdUnidadMedida);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("IdProducto,NombreProducto,DescripcionProducto,IdProveedor,IdUnidadMedida,IdCategoria,PrecioCosto,PrecioVenta,Descuento,IdEmpleado,FechaCreacion,FechaModificacion,ProductoStatus,ImagenProducto,Existencias,UnidadesMedidasIdUnidadMedida,ProveedoresIdProveedor")] Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.IdProducto))
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
            ViewData["IdProveedor"] = new SelectList(_context.Proveedores, "IdProveedor", "IdProveedor", producto.IdProveedor);
            ViewData["UnidadesMedidasIdUnidadMedida"] = new SelectList(_context.Unidadesmedidas, "IdUnidadMedida", "IdUnidadMedida", producto.UnidadesMedidasIdUnidadMedida);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdProveedorNavigation)
                .Include(p => p.UnidadesMedidasIdUnidadMedidaNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(uint id)
        {
            return _context.Productos.Any(e => e.IdProducto == id);
        }
    }
}
