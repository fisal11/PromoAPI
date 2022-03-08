using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PromoAPI.Model;
using PromoAPI.Model.DTO;

namespace PromoAPI.Data
{
    public class PromoContext :IdentityDbContext<ApplicationUser>
    {
        public PromoContext(DbContextOptions<PromoContext>options)
            :base(options)
        {

        }
        public DbSet<PromoParkDTO> PromoParks { get; set; } 
    }
}
