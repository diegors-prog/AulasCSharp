using AgendaContatos.Domain;
using Microsoft.EntityFrameworkCore;

namespace AgendaContatos.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseNpgsql("server=localhost; userid=postgres; password=root; port=5432; database=agendacontatos;");
        }

        public DbSet<Contato> contatos { get; set; }
    }
}