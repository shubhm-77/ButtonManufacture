using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ButtonManufacture.Data;
using ButtonManufacture.Models;

namespace ButtonManufacture.Controllers
{
    public class ButtonsController : Controller
    {
        private readonly ButtonManufactureContext _context;

        public ButtonsController(ButtonManufactureContext context)
        {
            _context = context;
        }

        // GET: Buttons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Button.ToListAsync());
        }

        // GET: Buttons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var button = await _context.Button
                .FirstOrDefaultAsync(m => m.Id == id);
            if (button == null)
            {
                return NotFound();
            }

            return View(button);
        }

        // GET: Buttons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buttons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,ManufacturingDate,color,Price,Quantity,Review")] Button button)
        {
            if (ModelState.IsValid)
            {
                _context.Add(button);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(button);
        }

        // GET: Buttons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var button = await _context.Button.FindAsync(id);
            if (button == null)
            {
                return NotFound();
            }
            return View(button);
        }

        // POST: Buttons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,ManufacturingDate,color,Price,Quantity,Review")] Button button)
        {
            if (id != button.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(button);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ButtonExists(button.Id))
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
            return View(button);
        }

        // GET: Buttons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var button = await _context.Button
                .FirstOrDefaultAsync(m => m.Id == id);
            if (button == null)
            {
                return NotFound();
            }

            return View(button);
        }

        // POST: Buttons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var button = await _context.Button.FindAsync(id);
            _context.Button.Remove(button);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ButtonExists(int id)
        {
            return _context.Button.Any(e => e.Id == id);
        }
    }
}
