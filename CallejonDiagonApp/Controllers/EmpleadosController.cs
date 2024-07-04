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
    public class EmpleadosController : Controller
    {
        private readonly CallejondiagonContext _context;

        public EmpleadosController(CallejondiagonContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var callejondiagonContext = _context.Empleados.Include(e => e.IdAreaNavigation).Include(e => e.IdRolNavigation);
            return View(await callejondiagonContext.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdAreaNavigation)
                .Include(e => e.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["IdArea"] = new SelectList(_context.Areastrabajos, "IdArea", "IdArea");
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,CedulaEmpleado,NombreEmpleado,ApellidosEmpleado,IdRol,IdArea,TelefonoEmpleado,EmailEmpleado,DireccionEmpleado,LoginUs,PasswordEmpleado,FechaNacimiento,FechaAlta,FechaBaja,EmpleadoStatus")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArea"] = new SelectList(_context.Areastrabajos, "IdArea", "IdArea", empleado.IdArea);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", empleado.IdRol);
            return View(empleado);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["IdArea"] = new SelectList(_context.Areastrabajos, "IdArea", "IdArea", empleado.IdArea);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", empleado.IdRol);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("IdEmpleado,CedulaEmpleado,NombreEmpleado,ApellidosEmpleado,IdRol,IdArea,TelefonoEmpleado,EmailEmpleado,DireccionEmpleado,LoginUs,PasswordEmpleado,FechaNacimiento,FechaAlta,FechaBaja,EmpleadoStatus")] Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.IdEmpleado))
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
            ViewData["IdArea"] = new SelectList(_context.Areastrabajos, "IdArea", "IdArea", empleado.IdArea);
            ViewData["IdRol"] = new SelectList(_context.Roles, "IdRol", "IdRol", empleado.IdRol);
            return View(empleado);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleados
                .Include(e => e.IdAreaNavigation)
                .Include(e => e.IdRolNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(uint id)
        {
            return _context.Empleados.Any(e => e.IdEmpleado == id);
        }
    }
}
