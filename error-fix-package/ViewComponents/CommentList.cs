using DataAccessLayer.Abstract;
using WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebUI.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var user = new List<UserModel>
            {
                new UserModel
                {
                    Id = 1,
                    Name = "user1"
                },
                new UserModel
                {
                    Id = 2,
                    Name = "user2"
                },
                new UserModel
                {
                    Id = 3,
                    Name = "user3"
                }
            };
            return View(user);
        }
    }
}
