
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infastrucure.Data
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options):base(options) 
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var EntityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properities = EntityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in properities)
                    {
                        modelBuilder.Entity(EntityType.Name).Property(property.Name).HasConversion<double>();
                    }

                }
            }
        }

    }
}
