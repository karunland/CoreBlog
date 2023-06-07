using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());

        [HttpGet]
        public async Task<IActionResult> Inbox()
        {
            var username = User.Identity.Name;
            var context = new Context();
            var id = context.Writers.Where(x => x.WriterName == username).Select(x => x.Id).FirstOrDefault();
            return View(mm.GetInboxListByWriter(id));
        }

        [HttpGet]
        public async Task<IActionResult> sendbox()
        {
            var username = User.Identity.Name;
            var context = new Context();
            var id = context.Writers.Where(x => x.WriterName == username).Select(x => x.Id).FirstOrDefault();
            var list = mm.GetSendboxListByWriter(id);
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> composeMail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> composeMail(Message2 message)
        {
            return View();
        }
    }
}
