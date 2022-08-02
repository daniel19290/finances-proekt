using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TransactionAPI.Database.Entities;




namespace TransactionAPI.Database
{
    public class CategoriesDbContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }

        public CategoriesDbContext()
        {

        }

        public CategoriesDbContext(DbContextOptions<CategoriesDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}