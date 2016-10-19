using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_4
{
    public class Menus
    {
        public static void MainMenu()
        {
            Console.WriteLine("Välkomen till Bosses bilar och bågar!");
            Console.WriteLine("Vad vill du göra?");
            Console.WriteLine("Lägg till (n)ytt fordons typ");
            Console.WriteLine("(T)a bort ett fordons typ");
            Console.WriteLine("Lägg till (f)ordon");
            Console.WriteLine("Ta (b)ort fordon");
            Console.WriteLine("(E)xit");
        }

        public static void ShowCurrentMenu(List<Vehicle> currentList)
        {
            Filters();

            Console.SetCursorPosition(93, 0);
            Console.WriteLine("|");

            for (int i = 1; i < currentList.Count; i++)
            {
                Console.SetCursorPosition(93, i);
                Console.WriteLine("|");
            }
            Console.SetCursorPosition(0, 0);
            if (currentList.Count != 0)
            {
                int index = 1;
                foreach (var vehicle in currentList)
                {
                        Console.WriteLine("{0}. {1}: {2} {3} price: {4}. Det finns {5} nya och {6} begagnade.",
                                        index, vehicle.GetType().ToString().Substring(7), vehicle.Manufacturer, vehicle.Model, vehicle.Price,
                                        vehicle.NewInStock, vehicle.UsedInStock);
                        index++;
                }
            }
            else Console.WriteLine("Listan tom (kolla filterna)");

            Console.WriteLine("----------------------------------------------------------------------------------------------");
        }

        private static void Filters()
        {
            Console.SetCursorPosition(95, 0);
            Console.WriteLine("Filter:");
            Console.SetCursorPosition(95, 1);
            Console.Write("1. Finns i lager ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", Runtime.InStockOn == true ? "på" : "av");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(95, 2);
            Console.Write("2. Bilar ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", Runtime.CarOn == true ? "på" : "av");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(95, 3);
            Console.Write("3. Motorcyklar ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", Runtime.MotorcycleOn == true ? "på" : "av");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 0);

        }
    }
}