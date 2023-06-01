using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebUI.ViewComponents.Category
{
    [AllowAnonymous]
    public class CategoryList: ViewComponent
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryReposiyory());
        public IViewComponentResult Invoke()
        {
            var item = _categoryManager.GetList();
            return View(item);
        }
    }
}
