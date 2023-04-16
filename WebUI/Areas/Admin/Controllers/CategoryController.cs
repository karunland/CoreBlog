using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryReposiyory());
        [Area("Admin")]
        public IActionResult Index()
        {
            var items = _categoryManager.GetList();
            return View(items);
        }
    }
}
