using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents
{
    public class Statistic2 : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Blogs.OrderByDescending(x => x.Id)?
                                .Take(1)
                                .Select(y => y.BlogTitle)
                                .FirstOrDefault();
            return View();
        }
    }
}
