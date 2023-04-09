using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            Context a = new Context();
            ViewBag.v1 = a.Blogs.Count();
            ViewBag.v2 = a.Blogs.Where(x => x.WriterId == 1).Count();
            ViewBag.v3 = a.Catergories.Count();
            return View();
        }
    }
}
