using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositores;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace DataAccessLayer.EntityFramework
{
    public class EfUserRepository : GenericRepository<AppUser>, IUserDal
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AppUser> _userManager;

        public EfUserRepository(IHttpContextAccessor httpContext, UserManager<AppUser> userManager)
        {
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public int GetCurrentUserId(string userName)
        {
            var _context = new Context();
            var id =  _context.Writers.Where(x => x.WriterName == userName).Select(x => x.Id).FirstOrDefault();
            return id == null ? 0 : (int)id;
        }

        public Writer GetLoggedUser()
        {
            var _context = new Context();

            var user = _httpContext.HttpContext.User;
            var id = user.Claims.FirstOrDefault();
            if (id == null)
                return null;
            // id is aspnets user id so find this guys name
            var loggedInUser = _userManager.Users.Where(x => x.Id.ToString() == id.Value).FirstOrDefault();

            return _context.Writers.Where(x => x.WriterMail == loggedInUser.Email).FirstOrDefault();
        }
    }
}
