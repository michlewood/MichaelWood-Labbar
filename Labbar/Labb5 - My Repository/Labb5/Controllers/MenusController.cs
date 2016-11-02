using Labb5.DataStores.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb5.Controllers
{
    class MenusController
    {
        public static int MainMenuChoice { get; set; }
        public static int MenuChoice { get; set; }

        public bool MainMenuChooser(bool loop)
        {
            Graphics.PrintMainMenu();
            var input = Console.ReadKey(true).Key;
            MainMenuChoice = MenuChooser(MainMenuChoice, 3, input);
            if(input == ConsoleKey.Enter)
            {
                switch (MainMenuChoice)
                {
                    case 0:
                        Console.Clear();
                        Games();
                        MenuChoice = 0;
                        break;
                    case 1:
                        Console.Clear();
                        Books();
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

        private void Games()
        {
            var games = new GamesController();
            var loop = true;

            while (loop)
            {
                Graphics.PrintMenu("game");
                var input = Console.ReadKey(true).Key;
                MenuChoice = MenuChooser(MenuChoice, 5, input);
                if (input == ConsoleKey.Enter)
                {
                    switch (MenuChoice)
                    {
                        case 0:
                            games.CreateGame();
                            break;
                        case 1:
                            games.RemoveGame();
                            break;
                        case 2:
                            games.PrintGameList();
                            break;
                        case 3:
                            games.EditGame();
                            break;
                        case 4:
                            loop = false;
                            break;
                    }
                }
            }
        }

        private void Books()
        {
            var books = new BooksController();
            var loop = true;

            while (loop)
            {
                Graphics.PrintMenu("book");
                var input = Console.ReadKey(true).Key;
                MenuChoice = MenuChooser(MenuChoice, 5, input);
                if (input == ConsoleKey.Enter)
                {
                    switch (MenuChoice)
                    {
                        case 0:
                            books.CreateBook();
                            break;
                        case 1:
                            books.RemoveBook();
                            break;
                        case 2:
                            books.PrintBookList();
                            break;
                        case 3:
                            books.EditBook();
                            break;
                        case 4:
                            loop = false;
                            break;
                    }
                }
            }
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
