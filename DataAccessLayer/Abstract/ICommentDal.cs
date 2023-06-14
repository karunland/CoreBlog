using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface ICommentDal : IGenericDal<Comment>
    {
        List<Comment> GetAll();
        List<Comment> GetAllwithUser(int blogId);

    }
}
