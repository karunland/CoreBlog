using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryReposiyory());
        public IViewComponentResult Invoke()
        {
            var item = _categoryManager.GetList();
            return View(item);
        }
    }
}
