using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetAll();
        List<Blog> GetAll(int WriterId);
        void Delete(int id);
    }
}
