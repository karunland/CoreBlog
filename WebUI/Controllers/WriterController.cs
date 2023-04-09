using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Controllers
{

    //[Authorize]
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterProfile(int? id)
        {
            return View();
        }
        public IActionResult Test(int? id)
        {
            return View();
        }
        public PartialViewResult WriterNavPartial()
        {
            return PartialView();
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult EditProfile()
        {
            var val = wm.GetByIdd(1);
            return View(val);
        }
        [HttpPost]
        public IActionResult EditProfile(Writer p)
        {
            WriterValidator validationRules = new WriterValidator();
            var results = validationRules.Validate(p);
            if (results.IsValid)
            {
                wm.TAdd(p);
                return RedirectToAction("index", "dashboard");
            }
            else
            {
                foreach (var val in results.Errors)
                {
                    ModelState.AddModelError(val.PropertyName, val.ErrorMessage);

                }
            }
            return View();
        }
    }
}
