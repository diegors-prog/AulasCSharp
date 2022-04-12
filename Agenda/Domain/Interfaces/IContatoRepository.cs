using System.Collections.Generic;

namespace Agenda.Domain.Interfaces
{
    public interface IContatoRepository
    {
        Contato GetById(int id);
        List<Contato> GetAll();
        void Save(Contato contato);
        void Delete(Contato contato);
        void Update(Contato contato);
    }
}