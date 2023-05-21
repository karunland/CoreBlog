using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebUI.Controllers
{
    public class EmployeeTestController : Controller
    {
        [HttpGet, Route("/test")]
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:7051/api/Default/GetAll");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<Class1>>(jsonString);

            return View(values);
        }

        [HttpGet, Route("/test/add")]
        public async Task<IActionResult> add()
        {
            return View();
        }


        [HttpPost, Route("/test/add")]
        public async Task<IActionResult> add([FromForm] Class1 person)
        {
            var httpClient = new HttpClient();
            var stringa = JsonConvert.SerializeObject(person);

            var jsonEmployee = new StringContent(stringa, Encoding.UTF8, "application/json");

            await httpClient.PostAsync($"https://localhost:7051/api/Default/Add", jsonEmployee);

            return View();
        }
    }


    public class Class1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
