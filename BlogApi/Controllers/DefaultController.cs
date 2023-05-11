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

        [HttpPost]
        public IActionResult EmployeeAdd(Employee model)
        {
            using (var context = new Context())
            {
                bool user = context.Employees.Where(x => x.Id == model.Id).Any();
                if (user)
                    return BadRequest();
                context.Employees.Add(model);
                context.SaveChanges();
            }
            return Ok(model);
        }
    }
}
