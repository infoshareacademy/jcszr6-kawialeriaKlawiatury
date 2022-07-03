using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FoodTrakkerWebAplication.Data;
using FoodTrakker_WebBusinessLogic.Model;

namespace FoodTrakkerWebAplication.Controllers
{
    public class FoodTrucksController : Controller
    {
        private readonly FoodTrakkerWebAplicationContext _context;

        public FoodTrucksController(FoodTrakkerWebAplicationContext context)
        {
            _context = context;
        }

        // GET: FoodTrucks
        public async Task<IActionResult> Index()
        {
              return _context.FoodTruck != null ? 
                          View(await _context.FoodTruck.ToListAsync()) :
                          Problem("Entity set 'FoodTrakkerWebAplicationContext.FoodTruck'  is null.");
        }

        // GET: FoodTrucks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FoodTruck == null)
            {
                return NotFound();
            }

            var foodTruck = await _context.FoodTruck
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodTruck == null)
            {
                return NotFound();
            }

            return View(foodTruck);
        }

        // GET: FoodTrucks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodTrucks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,OwnerId")] FoodTruck foodTruck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodTruck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodTruck);
        }

        // GET: FoodTrucks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FoodTruck == null)
            {
                return NotFound();
            }

            var foodTruck = await _context.FoodTruck.FindAsync(id);
            if (foodTruck == null)
            {
                return NotFound();
            }
            return View(foodTruck);
        }

        // POST: FoodTrucks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,OwnerId")] FoodTruck foodTruck)
        {
            if (id != foodTruck.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodTruck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodTruckExists(foodTruck.Id))
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
            return View(foodTruck);
        }

        // GET: FoodTrucks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FoodTruck == null)
            {
                return NotFound();
            }

            var foodTruck = await _context.FoodTruck
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foodTruck == null)
            {
                return NotFound();
            }

            return View(foodTruck);
        }

        // POST: FoodTrucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FoodTruck == null)
            {
                return Problem("Entity set 'FoodTrakkerWebAplicationContext.FoodTruck'  is null.");
            }
            var foodTruck = await _context.FoodTruck.FindAsync(id);
            if (foodTruck != null)
            {
                _context.FoodTruck.Remove(foodTruck);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodTruckExists(int id)
        {
          return (_context.FoodTruck?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
