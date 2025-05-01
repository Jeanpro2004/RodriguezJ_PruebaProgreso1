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
    public class VisitaVeterinariasController : Controller
    {
        private readonly DataBaseContext _context;

        public VisitaVeterinariasController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: VisitaVeterinarias
        public async Task<IActionResult> Index()
        {
            var dataBaseContext = _context.VisitaVeterinaria.Include(v => v.Mascota);
            return View(await dataBaseContext.ToListAsync());
        }

        // GET: VisitaVeterinarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitaVeterinaria = await _context.VisitaVeterinaria
                .Include(v => v.Mascota)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitaVeterinaria == null)
            {
                return NotFound();
            }

            return View(visitaVeterinaria);
        }

        // GET: VisitaVeterinarias/Create
        public IActionResult Create()
        {
            ViewData["MascotaId"] = new SelectList(_context.Mascota, "Id", "Id");
            return View();
        }

        // POST: VisitaVeterinarias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaVisita,Motivo,Tarifa,RequiereMedicacion,MascotaId")] VisitaVeterinaria visitaVeterinaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitaVeterinaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MascotaId"] = new SelectList(_context.Mascota, "Id", "Id", visitaVeterinaria.MascotaId);
            return View(visitaVeterinaria);
        }

        // GET: VisitaVeterinarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitaVeterinaria = await _context.VisitaVeterinaria.FindAsync(id);
            if (visitaVeterinaria == null)
            {
                return NotFound();
            }
            ViewData["MascotaId"] = new SelectList(_context.Mascota, "Id", "Id", visitaVeterinaria.MascotaId);
            return View(visitaVeterinaria);
        }

        // POST: VisitaVeterinarias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaVisita,Motivo,Tarifa,RequiereMedicacion,MascotaId")] VisitaVeterinaria visitaVeterinaria)
        {
            if (id != visitaVeterinaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitaVeterinaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitaVeterinariaExists(visitaVeterinaria.Id))
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
            ViewData["MascotaId"] = new SelectList(_context.Mascota, "Id", "Id", visitaVeterinaria.MascotaId);
            return View(visitaVeterinaria);
        }

        // GET: VisitaVeterinarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitaVeterinaria = await _context.VisitaVeterinaria
                .Include(v => v.Mascota)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitaVeterinaria == null)
            {
                return NotFound();
            }

            return View(visitaVeterinaria);
        }

        // POST: VisitaVeterinarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitaVeterinaria = await _context.VisitaVeterinaria.FindAsync(id);
            if (visitaVeterinaria != null)
            {
                _context.VisitaVeterinaria.Remove(visitaVeterinaria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitaVeterinariaExists(int id)
        {
            return _context.VisitaVeterinaria.Any(e => e.Id == id);
        }
    }
}
