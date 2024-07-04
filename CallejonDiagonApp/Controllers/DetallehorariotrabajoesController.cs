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
    public class DetallehorariotrabajoesController : Controller
    {
        private readonly CallejondiagonContext _context;

        public DetallehorariotrabajoesController(CallejondiagonContext context)
        {
            _context = context;
        }

        // GET: Detallehorariotrabajoes
        public async Task<IActionResult> Index()
        {
            var callejondiagonContext = _context.Detallehorariotrabajos.Include(d => d.IdHorarioTrabajoNavigation);
            return View(await callejondiagonContext.ToListAsync());
        }

        // GET: Detallehorariotrabajoes/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallehorariotrabajo = await _context.Detallehorariotrabajos
                .Include(d => d.IdHorarioTrabajoNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleHorarioT == id);
            if (detallehorariotrabajo == null)
            {
                return NotFound();
            }

            return View(detallehorariotrabajo);
        }

        // GET: Detallehorariotrabajoes/Create
        public IActionResult Create()
        {
            ViewData["IdHorarioTrabajo"] = new SelectList(_context.Horariostrabajos, "IdHorarioTrabajo", "IdHorarioTrabajo");
            return View();
        }

        // POST: Detallehorariotrabajoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleHorarioT,Fecha,HoraEntada,HoraSalida,CantidadHoras,IdHorarioTrabajo")] Detallehorariotrabajo detallehorariotrabajo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallehorariotrabajo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdHorarioTrabajo"] = new SelectList(_context.Horariostrabajos, "IdHorarioTrabajo", "IdHorarioTrabajo", detallehorariotrabajo.IdHorarioTrabajo);
            return View(detallehorariotrabajo);
        }

        // GET: Detallehorariotrabajoes/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallehorariotrabajo = await _context.Detallehorariotrabajos.FindAsync(id);
            if (detallehorariotrabajo == null)
            {
                return NotFound();
            }
            ViewData["IdHorarioTrabajo"] = new SelectList(_context.Horariostrabajos, "IdHorarioTrabajo", "IdHorarioTrabajo", detallehorariotrabajo.IdHorarioTrabajo);
            return View(detallehorariotrabajo);
        }

        // POST: Detallehorariotrabajoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("IdDetalleHorarioT,Fecha,HoraEntada,HoraSalida,CantidadHoras,IdHorarioTrabajo")] Detallehorariotrabajo detallehorariotrabajo)
        {
            if (id != detallehorariotrabajo.IdDetalleHorarioT)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallehorariotrabajo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallehorariotrabajoExists(detallehorariotrabajo.IdDetalleHorarioT))
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
            ViewData["IdHorarioTrabajo"] = new SelectList(_context.Horariostrabajos, "IdHorarioTrabajo", "IdHorarioTrabajo", detallehorariotrabajo.IdHorarioTrabajo);
            return View(detallehorariotrabajo);
        }

        // GET: Detallehorariotrabajoes/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallehorariotrabajo = await _context.Detallehorariotrabajos
                .Include(d => d.IdHorarioTrabajoNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleHorarioT == id);
            if (detallehorariotrabajo == null)
            {
                return NotFound();
            }

            return View(detallehorariotrabajo);
        }

        // POST: Detallehorariotrabajoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            var detallehorariotrabajo = await _context.Detallehorariotrabajos.FindAsync(id);
            if (detallehorariotrabajo != null)
            {
                _context.Detallehorariotrabajos.Remove(detallehorariotrabajo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallehorariotrabajoExists(ulong id)
        {
            return _context.Detallehorariotrabajos.Any(e => e.IdDetalleHorarioT == id);
        }
    }
}
