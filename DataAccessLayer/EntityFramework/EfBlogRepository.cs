using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : IBlogDal
    {
        public void Delete(Blog item)
        {
            throw new NotImplementedException();
        }
        public List<Blog> GetAll()
        {
            using (var item = new Context())
            {
                var list2 = item.Catergories.ToList();
                var list = item.Blogs
                    .Include(x => x.RCategory)
                    .ToList();

                return list;
            }
        }
        public List<Blog> GetAll(Expression<Func<Blog, bool>> filter)
        {
            using (var c = new Context())
            {
                return c.Set<Blog>()
                    .Where(filter)
                    .ToList();
            }
        }
        public Blog GetById(int id)
        {
            using (var item = new Context())
            {
                return item.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
            }
        }
        public List<Blog> GetListAll()
        {
            throw new NotImplementedException();
        }
        public void Insert(Blog item)
        {
            throw new NotImplementedException();
        }
        public void Update(Blog item)
        {
            throw new NotImplementedException();
        }

    }
}
