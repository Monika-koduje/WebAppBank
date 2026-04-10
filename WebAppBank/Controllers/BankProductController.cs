using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAppBank.Controllers
{
    public class BankProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BankContext _context;

        public BankProductController(ILogger<HomeController> logger, BankContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.ModelPages =
                (
                    from page in _context.Page
                    orderby page.DisplayOrder
                    select page
                ).ToList();

            ViewBag.ModelBankProduct =
                (
                    from product in _context.BankProduct
                    orderby product.IdProduct
                    select product
                ).ToList();

            var item = await _context.BankProduct.FirstOrDefaultAsync(a => a.IdProduct == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

    }
}
