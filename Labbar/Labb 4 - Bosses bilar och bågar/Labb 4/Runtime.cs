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

        public static bool InStockOn { get; private set; }
        public static bool CarOn { get; private set; } = true;
        public static bool MotorcycleOn { get; private set; } = true;

        public void Start()
        {
            if(Console.WindowWidth < 130) Console.SetWindowSize(130, 30);
            vehicleManager.lists.currentList = vehicleManager.lists.VehiclesInStock;
            MainMenu();
        }

        private void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                UpdateCurrentList();
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
                    InStockOn = !InStockOn;
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    CarOn = !CarOn;
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    MotorcycleOn = !MotorcycleOn;
                    break;

                default:
                    break;
            }
            UpdateCurrentList();
            
        }

        private void UpdateCurrentList()
        {
            vehicleManager.lists.VehiclesInStock = vehicleManager.lists.VehiclesInStock.OrderBy(vehicle => vehicle.GetType().ToString()).ToList();
            vehicleManager.lists.currentList = vehicleManager.lists.VehiclesInStock;
            if (InStockOn) vehicleManager.lists.currentList = vehicleManager.lists.currentList
                         .Where(vehicle => (vehicle.NewInStock != 0 || vehicle.UsedInStock != 0)
                         || !InStockOn).ToList();
            if (!CarOn) vehicleManager.lists.currentList = vehicleManager.lists.currentList
                        .Where(vehicle => vehicle.GetType().ToString() != "Labb_4.Car").ToList();
            if (!MotorcycleOn) vehicleManager.lists.currentList = vehicleManager.lists.currentList
                        .Where(vehicle => vehicle.GetType().ToString() != "Labb_4.Motorcycle").ToList();
        }
    }
}
