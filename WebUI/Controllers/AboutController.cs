using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class AboutController : Controller
    {
        AboutManager am = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var items = am.GetList();
            return View(items);
        }

        [HttpGet]
        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
