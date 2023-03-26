﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace WebUI.ViewComponents.Blog
{
    public class WriterLastBlogs : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());

        [HttpGet]
        public IViewComponentResult Invoke(int id)
        {
            var vals = bm?.GetBlogByWriter(id);
            return View(vals);
        }
    }
}
