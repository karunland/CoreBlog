using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("/Admin/[Controller]/[Action]/")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

        public IActionResult WriterList()
        {
            var jsonwriter = JsonConvert.SerializeObject(writers);
            return Json(jsonwriter);
        }

        [HttpGet("{id}")]
        public IActionResult GetWriterById(int id)
        {
            var writer = writers.FirstOrDefault(x=>x.Id == id);
            var json = JsonConvert.SerializeObject(writer);
            return Json(json);
        }
    }
}
