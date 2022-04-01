using AgendaContatos.Services;
using System;

namespace AgendaContatos.Controllers
{
    public class MenuAgenda
    {
        ControleAgenda controle = new ControleAgenda();

        public void Menu()
        {
            string operador = string.Empty;

            while(operador != "0") 
            {
                Console.WriteLine("Digite 1 para add um novo contato");
                Console.WriteLine("Digite 2 para editar um contato");
                Console.WriteLine("Digite 3 para listar todos contatos");
                Console.WriteLine("Digite 4 para listar somente os contatos ativos");
                Console.WriteLine("Digite 5 para desativar um contato");
                Console.WriteLine("Digite 6 para remover um contato");
                Console.WriteLine("Digite 0 para sair da aplicação");

                operador = Console.ReadLine();

                switch (operador)
                {
                    case "0":
                        Environment.Exit(0);
                    break;
                    
                    case "1":
                        Console.WriteLine("Digite o nome do contato");
                        string nome = Console.ReadLine().Trim();

                        Console.WriteLine("Digite o telefone do contato");
                        string telefone = Console.ReadLine().Trim();

                        var retorno = controle.CriarContato(nome, telefone);
                        Console.WriteLine(retorno);
                        Console.WriteLine("");
                    break;

                    case "2":
                        Console.WriteLine("Escolha o id do usuário a ser editado");
                        var contatos = controle.ListarContatos();
                        if (contatos.Contains("vazia"))
                        {
                            Console.WriteLine(contatos);
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine(contatos);
                        }
                        
                        string idContato = Console.ReadLine();
                        int idContatoInt = Convert.ToInt32(idContato);

                        Console.WriteLine("Digite o novo nome");
                        string novoNome = Console.ReadLine().Trim();

                        Console.WriteLine("Digite o novo telefone");
                        string novoTelefone = Console.ReadLine().Trim();

                        var retorno2 = controle.EditarContato(idContatoInt, novoNome, novoTelefone);
                        Console.WriteLine(retorno2);
                        Console.WriteLine("");
                    break;

                    case "3":
                        var retorno3 = controle.ListarContatos();
                        Console.WriteLine(retorno3);
                    break;

                    case "4":
                        var retorno4 = controle.ListarContatosAtivos();
                        Console.WriteLine(retorno4);
                    break;

                    case "5":
                        Console.WriteLine("Escolha o id do usuário a ser desativado");
                        var contatosAtivos = controle.ListarContatosAtivos();
                        if (contatosAtivos.Contains("vazia"))
                        {
                            Console.WriteLine(contatosAtivos);
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine(contatosAtivos);
                        }

                        int idContatoDesativar = int.Parse(Console.ReadLine());

                        var retorno5 = controle.DesativarContato(idContatoDesativar);

                        if (retorno5)
                        {
                            Console.WriteLine("Contato desativado com sucesso");
                        }
                        else
                        {
                            Console.WriteLine("Não existe um contato com o código " + idContatoDesativar);
                        }
                    break;

                    case "6":
                        Console.WriteLine("Escolha o id do usuário a ser removido");
                        var todosContatos = controle.ListarContatos();
                        if (todosContatos.Contains("vazia"))
                        {
                            Console.WriteLine(todosContatos);
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine(todosContatos);
                        }

                        string idContatoRemover = Console.ReadLine();
                        int idContatoRemoverInt = Convert.ToInt32(idContatoRemover);

                        var retorno6 = controle.RemoverContato(idContatoRemoverInt);
                        Console.WriteLine(retorno6);
                    break;
                    
                    default:
                        Console.WriteLine("Opção inválida");
                        Menu();
                    break;
                }
            }    
        }
    }
}