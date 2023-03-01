using DataAccessLayer.Abstract;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContactRepository : ICategoryDal
    {
        public void Delete(Contact item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Category item)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Contact GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetListAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(Contact item)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category item)
        {
            throw new NotImplementedException();
        }

        public void Update(Contact item)
        {
            throw new NotImplementedException();
        }

        public void Update(Category item)
        {
            throw new NotImplementedException();
        }

        Category IGenericDal<Category>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        List<Category> IGenericDal<Category>.GetListAll()
        {
            throw new NotImplementedException();
        }
    }
}
