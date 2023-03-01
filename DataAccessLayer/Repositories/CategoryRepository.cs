using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositores
{
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context();
        public void AddCategory(Category category)
        {
            c.Add(category);
            c.SaveChanges();
        }
        public void DeleteCategory(Category category)
        {
            c.Remove(category);
            c.SaveChanges();
        }
        public void UpdateCategory(Category category)
        {
            c.Update(category);
        }
        public Category GetById(int id)
        {
            return c.Catergories.Find(id);
        }
        public List<Category> ListAllCategory()
        {
            return c.Catergories.ToList();
        }
        public void Update(Category item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category item)
        {
            using var c = new Context();
            c.Remove(item);

        }
        public void Insert(Category item)
        {
            throw new NotImplementedException();
        }
        public List<Category> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
