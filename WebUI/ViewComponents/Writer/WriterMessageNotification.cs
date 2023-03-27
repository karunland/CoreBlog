using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
