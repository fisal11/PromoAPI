using Microsoft.AspNetCore.Identity;

namespace PromoAPI.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string  FirstName { get; set; }
        public string  LastNamed { get; set; }

    }
}
