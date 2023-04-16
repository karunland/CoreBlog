using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult AdminNavbarPartial()
        //{
        //    return PartialView("_AdminNavbarPartial");
        //}

    }
}
