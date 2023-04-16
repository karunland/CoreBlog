using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryReposiyory());

        [HttpGet("Index/{page?}")]
        public IActionResult Index(int page = 1)
        {
            var items = _categoryManager.GetList().ToPagedList(page, 3);
            return View(items);
        }
    }
}
