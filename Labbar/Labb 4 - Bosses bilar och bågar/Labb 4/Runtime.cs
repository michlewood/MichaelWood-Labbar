using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4
{
    class Runtime
    {
        public static int MenuChoice { get; set; }
        VehicleManager vehicleManager = new VehicleManager();


        public void Start()
        {
            if (Console.WindowWidth < 130) Console.SetWindowSize(130, 30);
            vehicleManager.lists.currentList = vehicleManager.lists.VehiclesInStock;
            MainMenu();
        }

        private void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                vehicleManager.UpdateCurrentList();
                Menus.ShowCurrentMenu(vehicleManager.lists.currentList);
                Menus.MainMenu();

                var input = Console.ReadKey(true).Key;
                vehicleManager.FiltersMenu(input);
                switch (input)
                {
                    case ConsoleKey.Enter:
                        Console.Clear();
                        if (MenuChoice == 0) vehicleManager.AddTypeOfVehicle();
                        if (MenuChoice == 1) { vehicleManager.RemoveTypeOfVehicle(); MenuChoice = 0; }
                        if (MenuChoice == 2) { vehicleManager.AddToStock(); MenuChoice = 0; }
                        if (MenuChoice == 3) { vehicleManager.RemoveFromStock(); MenuChoice = 0; }
                        if (MenuChoice == 4) return;
                        break;
                    case ConsoleKey.DownArrow:
                        if (MenuChoice == 4) MenuChoice = 0;
                        else MenuChoice++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (MenuChoice == 0) MenuChoice = 4;
                        else MenuChoice--;
                        break;

                    default:
                        break;
                }
            }
        }   
    }
}
