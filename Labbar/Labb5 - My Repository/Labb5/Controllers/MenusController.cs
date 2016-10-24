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

        public bool MainMenuChooser(bool loop)
        {
            var input = Console.ReadKey(true).Key;
            MainMenuChoice = MenuChooser(MainMenuChoice, 3, input);
            if(input == ConsoleKey.Enter)
            {
                switch (MainMenuChoice)
                {
                    case 0:
                        Console.Clear();
                        Games();
                        break;
                    case 1:
                        Console.Clear();
                        Books();
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
                UI.PrintMenu("game");
                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        games.CreateGame();
                        break;
                    case ConsoleKey.D2:
                        games.RemoveGame();
                        break;
                    case ConsoleKey.D3:
                        games.PrintGameList();
                        break;
                    case ConsoleKey.D4:
                        games.EditGame();
                        break;
                    case ConsoleKey.D5:
                        loop = false;
                        break;
                }
            }
        }

        private void Books()
        {
            var books = new BooksController();
            var loop = true;

            while (loop)
            {
                UI.PrintMenu("book");
                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        books.CreateBook();
                        break;
                    case ConsoleKey.D2:
                        books.RemoveBook();
                        break;
                    case ConsoleKey.D3:
                        books.PrintBookList();
                        break;
                    case ConsoleKey.D4:
                        books.EditBook();
                        break;
                    case ConsoleKey.D5:
                        loop = false;
                        break;
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
