using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthPlus.Data;
using HealthPlus.Models;

namespace HealthPlus.Controllers
{
    public class TrainingsController : Controller
    {
        private readonly HealthPlusUsersContext _context;

        public TrainingsController(HealthPlusUsersContext context)
        {
            _context = context;
        }

        // GET: Trainings
        public async Task<IActionResult> Index()
        {
              return _context.Trainings != null ? 
                          View(await _context.Trainings.ToListAsync()) :
                          Problem("Entity set 'HealthPlusUsersContext.Trainings' is null.");
        }

        // GET: Trainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trainings == null)
            {
                return NotFound();
            }

            var trainings = await _context.Trainings
                .FirstOrDefaultAsync(m => m.Id_training == id);
            if (trainings == null)
            {
                return NotFound();
            }

            return View(trainings);
        }

        // GET: Trainings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_training,training_name,exercise_list")] Trainings trainings)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainings);
        }

        // GET: Trainings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trainings == null)
            {
                return NotFound();
            }

            var trainings = await _context.Trainings.FindAsync(id);
            if (trainings == null)
            {
                return NotFound();
            }
            return View(trainings);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_training,training_name,exercise_list")] Trainings trainings)
        {
            if (id != trainings.Id_training)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingsExists(trainings.Id_training))
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
            return View(trainings);
        }

        // GET: Trainings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trainings == null)
            {
                return NotFound();
            }

            var trainings = await _context.Trainings
                .FirstOrDefaultAsync(m => m.Id_training == id);
            if (trainings == null)
            {
                return NotFound();
            }

            return View(trainings);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trainings == null)
            {
                return Problem("Entity set 'HealthPlusUsersContext.Trainings'  is null.");
            }
            var trainings = await _context.Trainings.FindAsync(id);
            if (trainings != null)
            {
                _context.Trainings.Remove(trainings);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingsExists(int id)
        {
          return (_context.Trainings?.Any(e => e.Id_training == id)).GetValueOrDefault();
        }
    }
}
