using System.Collections.Generic;
using System.Linq;
using AgendaContatos.Domain;
using Microsoft.EntityFrameworkCore;

namespace AgendaContatos.Data
{
    public class AgendaDeContatos
    {
        private DataContext Context;

        public AgendaDeContatos()
        {

        }
        public AgendaDeContatos(DataContext context)
        {
            this.Context = context;
        }

        public List<Contato> GetAll()
        {
            return Context.contatos.ToList();
        }

        public void Save(Contato contato)
        {
            Context.Add(contato);
            Context.SaveChanges();
        }

        public Contato GetById(int idContato)
        {
            return Context.contatos.SingleOrDefault(i => i.Id == idContato);
        }

        public void Update(Contato contato)
        {
            Context.Entry(contato).State = EntityState.Modified;
        }

        public void Delete(Contato contato)
        {
            Context.contatos.Remove(contato);
        }
    }
}