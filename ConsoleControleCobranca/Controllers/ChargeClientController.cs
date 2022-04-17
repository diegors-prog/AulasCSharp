using System;
using ConsoleControleCobranca.Interfaces;

namespace ConsoleControleCobranca.Controllers
{
    public class ChargeClientController
    {
        private IChargeService _chargeService;
        private IClientService _clientService;

        public ChargeClientController(
            IChargeService chargeService,
            IClientService clientService)
        {
            this._chargeService = chargeService;
            this._clientService = clientService;
        }

        public void Menu()
        {
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

                        var retorno = _clientService.AddClient(clientName, phoneNumber);
                        Console.WriteLine(retorno);
                        Console.WriteLine("");
                    break;
                        case "2":
                        Console.WriteLine("Escolha o id do cliente a ser editado");
                        var retorno1 = _clientService.ShowClients();
                        if (retorno1.Contains("vazia"))
                        {
                            Console.WriteLine(retorno1 + ", adicione o primeiro cliente!");
                            Console.WriteLine("");
                            Menu();
                        }
                        else
                            Console.WriteLine(retorno1);

                        string clientId = Console.ReadLine().Trim();
                        int clientIdInt = Convert.ToInt32(clientId);

                        Console.WriteLine("Digite o novo nome");
                        string newName = Console.ReadLine().Trim();

                        Console.WriteLine("Digite o novo telefone");
                        string newPhoneNumber = Console.ReadLine().Trim();

                        var retorno2 = _clientService.EditClient(clientIdInt, newName, newPhoneNumber);
                        Console.WriteLine(retorno2);
                        Console.WriteLine("");
                    break;
                    case "3":
                        var retorno3 = _clientService.ShowClients();
                        Console.WriteLine(retorno3);
                        Console.WriteLine("");
                    break;
                    case "4":
                        Console.WriteLine("Escolha o Id do cliente a ser removido");

                        var showClients = _clientService.ShowClients();

                        if (showClients.Contains("vazia"))
                        {
                            Console.WriteLine(showClients);
                            Console.WriteLine("");
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine(showClients);
                            Console.WriteLine("");
                        }

                        var idClient = Console.ReadLine().Trim();
                        var idClientInt = Convert.ToInt32(idClient);

                        var retorno4 = _clientService.RemoveClient(idClientInt);
                        Console.WriteLine(retorno4);
                        Console.WriteLine("");
                    break;
                    case "5":
                        Console.WriteLine("Escolha o Id do cliente");
                        var showClients2 = _clientService.ShowClients();

                        if (showClients2.Contains("vazia"))
                        {
                            Console.WriteLine("É preciso ter clientes na base de dados para adicionar uma nova cobranca!");
                            Console.WriteLine("");
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine(showClients2);
                            Console.WriteLine("");
                        }

                        var idClient2 = Console.ReadLine().Trim();
                        var idClientInt2 = Convert.ToInt32(idClient2);

                        Console.WriteLine("Digite a data de vencimento");
                        string date = Console.ReadLine().Trim();

                        DateTime dueDate = Convert.ToDateTime(date);

                        Console.WriteLine("Digite o valor da cobrança ");
                        string amount = Console.ReadLine().Trim();

                        double amountCharge = Convert.ToDouble(amount);

                        var retorno5 = _chargeService.AddCharge(dueDate, amountCharge, idClientInt2);
                        Console.WriteLine(retorno5);
                    break;
                    case "6":
                        var showCharges = _chargeService.ShowCharges();
                        Console.WriteLine(showCharges);
                        Console.WriteLine("");
                    break;
                    case "7":
                        Console.WriteLine("Escolha o Id da cobrança a ser paga");

                        var showCharges2 = _chargeService.ShowCharges();

                        if (showCharges2.Contains("vazia"))
                        {
                            Console.WriteLine("Não existem cobranças na base de dados");
                            Console.WriteLine("");
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine(showCharges2);
                            Console.WriteLine("");
                        }

                        var chargeId = Console.ReadLine().Trim();
                        var chargeIdInt = Convert.ToInt32(chargeId);

                        var retorno7 = _chargeService.PayCharge(chargeIdInt);
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