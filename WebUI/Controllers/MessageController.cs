using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
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
        public IActionResult Details(int id)
        {
            return View(mm.GetByIdd(id));
        }

        [HttpGet]
        public async Task<IActionResult> sendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> sendMessage(Message2 message)
        {
            var username = User.Identity.Name;
            var context = new Context();
            var id = context.Writers.Where(x => x.WriterName == username).Select(x => x.Id).FirstOrDefault();
            message.SenderId = id;
            message.RecieverId = 2;
            message.Status = true;
            mm.TAdd(message);
            return RedirectToAction("Inbox");
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
    }
}
