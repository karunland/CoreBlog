using BlogApi.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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
                    return NotFound();
                context.Employees.Add(model);
                context.SaveChanges();
            }
            return Ok(model);
        }

        [HttpGet, Route("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            using (var context = new Context())
            {
                var user = context.Employees.Where(x => x.Id == id).FirstOrDefault();
                return user == null ? NotFound() : Ok(user);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            using (var context = new Context())
            {
                var user = context.Employees.FirstOrDefault(e => e.Id == id);
                if (user == null)
                    return NotFound();

                context.Employees.Remove(user);
                context.SaveChanges();

                return Ok();
            }
        }

        [HttpPut]
        public IActionResult EmployeeUpdate(Employee model)
        {
            using (var context = new Context())
            {
                var item = context.Employees.FirstOrDefault(o => o.Id == model.Id);
                if (item == null)
                    return NotFound();
                item.Name = model.Name;
                context.Employees.Update(item);
                context.SaveChanges();
                return Ok(item);
            }   
        }
    }
}
