using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        public IViewComponentResult Invoke()
        {
            var vals = bm.GetLast3Blogs();
            return View(vals);
        }
    }
}
