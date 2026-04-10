using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bank.Intranet.Controllers
{
    public class ClientBankProductController : Controller
    {
        private readonly BankContext _context;

        public ClientBankProductController(BankContext context)
        {
            _context = context;
        }

        // GET: ClientBankProduct
        public async Task<IActionResult> Index()
        {
            var bankIntranetContext = _context.ClientBankProduct.Include(c => c.BankProduct).Include(c => c.Client);
            return View(await bankIntranetContext.ToListAsync());
        }

        // GET: ClientBankProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientBankProduct = await _context.ClientBankProduct
                .Include(c => c.BankProduct)
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.IdClientProduct == id);
            if (clientBankProduct == null)
            {
                return NotFound();
            }

            return View(clientBankProduct);
        }

        // GET: ClientBankProduct/Create
        public IActionResult Create()
        {
            ViewData["IdProduct"] = new SelectList(_context.BankProduct, "IdProduct", "ProductName");
            ViewData["IdClient"] = new SelectList(_context.Client, "IdClient", "Email");
            return View();
        }

        // POST: ClientBankProduct/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClientProduct,IdClient,IdProduct,AcquiredDate")] ClientBankProduct clientBankProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientBankProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProduct"] = new SelectList(_context.BankProduct, "IdProduct", "ProductName", clientBankProduct.IdProduct);
            ViewData["IdClient"] = new SelectList(_context.Client, "IdClient", "Email", clientBankProduct.IdClient);
            return View(clientBankProduct);
        }

        // GET: ClientBankProduct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientBankProduct = await _context.ClientBankProduct.FindAsync(id);
            if (clientBankProduct == null)
            {
                return NotFound();
            }
            ViewData["IdProduct"] = new SelectList(_context.BankProduct, "IdProduct", "ProductName", clientBankProduct.IdProduct);
            ViewData["IdClient"] = new SelectList(_context.Client, "IdClient", "Email", clientBankProduct.IdClient);
            return View(clientBankProduct);
        }

        // POST: ClientBankProduct/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClientProduct,IdClient,IdProduct,AcquiredDate")] ClientBankProduct clientBankProduct)
        {
            if (id != clientBankProduct.IdClientProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientBankProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientBankProductExists(clientBankProduct.IdClientProduct))
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
            ViewData["IdProduct"] = new SelectList(_context.BankProduct, "IdProduct", "ProductName", clientBankProduct.IdProduct);
            ViewData["IdClient"] = new SelectList(_context.Client, "IdClient", "Email", clientBankProduct.IdClient);
            return View(clientBankProduct);
        }

        // GET: ClientBankProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientBankProduct = await _context.ClientBankProduct
                .Include(c => c.BankProduct)
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.IdClientProduct == id);
            if (clientBankProduct == null)
            {
                return NotFound();
            }

            return View(clientBankProduct);
        }

        // POST: ClientBankProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientBankProduct = await _context.ClientBankProduct.FindAsync(id);
            if (clientBankProduct != null)
            {
                _context.ClientBankProduct.Remove(clientBankProduct);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientBankProductExists(int id)
        {
            return _context.ClientBankProduct.Any(e => e.IdClientProduct == id);
        }
    }
}
