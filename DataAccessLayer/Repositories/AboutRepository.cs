using DataAccessLayer.Abstract;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories
{
    public class AboutRepository: GenericRepository<About>, IAboutDal
    {
    }
}
