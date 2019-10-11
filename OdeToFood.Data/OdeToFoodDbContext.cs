using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }

    public class OdeToFoodDbContextFactory : IDesignTimeDbContextFactory<OdeToFoodDbContext>
    {
        public OdeToFoodDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<OdeToFoodDbContext>();
            optionBuilder.UseSqlServer("Data Source=.;Initial Catalog=OdeToFood;Integrated Security=True;");
            return new OdeToFoodDbContext(optionBuilder.Options);
        }
    }
}
