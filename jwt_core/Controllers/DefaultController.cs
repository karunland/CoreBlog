using jwt_core.Dal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jwt_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            return Created("", new GenerateToken().CreateToken());
        }

        [Authorize]
        [HttpGet("[action]")]
        public IActionResult page1()
        {
            return Ok("sayfa 1 icin giris basarili");
        }
    }
}
