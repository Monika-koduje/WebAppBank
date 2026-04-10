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
    public class ContactPageSectionController : Controller
    {
        private readonly BankContext _context;

        public ContactPageSectionController(BankContext context)
        {
            _context = context;
        }

        // GET: ContactPageSection
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContactPageSection.ToListAsync());
        }

        // GET: ContactPageSection/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPageSection = await _context.ContactPageSection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactPageSection == null)
            {
                return NotFound();
            }

            return View(contactPageSection);
        }

        // GET: ContactPageSection/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactPageSection/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SectionName,Content,ImageUrl,IconClass,Order,IsActive")] ContactPageSection contactPageSection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactPageSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactPageSection);
        }

        // GET: ContactPageSection/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPageSection = await _context.ContactPageSection.FindAsync(id);
            if (contactPageSection == null)
            {
                return NotFound();
            }
            return View(contactPageSection);
        }

        // POST: ContactPageSection/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SectionName,Content,ImageUrl,IconClass,Order,IsActive")] ContactPageSection contactPageSection)
        {
            if (id != contactPageSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactPageSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactPageSectionExists(contactPageSection.Id))
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
            return View(contactPageSection);
        }

        // GET: ContactPageSection/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPageSection = await _context.ContactPageSection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactPageSection == null)
            {
                return NotFound();
            }

            return View(contactPageSection);
        }

        // POST: ContactPageSection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactPageSection = await _context.ContactPageSection.FindAsync(id);
            if (contactPageSection != null)
            {
                _context.ContactPageSection.Remove(contactPageSection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactPageSectionExists(int id)
        {
            return _context.ContactPageSection.Any(e => e.Id == id);
        }
    }
}
