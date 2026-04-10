using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppBank.Controllers
{
    public class ContactPageController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BankContext _context;

        public ContactPageController(ILogger<HomeController> logger, BankContext context)
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

            ViewBag.ModelContact =
                (
                    from contact in _context.ContactPageSection
                    orderby contact.Id
                    select contact
                ).ToList();

            var item = await _context.ContactPageSection.FirstOrDefaultAsync(a => a.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

    }
}
