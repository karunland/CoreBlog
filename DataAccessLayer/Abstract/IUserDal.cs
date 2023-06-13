using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IUserDal : IGenericDal<AppUser>
    {
        /// <summary>
        /// returns current logged in user Id
        /// </summary>
        /// <returns></returns>
        int GetCurrentUserId(string userName);

        Writer GetLoggedUser();
    }
}
