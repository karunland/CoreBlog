using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
    }
}
