using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositores;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CommentController: Controller
    {
        ICommentDal _commentDal;
        public CommentController(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public PartialViewResult PartialAddComment(int? id)
        //{
        //    return PartialView();
        //}
        //public PartialViewResult CommentListByBlog(int? id)
        //{
        //    return PartialView(_commentDal.GetAll(12));
        //}
    }
}
