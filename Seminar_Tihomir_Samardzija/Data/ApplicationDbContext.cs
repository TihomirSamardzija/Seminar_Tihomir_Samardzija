using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Seminar_Tihomir_Samardzija.Models.Dbo;

namespace Seminar_Tihomir_Samardzija.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet <Adress> Adress { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
