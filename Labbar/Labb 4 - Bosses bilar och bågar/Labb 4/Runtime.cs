using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4
{
    class Runtime
    {
        public static int MainMenuChoice { get; set; }
        VehicleManager vehicleManager = new VehicleManager();


        public void Start()
        {
            if (Console.WindowWidth < 146) Console.SetWindowSize(146, 30);
            vehicleManager.lists.currentList = vehicleManager.lists.VehiclesInStock;
            MainMenu();
        }

        private void MainMenu()
        {
            while (true)
            {
                vehicleManager.UpdateCurrentList();
                Menus.ShowCurrentMenu(vehicleManager.lists.currentList);
                Menus.MainMenu();
                Console.CursorVisible = false;
                var input = Console.ReadKey(true).Key;
                vehicleManager.FiltersMenu(input);
                switch (input)
                {
                    case ConsoleKey.Enter:
                        Console.Clear();
                        if (MainMenuChoice == 0) vehicleManager.AddTypeOfVehicle();
                        if (MainMenuChoice == 1) { vehicleManager.RemoveTypeOfVehicle(); MainMenuChoice = 0; }
                        if (MainMenuChoice == 2) { vehicleManager.EditStock(true); MainMenuChoice = 0; }
                        if (MainMenuChoice == 3) { vehicleManager.EditStock(false); MainMenuChoice = 0; }
                        if (MainMenuChoice == 4) return;
                        break;
                    case ConsoleKey.DownArrow:
                        if (MainMenuChoice == 4) MainMenuChoice = 0;
                        else MainMenuChoice++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (MainMenuChoice == 0) MainMenuChoice = 4;
                        else MainMenuChoice--;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
