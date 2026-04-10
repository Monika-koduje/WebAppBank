using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAppBank.Controllers
{
    public class BranchController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BankContext _context;

        public BranchController(ILogger<HomeController> logger, BankContext context)
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

            ViewBag.ModelBranch =
                (
                    from branch in _context.Branch
                    orderby branch.IdBranch
                    select branch
                ).ToList();

            var item = await _context.Branch.FirstOrDefaultAsync(a => a.IdBranch == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

    }
}