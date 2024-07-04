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
    public class HorariostrabajoController : Controller
    {
        private readonly CallejondiagonContext _context;

        public HorariostrabajoController(CallejondiagonContext context)
        {
            _context = context;
        }

        // GET: Horariostrabajo
        public async Task<IActionResult> Index()
        {
            var callejondiagonContext = _context.Horariostrabajos.Include(h => h.IdEmpleadoNavigation);
            return View(await callejondiagonContext.ToListAsync());
        }

        // GET: Horariostrabajo/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horariostrabajo = await _context.Horariostrabajos
                .Include(h => h.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdHorarioTrabajo == id);
            if (horariostrabajo == null)
            {
                return NotFound();
            }

            return View(horariostrabajo);
        }

        // GET: Horariostrabajo/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado");
            return View();
        }

        // POST: Horariostrabajo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHorarioTrabajo,DescripcionHorario,IdEmpleado")] Horariostrabajo horariostrabajo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horariostrabajo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", horariostrabajo.IdEmpleado);
            return View(horariostrabajo);
        }

        // GET: Horariostrabajo/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horariostrabajo = await _context.Horariostrabajos.FindAsync(id);
            if (horariostrabajo == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", horariostrabajo.IdEmpleado);
            return View(horariostrabajo);
        }

        // POST: Horariostrabajo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("IdHorarioTrabajo,DescripcionHorario,IdEmpleado")] Horariostrabajo horariostrabajo)
        {
            if (id != horariostrabajo.IdHorarioTrabajo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horariostrabajo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorariostrabajoExists(horariostrabajo.IdHorarioTrabajo))
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
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", horariostrabajo.IdEmpleado);
            return View(horariostrabajo);
        }

        // GET: Horariostrabajo/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var horariostrabajo = await _context.Horariostrabajos
                .Include(h => h.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdHorarioTrabajo == id);
            if (horariostrabajo == null)
            {
                return NotFound();
            }

            return View(horariostrabajo);
        }

        // POST: Horariostrabajo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var horariostrabajo = await _context.Horariostrabajos.FindAsync(id);
            if (horariostrabajo != null)
            {
                _context.Horariostrabajos.Remove(horariostrabajo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorariostrabajoExists(byte id)
        {
            return _context.Horariostrabajos.Any(e => e.IdHorarioTrabajo == id);
        }
    }
}
