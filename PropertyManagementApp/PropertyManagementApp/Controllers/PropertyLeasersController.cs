using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PropertyManagementApp.Models;

namespace PropertyManagementApp.Controllers
{
    public class PropertyLeasersController : Controller
    {
        private readonly PropertyManagementContext _context;

        public PropertyLeasersController(PropertyManagementContext context)
        {
            _context = context;
        }

        // GET: PropertyLeasers
        public async Task<IActionResult> Index()
        {
            return View(await _context.PropertyLeaser.ToListAsync());
        }

        // GET: PropertyLeasers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyLeaser = await _context.PropertyLeaser
                .FirstOrDefaultAsync(m => m.LeaserId == id);
            if (propertyLeaser == null)
            {
                return NotFound();
            }

            return View(propertyLeaser);
        }

        // GET: PropertyLeasers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropertyLeasers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaserId,FirstName,LastName,Email,Address,City,State,ZipCode,Comments,PhoneNumber")] PropertyLeaser propertyLeaser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propertyLeaser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propertyLeaser);
        }

        // GET: PropertyLeasers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyLeaser = await _context.PropertyLeaser.FindAsync(id);
            if (propertyLeaser == null)
            {
                return NotFound();
            }
            return View(propertyLeaser);
        }

        // POST: PropertyLeasers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaserId,FirstName,LastName,Email,Address,City,State,ZipCode,Comments,PhoneNumber")] PropertyLeaser propertyLeaser)
        {
            if (id != propertyLeaser.LeaserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyLeaser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyLeaserExists(propertyLeaser.LeaserId))
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
            return View(propertyLeaser);
        }

        // GET: PropertyLeasers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyLeaser = await _context.PropertyLeaser
                .FirstOrDefaultAsync(m => m.LeaserId == id);
            if (propertyLeaser == null)
            {
                return NotFound();
            }

            return View(propertyLeaser);
        }

        // POST: PropertyLeasers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyLeaser = await _context.PropertyLeaser.FindAsync(id);
            _context.PropertyLeaser.Remove(propertyLeaser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyLeaserExists(int id)
        {
            return _context.PropertyLeaser.Any(e => e.LeaserId == id);
        }
    }
}
