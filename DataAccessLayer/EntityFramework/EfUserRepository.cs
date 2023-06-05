using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfUserRepository : GenericRepository<AppUser>, IUserDal
    {
        public int GetCurrentUserId(string userName)
        {
            var _context = new Context();
            var id =  _context.Writers.Where(x => x.WriterName == userName).Select(x => x.Id).FirstOrDefault();
            return id == null ? 0 : (int)id;
        }
    }
}
