using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_4
{
    public class Menus
    {
        static int left = 105;
        static int height = 2;

        public static void MainMenu()
        {
            if (Runtime.MainMenuChoice == 0)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

            }
            Console.WriteLine("Lägg till ny fordons typ");
            Console.ResetColor();
            if (Runtime.MainMenuChoice == 1)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("Ta bort ett fordons typ");
            Console.ResetColor();
            if (Runtime.MainMenuChoice == 2)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("Lägg till fordon");
            Console.ResetColor();
            if (Runtime.MainMenuChoice == 3)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("Ta bort fordon");
            Console.ResetColor();
            if (Runtime.MainMenuChoice == 4)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.WriteLine("Exit");
            Console.ResetColor();
        }

        public static void ShowCurrentMenu(List<Vehicle> currentList)
        {
            Console.Clear();
            Filters();
            Console.WriteLine("Bosses bilar och bågar datorsystem");
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────────────────────────────┐");

            Console.SetCursorPosition(left, height);
            Console.WriteLine("│");

            for (int i = 1; i < currentList.Count; i++)
            {
                Console.SetCursorPosition(left, i + height);
                Console.WriteLine("│");
            }
            Console.SetCursorPosition(0, height);
            if (currentList.Count != 0)
            {
                int index = 1;
                foreach (var vehicle in currentList)
                {
                    Console.WriteLine("│ {1}: {2} {3}. Pris som ny: {4}. Det finns {5} nya och {6} begagnade.",
                                    index, vehicle.GetType().ToString().Substring(7), vehicle.Manufacturer, vehicle.Model, vehicle.Price,
                                    vehicle.NewInStock, vehicle.UsedInStock);
                    index++;
                }
            }
            else Console.WriteLine("│ Listan tom (kolla filterna eller lägg till nya fordontyper) ");

            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
        }

        public static Vehicle ShowCurrentMenuChooser(List<Vehicle> currentList)
        {
            Console.Clear();
            Vehicle vehicleToReturn = new Car();
            Filters();
            Console.WriteLine("Bosses bilar och bågar datorsystem");
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────────────────────────────┐");

            Console.SetCursorPosition(left, height);
            Console.WriteLine("│");

            for (int i = 1; i < currentList.Count; i++)
            {
                Console.SetCursorPosition(left, i+ height);
                Console.WriteLine("│");
            }
            Console.SetCursorPosition(0, height);
            if (currentList.Count != 0)
            {
                int index = 1;
                foreach (var vehicle in currentList)
                {
                    Console.Write("│");
                    if(index == VehicleManager.CurrentMenuChoice + 1)
                    {
                        vehicleToReturn = vehicle;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(" {1}: {2} {3} pris som ny: {4}. Det finns {5} nya och {6} begagnade.",
                                    index, vehicle.GetType().ToString().Substring(7), vehicle.Manufacturer, vehicle.Model, vehicle.Price,
                                    vehicle.NewInStock, vehicle.UsedInStock);
                    Console.ResetColor();
                    index++;
                }
            }
            else Console.WriteLine("│ Listan tom (kolla filterna eller lägg till nya fordontyper) ");

            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────────────┘");
            return vehicleToReturn;
        }

        private static void Filters()
        {
            int left = 110;
            Console.SetCursorPosition(left, height);
            Console.WriteLine("Filter:");
            Console.SetCursorPosition(left, height+1);
            Console.Write("1. Finns i lager ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", VehicleManager.InStockOn == true ? "på" : "av");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(left, height+2);
            Console.Write("2. Bilar ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", VehicleManager.CarOn == true ? "på" : "av");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(left, height+3);
            Console.Write("3. Motorcyklar ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", VehicleManager.MotorcycleOn == true ? "på" : "av");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 0);
        }

        public static void NewOrUsed()
        {
            Console.WriteLine("Är bilen ny eller begagnad?");
            if (VehicleManager.NewOrUsedMenuChoice == 0)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

            }
            Console.WriteLine("Ny");
            Console.ResetColor();
            if (VehicleManager.NewOrUsedMenuChoice == 1)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

            }
            Console.WriteLine("Begagnad");
            Console.ResetColor();
        }
    }
}