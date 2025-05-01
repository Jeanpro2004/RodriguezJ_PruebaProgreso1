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
    public class DuenoMascotasController : Controller
    {
        private readonly DataBaseContext _context;

        public DuenoMascotasController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: DuenoMascotas
        public async Task<IActionResult> Index()
        {
            return View(await _context.DuenoMascota.ToListAsync());
        }

        // GET: DuenoMascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duenoMascota = await _context.DuenoMascota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duenoMascota == null)
            {
                return NotFound();
            }

            return View(duenoMascota);
        }

        // GET: DuenoMascotas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DuenoMascotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Edad,Email,SaldoDisponible,TieneMembresia,FechaRegistro")] DuenoMascota duenoMascota)
        {
            if (ModelState.IsValid)
            {
                _context.Add(duenoMascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(duenoMascota);
        }

        // GET: DuenoMascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duenoMascota = await _context.DuenoMascota.FindAsync(id);
            if (duenoMascota == null)
            {
                return NotFound();
            }
            return View(duenoMascota);
        }

        // POST: DuenoMascotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Edad,Email,SaldoDisponible,TieneMembresia,FechaRegistro")] DuenoMascota duenoMascota)
        {
            if (id != duenoMascota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(duenoMascota);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DuenoMascotaExists(duenoMascota.Id))
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
            return View(duenoMascota);
        }

        // GET: DuenoMascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var duenoMascota = await _context.DuenoMascota
                .FirstOrDefaultAsync(m => m.Id == id);
            if (duenoMascota == null)
            {
                return NotFound();
            }

            return View(duenoMascota);
        }

        // POST: DuenoMascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var duenoMascota = await _context.DuenoMascota.FindAsync(id);
            if (duenoMascota != null)
            {
                _context.DuenoMascota.Remove(duenoMascota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DuenoMascotaExists(int id)
        {
            return _context.DuenoMascota.Any(e => e.Id == id);
        }
    }
}
