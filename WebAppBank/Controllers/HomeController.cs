using Company.Data.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppBank.Models;

namespace WebAppBank.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BankContext _context;

        public HomeController(ILogger<HomeController> logger, BankContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int? id)
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

            ViewBag.ModelBankProduct =
    (
        from product in _context.BankProduct
        orderby product.IdProduct
        select product
    ).ToList();

            ViewBag.ModelBranch =
    (
        from branch in _context.Branch
        orderby branch.IdBranch
        select branch
    ).ToList();

            ViewBag.ModelCardType =
    (
        from card in _context.CardType
        orderby card.IdCardType
        select card
    ).ToList();

            ViewBag.ModelEmployee =
    (
        from employee in _context.Employee
        orderby employee.Position
        select employee
    ).ToList();

            ViewBag.ModelNotification =
    (
        from promotion in _context.Notification
        orderby promotion.IdNotification
        select promotion
    ).ToList();

            ViewBag.ModelAbout =
    (
        from about in _context.AboutPageSection
        orderby about.Id
        select about
    ).ToList();

            ViewBag.ModelContact =
    (
        from contact in _context.ContactPageSection
        orderby contact.Id
        select contact
    ).ToList();

            ViewBag.ModelPrivacy =
    (
        from privacy in _context.PolicyPageSection
        orderby privacy.Id
        select privacy
    ).ToList();



            if (id == null)
                id = _context.Page.First().IdPage;
            var item = _context.Page.Find(id);

            return View(item);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
