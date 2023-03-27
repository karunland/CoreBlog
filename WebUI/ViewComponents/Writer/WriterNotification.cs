using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
