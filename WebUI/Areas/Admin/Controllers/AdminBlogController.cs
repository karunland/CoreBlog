using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());

        public async  Task<IActionResult> Index()
        {
            return View(_blogManager.GetList());
        }
    }
}
