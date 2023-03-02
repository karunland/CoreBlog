using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryReposiyory : GenericRepository<Category>, ICategoryDal
    {
        public List<Category> GetListAll()
        {
            using (var item = new Context())
            {
                return item.Catergories.ToList();
            }
        }
    }
}
