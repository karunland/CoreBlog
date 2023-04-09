using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
