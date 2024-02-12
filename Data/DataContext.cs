using HouseFinances.Data.EntitiesConfiguration;
using HouseFinances.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseFinances.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }
        public DbSet<Carrier> Carriers { get; set; }
        public DbSet<CarrierType> CarrierTypes { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<RubricItem> RubricItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ExpenseConfiguration());
            modelBuilder.ApplyConfiguration(new ExpenseTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CarrierConfiguration());
            modelBuilder.ApplyConfiguration(new CarrierTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new RubricItemConfiguration());
        }
    }
}
