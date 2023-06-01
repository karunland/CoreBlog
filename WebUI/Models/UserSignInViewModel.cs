using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Please enter Name and Surname!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter Password!")]
        public string Password { get; set; }
    }
}
