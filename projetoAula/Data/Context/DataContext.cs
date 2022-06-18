using Data.Types;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> DbSetUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}