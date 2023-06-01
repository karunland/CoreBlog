using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer
{
    public class WriterAboutonDashboard : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;

        Context c = new Context();

        public WriterAboutonDashboard(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke(int id)
        {
            var name = User.Identity?.Name;
            if (name == null)
                return View(wm.GetWriterbyId(1));
            
            var userid = c.Writers.Where(x=> x.WriterName == name).Select(y=>y.Id).FirstOrDefault();
            var mail = c.Writers.Where(x=> x.WriterName == name).Select(y=>y.WriterMail).FirstOrDefault();
            
            var val = wm.GetByIdd(userid);
            return View(val);
        }
    }
}
