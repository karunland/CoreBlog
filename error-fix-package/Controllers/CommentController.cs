using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialAddComment(int? id)
        {
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int? id)
        {
            return PartialView();
        }
    }
}
