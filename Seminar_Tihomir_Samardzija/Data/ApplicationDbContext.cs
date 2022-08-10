using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Seminar_Tihomir_Samardzija.Models.Dbo;
using Seminar_Tihomir_Samardzija.Models.Dbo.Base;
using Seminar_Tihomir_Samardzija.Models.ViewModel;
using Seminar_Tihomir_Samardzija.Models.Binding;

namespace Seminar_Tihomir_Samardzija.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public override int SaveChanges()
        {

            var entries = ChangeTracker
                        .Entries()
                        .Where(e => e.Entity is IEntityBase && (
                          e.State == EntityState.Added
                          || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        ((IEntityBase)entityEntry.Entity).Created = DateTime.Now;
                        break;
                    default:
                        break;
                }

            }
            return base.SaveChanges();

        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {

            var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IEntityBase && (
              e.State == EntityState.Added
              || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        ((IEntityBase)entityEntry.Entity).Created = DateTime.Now;
                        break;
                    default:
                        break;
                }

            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet <Adress> Adress { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductViewModel> ProductViewModel { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductCategoryUpdateBinding>? ProductCategoryUpdateBinding { get; set; }
        public DbSet<FileStorage> FileStorage { get; set; }
    }
}
