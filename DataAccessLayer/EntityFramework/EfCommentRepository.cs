using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentRepository : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetAll(int blogId)
        {
            using (var item = new Context())
            {
                List<Comment> x = item.Comments.Where(x => x.BlogId == blogId).ToList();
                return x;
            }
        }
    }
}
