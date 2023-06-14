using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]
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
            if (model.Score == null || model.Score == 0)
                model.Score = 5;
            cm.CommentAdd(model);

            // sql trigger sildigim icin burda kendim ekleme yapiyorum
            using (var context = new Context())
            {
                BlogRating RatingRow = context.BlogRatings.Where(x => x.BLogId == model.BlogId).FirstOrDefault();
                if (RatingRow != null)
                {
                    RatingRow.RatingCount++;
                    RatingRow.TotalScore = RatingRow.TotalScore + model.Score ;
                    context.BlogRatings.Update(RatingRow);
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Details", "Blog", new { id = model.BlogId });
        }
    }
}
