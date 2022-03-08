using System.ComponentModel.DataAnnotations;

namespace PromoAPI.Model
{
    public class SignInModel
    {
        [Required(ErrorMessage ="Please Enter Your Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }


    }
}
