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

        public static bool CarOn { get; private set; } = true;
        public static bool MotorcycleOn { get; private set; } = true;

        public void Start()
        {
            vehicleManager.lists.currentList = vehicleManager.lists.VehiclesInStock;
            MainMenu();
        }

        private void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Menus.Filters();
                Menus.ShowCurrentMenu(vehicleManager.lists.currentList);
                Menus.MainMenu();

                var input = Console.ReadKey(true).Key;
                FiltersMenu(input);
                switch (input)
                {
                    case ConsoleKey.N:
                        Console.Clear();
                        vehicleManager.AddTypeOfVehicle();
                        break;
                    case ConsoleKey.T:
                        Console.Clear();
                        vehicleManager.RemoveTypeOfVehicle();
                        break;
                    case ConsoleKey.F:
                        Console.Clear();
                        vehicleManager.AddToStock();
                        break;
                    case ConsoleKey.B:
                        Console.Clear();
                        vehicleManager.RemoveFromStock();
                        break;
                    case ConsoleKey.E:
                        return;

                    default:
                        break;
                }
            }
        }

        private void FiltersMenu(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    CarOn = !CarOn;
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    MotorcycleOn = !MotorcycleOn;
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:

                    break;

                default:
                    break;
            }
            vehicleManager.lists.currentList = vehicleManager.lists.VehiclesInStock;
            if(!CarOn) vehicleManager.lists.currentList = vehicleManager.lists.currentList
                        .Where(vehicle => vehicle.GetType().ToString() != "Labb_4.Car").ToList();
            if (!MotorcycleOn) vehicleManager.lists.currentList = vehicleManager.lists.currentList
                          .Where(vehicle => vehicle.GetType().ToString() != "Labb_4.Motorcycle").ToList();
        }
    }
}
