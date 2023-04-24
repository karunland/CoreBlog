using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class WidgetController : Controller
    {
        [Area("Admin")]
        //[Route("/Admin/[Controller]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
