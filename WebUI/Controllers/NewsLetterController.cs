using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager lm = new NewsLetterManager(new EfNewsLetterRepository());


        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeMail(int id, NewsLetter model)
        {
            model.MailStatus = true;
            lm.AddNewsLetter(model);
            return RedirectToAction("Details", "Blog", new { id = id } );
        }
    }
}
