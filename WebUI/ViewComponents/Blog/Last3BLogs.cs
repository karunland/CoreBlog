using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace WebUI.ViewComponents.Blog
{
    public class Last3Blogs : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var vals = bm.GetLast3Blogs();
            return View(vals);
        }
    }
}
