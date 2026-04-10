using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.Intranet.Controllers
{
    public class BankProductController : Controller
    {
        private readonly BankContext _context;

        public BankProductController(BankContext context)
        {
            _context = context;
        }

        // GET: BankProduct
        public async Task<IActionResult> Index()
        {
            return View(await _context.BankProduct.ToListAsync());
        }

        // GET: BankProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankProduct = await _context.BankProduct
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (bankProduct == null)
            {
                return NotFound();
            }

            return View(bankProduct);
        }

        // GET: BankProduct/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduct,ProductName,Description,ProductType,InterestRate")] BankProduct bankProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bankProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bankProduct);
        }

        // GET: BankProduct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankProduct = await _context.BankProduct.FindAsync(id);
            if (bankProduct == null)
            {
                return NotFound();
            }
            return View(bankProduct);
        }

        // POST: BankProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduct,ProductName,Description,ProductType,InterestRate")] BankProduct bankProduct)
        {
            if (id != bankProduct.IdProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankProductExists(bankProduct.IdProduct))
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
            return View(bankProduct);
        }

        // GET: BankProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankProduct = await _context.BankProduct
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (bankProduct == null)
            {
                return NotFound();
            }

            return View(bankProduct);
        }

        // POST: BankProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bankProduct = await _context.BankProduct.FindAsync(id);
            if (bankProduct != null)
            {
                _context.BankProduct.Remove(bankProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankProductExists(int id)
        {
            return _context.BankProduct.Any(e => e.IdProduct == id);
        }
    }
}
