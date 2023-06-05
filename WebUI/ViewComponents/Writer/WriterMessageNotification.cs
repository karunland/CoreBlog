using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var context = new Context();
            int id = context.Writers.Where(x => x.WriterName == username).Select(x => x.Id).FirstOrDefault();

            var list = mm.GetInboxListByWriter(id);
            ViewBag.Count = list.ToList().Count;
            if (list.Count > 3) { return View(list.Take(3).ToList()); }
            return View(list.ToList());
        }
    }
}
