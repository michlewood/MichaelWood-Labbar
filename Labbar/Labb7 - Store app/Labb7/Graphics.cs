using Labb7.Manager;
using Labb7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb7
{
    class Graphics
    {
        static int left = 70;
        static int height = 2;
        public static bool ElecronicsOn { get; set; } = true;
        public static bool ToysOn { get; set; } = true;

        public static Product ShowCurrentMenu(List<Product> currentList, bool isInteractable = false)
        {
            
            Console.Clear();
            Product productToReturn = new Electronic();

            FiltersMenu();
            Console.WriteLine("Products");
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
                foreach (var product in currentList)
                {
                    Console.Write("│");
                    if (index == MenusManager.CurrentMenuChoice + 1 && isInteractable)
                    {
                        productToReturn = product;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.Write(" ");
                    ProductManager.PrintSingleProduct(product);
                    Console.ResetColor();
                    index++;
                }
            }
            else Console.WriteLine("│ Listan tom (kolla filterna eller lägg till nya fordontyper) ");

            Console.Write("└");
            for (int i = 1; i < left; i++) Console.Write("─");
            Console.WriteLine("┘");

            return productToReturn;
        }

        static void FiltersMenu()
        {
            int left = Graphics.left + 3;
            int row = 0;
            Console.SetCursorPosition(left, height + row++);
            Console.Write("Tryck Esc för att återvända till huvudmenyn");
            row++;

            Console.SetCursorPosition(left, height + (row++));
            Console.WriteLine("Filter:");
            Console.SetCursorPosition(left, height + row++);
            Console.Write("1. Electronics ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", Graphics.ElecronicsOn == true ? "på" : "av");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(left, height + row++);
            Console.Write("2. Toys ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", Graphics.ToysOn == true ? "på" : "av");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(0, 0);
        }

        public static void PrintMainMenu()
        {
            CheckChoice(MenusManager.MainMenuChoice, 0);
            Console.WriteLine("Games");
            Console.ResetColor();

            CheckChoice(MenusManager.MainMenuChoice, 1);
            Console.WriteLine("Books");
            Console.ResetColor();

            CheckChoice(MenusManager.MainMenuChoice, 2);
            Console.WriteLine("Exit");
            Console.ResetColor();
        }

        private static void CheckChoice(int MenuChoice, int numberToFind)
        {
            if (MenuChoice == numberToFind)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
        }
    }
}
