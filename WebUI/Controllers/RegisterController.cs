using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        WriterManager _writerManager = new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManger;

        public RegisterController(UserManager<AppUser> userManger)
        {
            _userManger = userManger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto p)
        {
            WriterValidator vw = new WriterValidator();
            Writer writer = new Writer();
            ValidationResult results = vw.Validate(p);
            if (results.IsValid)
            {
                if (writer.WriterPassword != writer.WriterPasswordAgain)
                {
                    return View("Index");
                }

                if (p.WriterImage != null)
                {
                    var extension = Path.GetExtension(p.WriterImage.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var loc = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newImageName);
                    var stream = new FileStream(loc, FileMode.Create);
                    p.WriterImage.CopyTo(stream);
                    writer.WriterImage = newImageName != null ? "/WriterImageFiles/" + newImageName : "";
                }
                else
                    writer.WriterImage = "/writer/assets/images/faces-clipart/pic-" + new Random().Next(1, 4) + ".png";

                writer.Id = 0;
                writer.WriterName = p.WriterName;
                writer.WriterMail = p.WriterMail;
                writer.WriterPassword = p.WriterPassword;
                writer.WriterAbout = "";
                writer.WriterStatus = true;
                writer.WriterPasswordAgain = p.WriterPasswordAgain;

                _writerManager.TAdd(writer);

                AppUser user = new AppUser()
                {
                    Email = writer.WriterMail,
                    FullName = writer.WriterName,
                    UserName = writer.WriterName,
                    ImageUrl = writer.WriterImage
                };

                var result = await _userManger.CreateAsync(user, writer.WriterPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
