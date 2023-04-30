using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WebUI.Areas.Admin.ViewComponents
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        Context context = new Context();
        
        public  IViewComponentResult Invoke()
        {
            string apiKey = "0fd75240baf47c86acec3fdeb7e68895";
            string city = "istanbul";
            string apiPath = $"https://api.openweathermap.org/data/2.5/weather?q=istanbul&appid=0fd75240baf47c86acec3fdeb7e68895&mode=xml ";
            ViewBag.BlogCount = bm.GetList().Count();
            ViewBag.MessageCount = context.Contacts.Count();
            ViewBag.CommentCount = context.Comments.Count();
            XDocument x = XDocument.Load(apiPath);
            ViewBag.weather = Convert.ToDouble(x.Descendants("temperature").ElementAt(0).Attribute("value").Value) - 273;
            return View();
        }
    }
}
