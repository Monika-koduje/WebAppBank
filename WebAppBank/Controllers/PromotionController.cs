using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAppBank.Controllers
{
    public class PromotionController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BankContext _context;

        public PromotionController(ILogger<HomeController> logger, BankContext context)
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

            ViewBag.ModelNotification =
                (
                    from promotion in _context.Notification
                    orderby promotion.IdNotification
                    select promotion
                ).ToList();

            var item = await _context.Notification.FirstOrDefaultAsync(a => a.IdNotification == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

    }
}