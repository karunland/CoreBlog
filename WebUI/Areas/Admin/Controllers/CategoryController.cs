using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("Add/")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost("Add/")]
        public IActionResult Add(Category model)
        {
            CategoryValidator cv = new CategoryValidator();
            model.CategoryStatus = true;
            var results = cv.Validate(model);
            if (results.IsValid)
            {
                _categoryManager.TAdd(model);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        [HttpPost("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _categoryManager.TDelete(_categoryManager.GetByIdd(id));
            return RedirectToAction("Index");
        }
    }
}
