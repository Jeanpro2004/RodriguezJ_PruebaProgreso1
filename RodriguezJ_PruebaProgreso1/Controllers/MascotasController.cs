using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RodriguezJ_PruebaProgreso1.Models;

namespace RodriguezJ_PruebaProgreso1.Controllers
{
    public class MascotasController : Controller
    {
        private readonly DataBaseContext _context;

        public MascotasController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: Mascotas
        public async Task<IActionResult> Index()
        {
            var dataBaseContext = _context.Mascota.Include(m => m.Dueno);
            return View(await dataBaseContext.ToListAsync());
        }

        // GET: Mascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascota
                .Include(m => m.Dueno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        // GET: Mascotas/Create
        public IActionResult Create()
        {
            // Usar Nombre en lugar de Id para la visualización en el dropdown
            ViewData["DuenoMascotaId"] = new SelectList(_context.DuenoMascota, "Id", "Nombre");
            return View();
        }

        // POST: Mascotas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Raza,Especie,Edad,PesoKg,DuenoMascotaId")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(mascota);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception or inspect it for debugging
                    ModelState.AddModelError("", "Error al guardar: " + ex.Message);
                }
            }
            // Si hay errores, volver a cargar el dropdown
            ViewData["DuenoMascotaId"] = new SelectList(_context.DuenoMascota, "Id", "Nombre", mascota.DuenoMascotaId);
            return View(mascota);
        }

        // GET: Mascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascota.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }
            // Usar Nombre en lugar de Id para la visualización en el dropdown
            ViewData["DuenoMascotaId"] = new SelectList(_context.DuenoMascota, "Id", "Nombre", mascota.DuenoMascotaId);
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Raza,Especie,Edad,PesoKg,DuenoMascotaId")] Mascota mascota)
        {
            if (id != mascota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mascota);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotaExists(mascota.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or inspect it for debugging
                    ModelState.AddModelError("", "Error al guardar: " + ex.Message);
                }
            }
            // Usar Nombre en lugar de Id para la visualización en el dropdown
            ViewData["DuenoMascotaId"] = new SelectList(_context.DuenoMascota, "Id", "Nombre", mascota.DuenoMascotaId);
            return View(mascota);
        }

        // GET: Mascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascota
                .Include(m => m.Dueno)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascota = await _context.Mascota.FindAsync(id);
            if (mascota != null)
            {
                _context.Mascota.Remove(mascota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MascotaExists(int id)
        {
            return _context.Mascota.Any(e => e.Id == id);
        }
    }
}