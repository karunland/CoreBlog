using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin,Member,Writer")]
    public class BlogController : Controller
    {
        BlogManager _blogManager = new BlogManager(new EfBlogRepository());

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_blogManager.GetList());
        }
        
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            return View(_blogManager.GetBlogById(id));
        }

        [AllowAnonymous]
        public IActionResult GetBLogByWriter()
        {
            Context c = new Context();
            var userName = User.Identity?.Name;
            var userid = c.Writers.Where(x => x.WriterName == userName).Select(y => y.Id).FirstOrDefault();
            return View(_blogManager.GetBlogByWriter(userid));
        }

        [HttpGet]
        [Authorize(Roles = "Writer, Admin")]
        public IActionResult BlogAdd(int? id)
        {
           
            CategoryManager cm = new CategoryManager(new EfCategoryReposiyory());
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            var userName = User.Identity?.Name;
            Context c = new Context();
            var userid = c.Writers.Where(x => x.WriterName == userName).Select(y => y.Id).FirstOrDefault();

            ViewBag.id = userid;
            ViewBag.cv = categoryValues;

            if (id != 0 && id != null)
            {
                var item = _blogManager.GetBlogById((int)userid);
                return View(item);
            }
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Writer, Admin")]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator bv = new BlogValidator();
            var results = bv.Validate(p);
            if (results.IsValid)
            {
                p.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());

                // sql trigger sildigim icin burda kendim ekleme yapiyorum
                // writerId artik Identity den aliniyor
                using (var context = new Context())
                {
                    var username = User.Identity.Name;
                    var id = context.Writers.Where(x => x.WriterName == username).Select(x => x.Id).FirstOrDefault();
                    p.WriterId = id;
                    _blogManager.TAdd(p);
                    BlogRating newRatingRow = new BlogRating { BLogId = p.Id, RatingCount = 0, TotalScore = 0 };
                    context.BlogRatings.Add(newRatingRow);
                    context.SaveChanges();
                }
                
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

        [Authorize(Roles = "Writer, Admin")]
        public IActionResult BlogDelete(int id)
        {
            _blogManager.DeleteBlog(id);
            return RedirectToAction("GetBLogByWriter");
        }
    }
}
