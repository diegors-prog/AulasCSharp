using System.Collections.Generic;
using Agenda.ViewModels;

namespace Agenda.Domain.Interfaces
{
    public interface IContatoService
    {
         int TamanhoLista();
         string CriarContato(Contato model);
         List<Contato> BuscarContatos();
         bool EditarContato(int id, ContatoUpdateViewModel model);
         bool DeletarContato(int id);
         Contato BuscarContato(int id);
    }
}