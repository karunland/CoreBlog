using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult PartialAddComment(Comment model)
        {
            model.CommentStatus = true;
            model.CommentDate = DateTime.Now;
            if (model.Score == null || model.Score == 0)
                model.Score = 5;
            cm.CommentAdd(model);
            return RedirectToAction("Details", "Blog", new { id = model.BlogId });
        }
    }
}
