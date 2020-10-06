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
    public class PropertyOwnersController : Controller
    {
        private readonly PropertyManagementContext _context;

        public PropertyOwnersController(PropertyManagementContext context)
        {
            _context = context;
        }

        // GET: PropertyOwners
        public async Task<IActionResult> Index()
        {
            return View(await _context.PropertyOwner.ToListAsync());
        }

        // GET: PropertyOwners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyOwner = await _context.PropertyOwner
                .FirstOrDefaultAsync(m => m.OwnerId == id);
            if (propertyOwner == null)
            {
                return NotFound();
            }

            return View(propertyOwner);
        }

        // GET: PropertyOwners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PropertyOwners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OwnerId,FirstName,LastName,Email,Address,City,State,ZipCode,Comments")] PropertyOwner propertyOwner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propertyOwner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propertyOwner);
        }

        // GET: PropertyOwners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyOwner = await _context.PropertyOwner.FindAsync(id);
            if (propertyOwner == null)
            {
                return NotFound();
            }
            return View(propertyOwner);
        }

        // POST: PropertyOwners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OwnerId,FirstName,LastName,Email,Address,City,State,ZipCode,Comments")] PropertyOwner propertyOwner)
        {
            if (id != propertyOwner.OwnerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propertyOwner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyOwnerExists(propertyOwner.OwnerId))
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
            return View(propertyOwner);
        }

        // GET: PropertyOwners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propertyOwner = await _context.PropertyOwner
                .FirstOrDefaultAsync(m => m.OwnerId == id);
            if (propertyOwner == null)
            {
                return NotFound();
            }

            return View(propertyOwner);
        }

        // POST: PropertyOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propertyOwner = await _context.PropertyOwner.FindAsync(id);
            _context.PropertyOwner.Remove(propertyOwner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyOwnerExists(int id)
        {
            return _context.PropertyOwner.Any(e => e.OwnerId == id);
        }
    }
}
