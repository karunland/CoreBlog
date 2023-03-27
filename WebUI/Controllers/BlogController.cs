using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class BlogController : Controller
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());

        public IActionResult Index()
        {
            return View(_blogManager.GetList());
        }
        
        public IActionResult Details(int id)
        {
            return View(_blogManager.GetBlogById(id));
        }

        public IActionResult GetBLogByWriter(int id)
        {
            return View(_blogManager.GetBlogByWriter(4));
        }
    }
}
