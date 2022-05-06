using Microsoft.EntityFrameworkCore;
using WebApi.Data.Mappings;
using WebApi.Domain.Entities;

namespace WebApi.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Charge> DbSetCharge { get; set; }
        public DbSet<Customer> DbSetCustomer { get; set; }
        public DbSet<User> DbSetUser { get; set; }
        public DbSet<Role> DbSetRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChargeMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
        }
    }
}
