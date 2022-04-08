using System.Collections.Generic;

namespace Agenda.Domain.Interfaces
{
    public interface IContatoRepository
    {
        List<Contato> GetAll();
        Contato GetById(int id);
        void Save(Contato contato);
        void Update(Contato contato);
        void Delete(Contato contato);
    }
}