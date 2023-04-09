using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebUI.Models;

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
        public IActionResult WriterAdd(int? id)
        {
            if (id != null)
            {
                var val = wm.GetByIdd((int)id);
                AddProfileImage person = new AddProfileImage()
                {
                    WriterName = val.WriterName,
                    WriterMail = val.WriterMail,
                    WriterAbout = val.WriterAbout,
                    Id = val.Id
                };
                ViewBag.Id = val.Id;
                return View(person);
            }
            ViewBag.Id = 0;
            return View();
        }

        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w = new Writer();

            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var loc = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                var stream = new FileStream(loc, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newImageName;
            }
            w.WriterMail = p.WriterMail;
            w.WriterName = p.WriterName;
            w.WriterPassword = p.WriterPassword;
            w.WriterStatus = p.WriterStatus;
            w.WriterAbout = p.WriterAbout;
            WriterValidator validationRules = new WriterValidator();
            var results = validationRules.Validate(w);
            if (results.IsValid)
            {
                wm.TAdd(w);
                return RedirectToAction("index", "dashboard");
            }
            else
                foreach (var val in results.Errors)
                    ModelState.AddModelError(val.PropertyName, val.ErrorMessage);
            return View();
        }
    }
}
