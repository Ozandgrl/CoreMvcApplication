using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreMVC2.Admin.Models.DbLayer;
using CoreMVC2.Admin.Models.Entities;

namespace CoreMVC2.Admin.Controllers
{
    public class CertificateController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CertificateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Certificate
        public async Task<IActionResult> Index()
        {
            return View(await _context.Certificate.ToListAsync());
        }

        // GET: Certificate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate = await _context.Certificate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificate == null)
            {
                return NotFound();
            }

            return View(certificate);
        }

        // GET: Certificate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Certificate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Text,ImagePath,Id,IsActive,CreatedUserId,CreatedDate,UpdatedUserId,UpdatedDate")] Certificate certificate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certificate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(certificate);
        }

        // GET: Certificate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate = await _context.Certificate.FindAsync(id);
            if (certificate == null)
            {
                return NotFound();
            }
            return View(certificate);
        }

        // POST: Certificate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Text,ImagePath,Id,IsActive,CreatedUserId,CreatedDate,UpdatedUserId,UpdatedDate")] Certificate certificate)
        {
            if (id != certificate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificateExists(certificate.Id))
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
            return View(certificate);
        }

        // GET: Certificate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificate = await _context.Certificate
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificate == null)
            {
                return NotFound();
            }

            return View(certificate);
        }

        // POST: Certificate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certificate = await _context.Certificate.FindAsync(id);
            _context.Certificate.Remove(certificate);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificateExists(int id)
        {
            return _context.Certificate.Any(e => e.Id == id);
        }
    }
}
