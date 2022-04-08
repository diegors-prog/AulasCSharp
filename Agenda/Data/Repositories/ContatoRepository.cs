using System.Collections.Generic;
using System.Linq;
using Agenda.Domain;
using Agenda.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Data.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private DataContext Context;

        public ContatoRepository(DataContext context)
        {
            this.Context = context;
        }

        public void Delete(Contato contato)
        {
            Context.DbSetContato.Remove(contato);
        }

        public List<Contato> GetAll()
        {
            return Context.DbSetContato.ToList();
        }

        public Contato GetById(int id)
        {
            return Context.DbSetContato.SingleOrDefault(i => i.Id == id);
        }

        public void Save(Contato contato)
        {
            Context.Add(contato);
            Context.SaveChanges();
        }

        public void Update(Contato contato)
        {
            Context.Entry(contato).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}