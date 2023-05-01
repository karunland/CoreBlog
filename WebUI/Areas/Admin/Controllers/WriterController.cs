using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WriterList()
        {
            var jsonwriter = JsonConvert.SerializeObject(writers);

            return View(jsonwriter);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id = 1,
                Name = "john"
            },
            new WriterClass
            {
                Id = 3,
                Name = "doe"
            },
            new WriterClass
            {
                Id = 2,
                Name = "max"
            }
        };
    }
}
