using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetAll()
        {
            using (var item = new Context())
            {
                var list = item.Blogs
                    .Include(x => x.Category)
                    .ToList();

                return list;
            }
        }
        public List<Blog> GetAll(int WriterId)
        {
            using (var item = new Context())
            {
                var list = item.Blogs
                    .Include(x => x.Category)
                    .Where(x => x.WriterId == WriterId && x.isDeleted == false)
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

        public void Delete(int id)
        {
            using (var c = new Context())
            {
                Blog item = c.Blogs.Where(x => x.BlogId == id).FirstOrDefault();
                item.isDeleted = true;
                c.SaveChanges();
            }
        }
    }
}
