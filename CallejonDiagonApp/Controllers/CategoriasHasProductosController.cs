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
    public class CategoriasHasProductosController : Controller
    {
        private readonly CallejondiagonContext _context;

        public CategoriasHasProductosController(CallejondiagonContext context)
        {
            _context = context;
        }

        // GET: CategoriasHasProductos
        public async Task<IActionResult> Index()
        {
            var callejondiagonContext = _context.CategoriasHasProductos.Include(c => c.CategoriasIdCategoriaNavigation);
            return View(await callejondiagonContext.ToListAsync());
        }

        // GET: CategoriasHasProductos/Details/5
        public async Task<IActionResult> Details(sbyte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriasHasProducto = await _context.CategoriasHasProductos
                .Include(c => c.CategoriasIdCategoriaNavigation)
                .FirstOrDefaultAsync(m => m.CategoriasIdCategoria == id);
            if (categoriasHasProducto == null)
            {
                return NotFound();
            }

            return View(categoriasHasProducto);
        }

        // GET: CategoriasHasProductos/Create
        public IActionResult Create()
        {
            ViewData["CategoriasIdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria");
            return View();
        }

        // POST: CategoriasHasProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriasIdCategoria,ProductosIdProducto")] CategoriasHasProducto categoriasHasProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriasHasProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriasIdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria", categoriasHasProducto.CategoriasIdCategoria);
            return View(categoriasHasProducto);
        }

        // GET: CategoriasHasProductos/Edit/5
        public async Task<IActionResult> Edit(sbyte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriasHasProducto = await _context.CategoriasHasProductos.FindAsync(id);
            if (categoriasHasProducto == null)
            {
                return NotFound();
            }
            ViewData["CategoriasIdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria", categoriasHasProducto.CategoriasIdCategoria);
            return View(categoriasHasProducto);
        }

        // POST: CategoriasHasProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(sbyte id, [Bind("CategoriasIdCategoria,ProductosIdProducto")] CategoriasHasProducto categoriasHasProducto)
        {
            if (id != categoriasHasProducto.CategoriasIdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriasHasProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriasHasProductoExists(categoriasHasProducto.CategoriasIdCategoria))
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
            ViewData["CategoriasIdCategoria"] = new SelectList(_context.Categorias, "IdCategoria", "IdCategoria", categoriasHasProducto.CategoriasIdCategoria);
            return View(categoriasHasProducto);
        }

        // GET: CategoriasHasProductos/Delete/5
        public async Task<IActionResult> Delete(sbyte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriasHasProducto = await _context.CategoriasHasProductos
                .Include(c => c.CategoriasIdCategoriaNavigation)
                .FirstOrDefaultAsync(m => m.CategoriasIdCategoria == id);
            if (categoriasHasProducto == null)
            {
                return NotFound();
            }

            return View(categoriasHasProducto);
        }

        // POST: CategoriasHasProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(sbyte id)
        {
            var categoriasHasProducto = await _context.CategoriasHasProductos.FindAsync(id);
            if (categoriasHasProducto != null)
            {
                _context.CategoriasHasProductos.Remove(categoriasHasProducto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriasHasProductoExists(sbyte id)
        {
            return _context.CategoriasHasProductos.Any(e => e.CategoriasIdCategoria == id);
        }
    }
}
