using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositores
{
    class BlogCategory: GenericRepository<Blog> //IBlogDal
    {
        //public void Delete(Blog item)
        //{
        //    using var c = new Context();
        //    c.Remove(item);
        //    c.SaveChanges();    
        //}

        //public Blog GetById(int id)
        //{
        //    using var c = new Context();
        //    return c.Blogs.Find(id);
        //}

        //public List<Blog> GetAll()
        //{
        //    using (var c = new Context())
        //    {
        //        return c.Blogs.ToList();
        //    }
        //}

        //public void Add(Blog item)
        //{
        //    using var c = new Context();
        //    c.Add(item);
        //    c.SaveChanges();
        //}

        //public void Update(Blog item)
        //{
        //    using var c = new Context();
        //    c.Update(item);
        //    c.SaveChanges();
        //}
    }
}
