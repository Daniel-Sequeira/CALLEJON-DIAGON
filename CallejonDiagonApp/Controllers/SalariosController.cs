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
    public class SalariosController : Controller
    {
        private readonly CallejondiagonContext _context;

        public SalariosController(CallejondiagonContext context)
        {
            _context = context;
        }

        // GET: Salarios
        public async Task<IActionResult> Index()
        {
            var callejondiagonContext = _context.Salarios.Include(s => s.IdEmpleadoNavigation);
            return View(await callejondiagonContext.ToListAsync());
        }

        // GET: Salarios/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salario = await _context.Salarios
                .Include(s => s.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdSalario == id);
            if (salario == null)
            {
                return NotFound();
            }

            return View(salario);
        }

        // GET: Salarios/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado");
            return View();
        }

        // POST: Salarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSalario,SalarioBase,ValorHora,ValorHoraExtra,IdEmpleado")] Salario salario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", salario.IdEmpleado);
            return View(salario);
        }

        // GET: Salarios/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salario = await _context.Salarios.FindAsync(id);
            if (salario == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", salario.IdEmpleado);
            return View(salario);
        }

        // POST: Salarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("IdSalario,SalarioBase,ValorHora,ValorHoraExtra,IdEmpleado")] Salario salario)
        {
            if (id != salario.IdSalario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalarioExists(salario.IdSalario))
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
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", salario.IdEmpleado);
            return View(salario);
        }

        // GET: Salarios/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salario = await _context.Salarios
                .Include(s => s.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdSalario == id);
            if (salario == null)
            {
                return NotFound();
            }

            return View(salario);
        }

        // POST: Salarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var salario = await _context.Salarios.FindAsync(id);
            if (salario != null)
            {
                _context.Salarios.Remove(salario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalarioExists(byte id)
        {
            return _context.Salarios.Any(e => e.IdSalario == id);
        }
    }
}
