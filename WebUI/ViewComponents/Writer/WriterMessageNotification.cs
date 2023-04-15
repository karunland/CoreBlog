using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Repository());
        public IViewComponentResult Invoke()
        {
            return View(mm.GetInboxListByWriter(2));
        }
    }
}
