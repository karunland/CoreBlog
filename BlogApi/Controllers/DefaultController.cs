using BlogApi.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            using (var context = new Context())
            {
                var items = context.Employees.ToList();
                return Ok(items);
            }
        }
    }
}
