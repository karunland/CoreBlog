using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    //[Authorize]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterProfile(int? id)
        {
            return View();
        }
        public IActionResult Test(int? id)
        {
            return View();
        }
        public PartialViewResult WriterNavPartial()
        {
            return PartialView();
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
    }
}
