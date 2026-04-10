using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAppBank.Controllers
{
    public class NewsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BankContext _context;

        public NewsController(ILogger<HomeController> logger, BankContext context)
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

            ViewBag.ModelNews =
                (
                    from news in _context.News
                    orderby news.DisplayOrder
                    select news
                ).ToList();

            var item = await _context.News.FirstOrDefaultAsync(a => a.IdNews == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

    }
}
