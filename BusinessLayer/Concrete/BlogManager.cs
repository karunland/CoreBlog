using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Security.Cryptography.X509Certificates;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public List<Blog> GetLast3Blogs()
        {
            return _blogDal.GetAll().Take(3).ToList();
        }

        public Blog GetBlogById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetBlogByWriter(int WriterId)
        {
            return _blogDal.GetAll(WriterId);
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Blog t)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetAll();
        }

        public Blog GetByIdd(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlog(int id)
        {
            _blogDal.Delete(id);
        }
    }
}
