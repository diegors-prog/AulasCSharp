using System.Collections.Generic;
using Agenda.Domain;
using Agenda.Domain.Interfaces;
using Agenda.ViewModels;

namespace Agenda.Services
{
    public class ContatoService : IContatoService
    {
        private IContatoRepository Contatorepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            this.Contatorepository = contatoRepository;
        }

        public Contato BuscarContato(int id)
        {
            var contato = Contatorepository.GetById(id);
            return contato;
        }

        public List<Contato> BuscarContatos()
        {
            var listaDeContato = Contatorepository.GetAll();
            return listaDeContato;
        }

        public string CriarContato(Contato model)
        {
            Contatorepository.Save(model);
            return "Contato adicionado com sucesso!";
        }

        public bool DeletarContato(int id)
        {
            var contato = Contatorepository.GetById(id);

            if(contato == null)
            {
                return false;
            }
            else
            {
                Contatorepository.Delete(contato);
                return true;
            }
        }

        public bool EditarContato(int id, ContatoUpdateViewModel model)
        {
            var contato = Contatorepository.GetById(id);
            if(contato == null)
            {
                return false;
            }
            else
            {
                contato.Nome = model.Nome;
                contato.Telefone = model.Telefone;

                Contatorepository.Update(contato);
                return true;
            }
        }

        public int TamanhoLista()
        {
            throw new System.NotImplementedException();
        }
    }
}