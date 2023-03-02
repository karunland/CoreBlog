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
    }
}
