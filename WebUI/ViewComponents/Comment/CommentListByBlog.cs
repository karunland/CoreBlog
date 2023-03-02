using DataAccessLayer.Abstract;
using WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace WebUI.ViewComponents
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager _commentManager = new CommentManager(new EfCommentRepository());

        public IViewComponentResult Invoke(int BlogId)
        {
            var item = _commentManager.GetList(BlogId);
            return View(item);
        }
    }
}
