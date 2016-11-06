using Labb7.DataStores;
using Labb7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb7.Manager
{
    class MenusManager
    {
        public static int MainMenuChoice { get; set; }
        public static int CurrentMenuChoice { get; set; }
        public static int MenuChoice { get; set; }

        public void FiltersMenu(ConsoleKey input, MyLists myLists)
        {
            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Graphics.ElecronicsOn = !Graphics.ElecronicsOn;
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Graphics.ToysOn = !Graphics.ToysOn;
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Graphics.VideoGamesOn = !Graphics.VideoGamesOn;
                    break;
                default:
                    break;
            }
            myLists.UpdateCurrentList();
        }

        public bool MainMenuChooser(MyLists myLists)
        {
            bool loop = true;
            Console.CursorVisible = false;
            Graphics.PrintMainMenu();
            var input = Console.ReadKey(true).Key;
            FiltersMenu(input, myLists);
            MainMenuChoice = MenuChooser(MainMenuChoice, 3, input);
            if (input == ConsoleKey.Enter)
            {
                switch (MainMenuChoice)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Hello");
                        Console.ReadKey(true);
                        MenuChoice = 0;
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Hi");
                        Console.ReadKey(true);
                        MenuChoice = 0;
                        break;
                    case 2:
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
            return loop;
        }

        private int MenuChooser(int menuChoice, int sizeOfMenu, ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    menuChoice--;
                    if (menuChoice < 0) menuChoice = sizeOfMenu - 1;
                    break;
                case ConsoleKey.DownArrow:
                    menuChoice++;
                    if (menuChoice == sizeOfMenu) menuChoice = 0;
                    break;
                default:
                    break;
            }

            return menuChoice;
        }
    }
}
