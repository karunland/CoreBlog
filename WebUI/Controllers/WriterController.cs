using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class WriterController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        WriterManager wm = new WriterManager(new EfWriterRepository());

        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
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
        
        [HttpGet]
        public IActionResult WriterAdd(int? id)
        {
            if (id != null)
            {
                var userName = User.Identity?.Name;
                Context c = new Context();
                var userid = c.Writers.Where(x => x.WriterName == userName).Select(y => y.Id).FirstOrDefault();
                var val = wm.GetByIdd(userid);

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

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var vals = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel a = new UserUpdateViewModel();
            a.namesurname = vals.FullName;
            a.username = vals.UserName;
            a.mail = vals.Email;
            return View(a);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserUpdateViewModel p)
        {
            var vals = await _userManager.FindByNameAsync(User.Identity.Name);
            vals.UserName = p.username;
            vals.FullName = p.namesurname;
            vals.ImageUrl = p.imageurl;
            var res = await _userManager.UpdateAsync(vals);
            if (res.Succeeded)
                return RedirectToAction("Index", "Dashboard");
            return View();
        }
    }
}
