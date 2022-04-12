using CobrancaControle.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CobrancaControle.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Charge> DbSetCharge { get; set; }
        public DbSet<Client> DbSetClient { get; set; }
    }
}