using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Security.Cryptography.X509Certificates;

namespace BusinessLayer.Concrete
{
    public class BlogManager: IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public List<Blog> GetAllBlogs()
        {
            return _blogDal.GetAll();
        }
        public List<Blog> GetLast3Blogs()
        {
            return _blogDal.GetAll().Take(3).ToList();
        }
        public Blog GetBlogById(int id)
        {
            return _blogDal.GetById(id);
        }
        public void BlogAdd(Blog blog)
        {
            throw new NotImplementedException();
        }
        public void BlogDelete(Blog blog)
        {
            throw new NotImplementedException();
        }
        public void BlogUpdate(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogByWriter(int WriterId)
        {
            return _blogDal.GetAll(x => x.WriterId == WriterId);
        }
    }
}
