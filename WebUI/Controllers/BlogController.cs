using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

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
            return View(_blogManager.GetBlogByWriter(1));
        }
        [HttpGet]
        public IActionResult BlogAdd(int? id)
        {
            CategoryManager cm = new CategoryManager(new EfCategoryReposiyory());
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.id = 1;
            ViewBag.cv = categoryValues;
            if (id != 0 && id != null)
            {
                var item = _blogManager.GetBlogById((int)id);
                return View(item);
            }
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator bv = new BlogValidator();
            var results = bv.Validate(p);
            if (results.IsValid)
            {
                p.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterId = 1;
                _blogManager.TAdd(p);
                return RedirectToAction("GetBlogByWriter", "Blog");
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

        public IActionResult BlogDelete(int id)
        {
            _blogManager.DeleteBlog(id);
            return RedirectToAction("GetBLogByWriter");
        }
    }
}
