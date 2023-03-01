using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace error_fix_package.Controllers
{
    public class BlogController : Controller
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            return View(_blogManager.GetAllBlogs());
        }
        
        public IActionResult BlogDetails(int id)
        {
            return View(_blogManager.GetBlogById(id));
        }
    }
}
