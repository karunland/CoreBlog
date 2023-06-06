using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class MessageController : Controller
    {
        [HttpGet]
        public IActionResult Inbox()
        {
            return View();
        }
    }
}
