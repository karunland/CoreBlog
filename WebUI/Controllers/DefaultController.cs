using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
    }
}
