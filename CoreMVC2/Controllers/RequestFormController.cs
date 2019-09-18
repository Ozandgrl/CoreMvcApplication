using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreMVC2.Models.DbLayer;
using CoreMVC2.Models.Entities;

namespace CoreMVC2.Controllers
{
    public class RequestFormController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestFormController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RequestForm
        public async Task<IActionResult> Index()
        {
            return View(await _context.RequestForm.ToListAsync());
        }

        // GET: RequestForm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestForm = await _context.RequestForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestForm == null)
            {
                return NotFound();
            }

            return View(requestForm);
        }

        // GET: RequestForm/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RequestForm/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyName,CompanyRepresentative,PhoneNumber,TaxNumber,MailAddress,ProductOfInterest,Quantity,City,Explanation,Id,IsActive,CreatedUserId,CreatedDate,UpdatedUserId,UpdatedDate")] RequestForm requestForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestForm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requestForm);
        }

        // GET: RequestForm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestForm = await _context.RequestForm.FindAsync(id);
            if (requestForm == null)
            {
                return NotFound();
            }
            return View(requestForm);
        }

        // POST: RequestForm/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyName,CompanyRepresentative,PhoneNumber,TaxNumber,MailAddress,ProductOfInterest,Quantity,City,Explanation,Id,IsActive,CreatedUserId,CreatedDate,UpdatedUserId,UpdatedDate")] RequestForm requestForm)
        {
            if (id != requestForm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestFormExists(requestForm.Id))
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
            return View(requestForm);
        }

        // GET: RequestForm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requestForm = await _context.RequestForm
                .FirstOrDefaultAsync(m => m.Id == id);
            if (requestForm == null)
            {
                return NotFound();
            }

            return View(requestForm);
        }

        // POST: RequestForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requestForm = await _context.RequestForm.FindAsync(id);
            _context.RequestForm.Remove(requestForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestFormExists(int id)
        {
            return _context.RequestForm.Any(e => e.Id == id);
        }
    }
}
