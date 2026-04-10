using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Company.Data.Data;

namespace Bank.Intranet.Controllers
{
    public class PolicyPageSectionController : Controller
    {
        private readonly BankContext _context;

        public PolicyPageSectionController(BankContext context)
        {
            _context = context;
        }

        // GET: PolicyPageSection
        public async Task<IActionResult> Index()
        {
            return View(await _context.PolicyPageSection.ToListAsync());
        }

        // GET: PolicyPageSection/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policyPageSection = await _context.PolicyPageSection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policyPageSection == null)
            {
                return NotFound();
            }

            return View(policyPageSection);
        }

        // GET: PolicyPageSection/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PolicyPageSection/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SectionName,Content,ImageUrl,IconClass,Order,IsActive")] PolicyPageSection policyPageSection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(policyPageSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(policyPageSection);
        }

        // GET: PolicyPageSection/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policyPageSection = await _context.PolicyPageSection.FindAsync(id);
            if (policyPageSection == null)
            {
                return NotFound();
            }
            return View(policyPageSection);
        }

        // POST: PolicyPageSection/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SectionName,Content,ImageUrl,IconClass,Order,IsActive")] PolicyPageSection policyPageSection)
        {
            if (id != policyPageSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(policyPageSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PolicyPageSectionExists(policyPageSection.Id))
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
            return View(policyPageSection);
        }

        // GET: PolicyPageSection/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var policyPageSection = await _context.PolicyPageSection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (policyPageSection == null)
            {
                return NotFound();
            }

            return View(policyPageSection);
        }

        // POST: PolicyPageSection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var policyPageSection = await _context.PolicyPageSection.FindAsync(id);
            if (policyPageSection != null)
            {
                _context.PolicyPageSection.Remove(policyPageSection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PolicyPageSectionExists(int id)
        {
            return _context.PolicyPageSection.Any(e => e.Id == id);
        }
    }
}
