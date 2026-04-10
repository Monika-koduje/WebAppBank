using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppBank.Controllers
{
    public class PolicyPageController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BankContext _context;

        public PolicyPageController(ILogger<HomeController> logger, BankContext context)
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

            ViewBag.ModelPrivacy =
                (
                    from privacy in _context.PolicyPageSection
                    orderby privacy.Id
                    select privacy
                ).ToList();

            var item = await _context.AboutPageSection.FirstOrDefaultAsync(a => a.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

    }
}
