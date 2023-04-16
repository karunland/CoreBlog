using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer
{
    public class WriterAboutonDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();
        public IViewComponentResult Invoke(int id)
        {
            var usermail = User.Identity?.Name;
            if (usermail == null)
                return View(wm.GetWriterbyId(1));
            var userid = c.Writers.Where(x=> x.WriterMail == usermail).Select(y=>y.Id).FirstOrDefault();
            var val = wm.GetByIdd(userid);
            return View(val);
        }
    }
}
