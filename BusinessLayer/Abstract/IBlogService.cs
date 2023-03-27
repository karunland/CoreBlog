using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        //List<Blog> GetAllBlogs();
        List<Blog> GetBlogByWriter(int id);
        Blog GetBlogById(int id);
    }
}
