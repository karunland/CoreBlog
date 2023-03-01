using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    // business katmaninda abstract klasoru icinde yer alan interfaceler service oa.
    // business katmaninda concrete klasoru icerisinde yer alan siniflar manager oa.
    // validations are going to be here
    // A blog needs a name, content, and category. 
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        // generic version of code style
        //GenericRepository<Category> categoryRepository2 = new GenericRepository<Category>;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void CategoryAdd(Category category)
        {
            if (category.CategoryName != "" && 
                category.CatergoryDescription != "" &&
                category.CategoryName.Length >= 5 && 
                category.CategoryStatus == true)
            {
                _categoryDal.Insert(category);
            }
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
             _categoryDal.Update(category);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryDal.GetListAll();
        }

        public Category GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
