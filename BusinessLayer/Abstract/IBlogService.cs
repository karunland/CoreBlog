using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetBlogByWriter(int id);
        Blog GetBlogById(int id);
        void DeleteBlog(int id);
    }
}
