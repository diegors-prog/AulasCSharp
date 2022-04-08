using Agenda.Domain;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Contato> DbSetContato { get; set; }
    }
}