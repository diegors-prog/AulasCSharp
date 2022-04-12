using System.Text;
using System.Linq;
using AgendaContatos.Data;
using AgendaContatos.Domain;

namespace AgendaContatos.Services
{
    public class ControleAgenda
    {
        private AgendaDeContatos minhaAgenda;

        public ControleAgenda(AgendaDeContatos agenda)
        {
            this.minhaAgenda = agenda;
        }

        public int TamanhoLista()
        {
            var quantidade = minhaAgenda.GetAll().Count;
            return quantidade;
        }
        public string CriarContato(string nome, string telefone)
        {
            int idContato = TamanhoLista() + 1;

            minhaAgenda.Save(new Contato(idContato, nome, telefone));

            return "Contato adicionado com sucesso!";
        }

        public string ListarContatos()
        {
            var builder = new StringBuilder();
            var contatos = minhaAgenda.GetAll();
            var qtdContatos = TamanhoLista();

            if (qtdContatos == 0)
            {
                builder.AppendLine("Lista vazia, para poder editar é necessário possuir contatos cadastrados!");
                return builder.ToString();
            }

            foreach (var item in contatos)
            {
                builder.AppendLine("Id: " + item.Id + " - " + item.Nome + " Número: " + item.Telefone);
            }

            return builder.ToString();
        }

        public string EditarContato(int idContato, string nome, string telefone)
        {
            string retorno;

            if (TamanhoLista().Equals(0))
            {
                retorno = "Lista vazia, para poder editar é necessário possuir contatos cadastrados!";
                return retorno;
            }

            var contato = minhaAgenda.GetById(idContato);

            if (contato == null)
            {
                retorno = "Contato não encontrado!";
                return retorno;
            }

            minhaAgenda.Update(new Contato(idContato, nome, telefone));

            retorno = "Contato editado com sucesso";
            return retorno;
        }

        public string RemoverContato(int idContato)
        {
            string retorno;

            if (TamanhoLista().Equals(0))
            {
                retorno = "Lista vazia, para poder remover é necessário possuir contatos cadastrados!";
                return retorno;
            }

            var contato = minhaAgenda.GetById(idContato);

            if (contato == null)
            {
                retorno = "Não existe um contato com o código " + idContato;
            }

            minhaAgenda.Delete(contato);

            retorno = "Contato excluído com sucesso!";
            return retorno;
        }
    }
}