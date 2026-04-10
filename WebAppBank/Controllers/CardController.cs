using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAppBank.Controllers
{
    public class CardController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BankContext _context;

        public CardController(ILogger<HomeController> logger, BankContext context)
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

            ViewBag.ModelCardType =
                (
                    from card in _context.CardType
                    orderby card.IdCardType
                    select card
                ).ToList();

            var item = await _context.CardType.FirstOrDefaultAsync(a => a.IdCardType == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

    }
}