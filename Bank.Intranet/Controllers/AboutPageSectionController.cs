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
    public class AboutPageSectionController : Controller
    {
        private readonly BankContext _context;

        public AboutPageSectionController(BankContext context)
        {
            _context = context;
        }

        // GET: AboutPageSection
        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutPageSection.ToListAsync());
        }

        // GET: AboutPageSection/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutPageSection = await _context.AboutPageSection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutPageSection == null)
            {
                return NotFound();
            }

            return View(aboutPageSection);
        }

        // GET: AboutPageSection/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AboutPageSection/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SectionName,Content,ImageUrl,IconClass,Order,IsActive")] AboutPageSection aboutPageSection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aboutPageSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aboutPageSection);
        }

        // GET: AboutPageSection/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutPageSection = await _context.AboutPageSection.FindAsync(id);
            if (aboutPageSection == null)
            {
                return NotFound();
            }
            return View(aboutPageSection);
        }

        // POST: AboutPageSection/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SectionName,Content,ImageUrl,IconClass,Order,IsActive")] AboutPageSection aboutPageSection)
        {
            if (id != aboutPageSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aboutPageSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AboutPageSectionExists(aboutPageSection.Id))
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
            return View(aboutPageSection);
        }

        // GET: AboutPageSection/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutPageSection = await _context.AboutPageSection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aboutPageSection == null)
            {
                return NotFound();
            }

            return View(aboutPageSection);
        }

        // POST: AboutPageSection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aboutPageSection = await _context.AboutPageSection.FindAsync(id);
            if (aboutPageSection != null)
            {
                _context.AboutPageSection.Remove(aboutPageSection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AboutPageSectionExists(int id)
        {
            return _context.AboutPageSection.Any(e => e.Id == id);
        }
    }
}
