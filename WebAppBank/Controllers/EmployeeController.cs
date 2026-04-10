using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAppBank.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BankContext _context;

        public EmployeeController(ILogger<HomeController> logger, BankContext context)
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

            ViewBag.ModelEmployee =
                (
                    from employee in _context.Employee
                    orderby employee.IdEmployee
                    select employee
                ).ToList();

            var item = await _context.Employee.FirstOrDefaultAsync(a => a.IdEmployee == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

    }
}
