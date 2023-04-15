using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        
        [HttpGet]
        public IActionResult Inbox()
        {
            return View(mm.GetInboxListByWriter(2));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(mm.GetByIdd(id));
        }
    }
}
