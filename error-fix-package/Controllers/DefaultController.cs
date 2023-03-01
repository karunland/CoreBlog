using Microsoft.AspNetCore.Mvc;

namespace error_fix_package.Controllers
{
    public class DefaultController : Controller
    {
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
    }
}
