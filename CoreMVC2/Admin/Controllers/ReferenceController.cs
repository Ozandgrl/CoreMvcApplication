using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreMVC2.Admin.Models.DbLayer;
using CoreMVC2.Admin.Models.Entities;

namespace CoreMVC2.Admin.Controllers
{
    public class ReferenceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReferenceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reference
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reference.ToListAsync());
        }

        // GET: Reference/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.Reference
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // GET: Reference/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reference/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerName,ImagePath,Id,IsActive,CreatedUserId,CreatedDate,UpdatedUserId,UpdatedDate")] Reference reference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reference);
        }

        // GET: Reference/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.Reference.FindAsync(id);
            if (reference == null)
            {
                return NotFound();
            }
            return View(reference);
        }

        // POST: Reference/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerName,ImagePath,Id,IsActive,CreatedUserId,CreatedDate,UpdatedUserId,UpdatedDate")] Reference reference)
        {
            if (id != reference.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReferenceExists(reference.Id))
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
            return View(reference);
        }

        // GET: Reference/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reference = await _context.Reference
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reference == null)
            {
                return NotFound();
            }

            return View(reference);
        }

        // POST: Reference/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reference = await _context.Reference.FindAsync(id);
            _context.Reference.Remove(reference);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReferenceExists(int id)
        {
            return _context.Reference.Any(e => e.Id == id);
        }
    }
}
