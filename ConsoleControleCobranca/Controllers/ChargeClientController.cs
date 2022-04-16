using System;
using ConsoleControleCobranca.Services;

namespace ConsoleControleCobranca.Controllers
{
    public class ChargeClientController
    {
        ChargeService chargeService = new ChargeService();
        ClientService clientService = new ClientService();

        public void Menu()
        {
            chargeService.ClientService = clientService;
            clientService.ChargeService = chargeService;

            string operador = string.Empty;

            while (operador != "0")
            {
                Console.WriteLine("Digite 1 para adicionar um novo cliente");
                Console.WriteLine("Digite 2 para editar um cliente");
                Console.WriteLine("Digite 3 para listar todos os clientes");
                Console.WriteLine("Digite 4 para remover um cliente");
                Console.WriteLine("Digite 5 criar uma cobrança");
                Console.WriteLine("Digite 6 para listar todas as cobranças");
                Console.WriteLine("Digite 7 para efetuar o pagamento de uma cobrança");
                Console.WriteLine("Digite 0 para sair");

                operador = Console.ReadLine();

                switch (operador)
                {
                    case "0":
                        Environment.Exit(0);
                    break;
                    case "1":
                        Console.WriteLine("Digite o nome do cliente");
                        string clientName = Console.ReadLine().Trim();

                        Console.WriteLine("Digite o telefone do cliente");
                        string phoneNumber = Console.ReadLine().Trim();

                        var retorno = clientService.AddClient(clientName, phoneNumber);
                        Console.WriteLine(retorno);
                        Console.WriteLine("");
                    break;
                        case "2":
                        Console.WriteLine("Escolha o id do cliente a ser editado");
                        var retorno1 = clientService.ShowClients();
                        if (retorno1.Contains("vazia"))
                        {
                            Console.WriteLine(retorno1);
                            Menu();
                        }
                        else
                            Console.WriteLine(retorno1);

                        string clientId = Console.ReadLine();
                        int clientIdInt = Convert.ToInt32(clientId);

                        Console.WriteLine("Digite o novo nome");
                        string newName = Console.ReadLine().Trim();

                        Console.WriteLine("Digite o novo telefone");
                        string newPhoneNumber = Console.ReadLine().Trim();

                        var retorno2 = clientService.EditClient(clientIdInt, newName, newPhoneNumber);
                        Console.WriteLine(retorno2);
                        Console.WriteLine("");
                    break;
                    case "3":
                        var retorno3 = clientService.ShowClients();
                        Console.WriteLine(retorno3);
                        Console.WriteLine("");
                    break;
                    case "4":
                        Console.WriteLine("Escolha o Id do cliente a ser removido");

                        var showClients = clientService.ShowClients();
                        Console.WriteLine(showClients);
                        Console.WriteLine("");

                        var idClient = Console.ReadLine();
                        var idClientInt = Convert.ToInt32(idClient);

                        var retorno4 = clientService.RemoveClient(idClientInt);
                        Console.WriteLine(retorno4);
                        Console.WriteLine("");
                    break;
                    case "5":
                        Console.WriteLine("Digite a data de vencimento");
                        string date = Console.ReadLine().Trim();

                        DateTime dueDate = Convert.ToDateTime(date);

                        Console.WriteLine("Digite o valor da cobrança ");
                        string amount = Console.ReadLine().Trim();

                        double amountCharge = Convert.ToDouble(amount);

                        Console.WriteLine("Escolha o Id do cliente");
                        var showClients2 = clientService.ShowClients();
                        Console.WriteLine(showClients2);
                        Console.WriteLine("");

                        var idClient2 = Console.ReadLine().Trim();
                        var idClientInt2 = Convert.ToInt32(idClient2);

                        var retorno5 = chargeService.AddCharge(dueDate, amountCharge, idClientInt2);
                        Console.WriteLine(retorno5);
                    break;
                    case "6":
                        var showCharges = chargeService.ShowCharges();
                        Console.WriteLine(showCharges);
                    break;
                    case "7":
                        Console.WriteLine("Escolha o Id da cobrança a ser paga");

                        var showCharges2 = chargeService.ShowCharges();
                        Console.WriteLine(showCharges2);
                        Console.WriteLine("");

                        var chargeId = Console.ReadLine();
                        var chargeIdInt = Convert.ToInt32(chargeId);

                        var retorno7 = chargeService.PayCharge(chargeIdInt);
                        Console.WriteLine(retorno7);
                        Console.WriteLine("");
                    break;
                    default:
                        Console.WriteLine("Ação inválida");
                        Menu();
                    break;
                }
            }
        }
    }
}