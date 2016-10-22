using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_4
{
    public class Menus
    {
        static int left = 98;
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

        public static Vehicle ShowCurrentMenu(List<Vehicle> currentList, bool isInteractable = false)
        {
            Console.Clear();
            Vehicle vehicleToReturn = new Car();
            FiltersMenu();
            Console.WriteLine("Bosses bilar och bågar datorsystem");
            Console.Write("┌");
            for (int i = 1; i < left; i++) Console.Write("─");
            Console.WriteLine("┐");

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
                    Console.Write("│");
                    if (index == VehicleManager.CurrentMenuChoice + 1 && isInteractable)
                    {
                        vehicleToReturn = vehicle;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(" ");
                    VehicleManager.ShowSingleVehicle(vehicle);
                    Console.ResetColor();
                    index++;
                }
            }
            else Console.WriteLine("│ Listan tom (kolla filterna eller lägg till nya fordontyper) ");

            Console.Write("└");
            for (int i = 1; i < left; i++) Console.Write("─");
            Console.WriteLine("┘");

            return vehicleToReturn;
        }

        static void FiltersMenu()
        {
            int left = Menus.left + 3;
            Console.SetCursorPosition(left, height);
            Console.Write("Tryck Esc för att återvända till huvudmenyn");
            Console.SetCursorPosition(left, height + 2);
            Console.WriteLine("Filter:");
            Console.SetCursorPosition(left, height + 3);
            Console.Write("1. Finns i lager ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", VehicleManager.InStockOn == true ? "på" : "av");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(left, height + 4);
            Console.Write("2. Bilar ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", VehicleManager.CarOn == true ? "på" : "av");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(left, height + 5);
            Console.Write("3. Motorcyklar ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", VehicleManager.MotorcycleOn == true ? "på" : "av");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 0);
        }

        public static void NewOrUsed()
        {
            Console.WriteLine("Nya eller begagnade?");
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