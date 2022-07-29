using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TransactionAPI.Database.Entities;




namespace TransactionAPI.Database
{
    public class TransactionsDbContext : DbContext
    {
        public DbSet<TransactionEntity> Transactions { get; set; }

        public TransactionsDbContext()
        {

        }

        public TransactionsDbContext(DbContextOptions<TransactionsDbContext> options): base(options)
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