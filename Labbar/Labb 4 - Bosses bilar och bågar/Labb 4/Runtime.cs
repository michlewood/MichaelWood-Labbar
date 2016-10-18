using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4
{
    class Runtime
    {
        VehicleManager vehicleManager = new VehicleManager();
        public void Start()
        {
            MainMenu();
        }

        private void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Menus.MainMenu();

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        vehicleManager.ShowStock();
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:

                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        return;

                    default:
                        break;
                }
            }
        }
    }
}
