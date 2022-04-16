using System;
using ConsoleControleCobranca.Controllers;

namespace ConsoleControleCobranca
{
    class Program
    {
        static void Main(string[] args)
        {
            ChargeClientController controller = new ChargeClientController();
            controller.Menu();
        }
    }
}
