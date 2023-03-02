using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebUI.ViewComponents.Category
{
    public class CategoryList: ViewComponent
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryReposiyory());
        public IViewComponentResult Invoke()
        {
            var item = _categoryManager.GetAllCategories();
            return View(item);
        }

    }
}
