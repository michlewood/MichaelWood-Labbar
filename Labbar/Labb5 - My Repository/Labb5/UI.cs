using Labb5.Controllers;
using Labb5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Labb5
{
    class UI
    {
        public static void PrintMainMenu()
        {
            CheckChoice(MenusController.MainMenuChoice, 0);
            Console.WriteLine("Games");
            Console.ResetColor();

            CheckChoice(MenusController.MainMenuChoice, 1);
            Console.WriteLine("Books");
            Console.ResetColor();

            CheckChoice(MenusController.MainMenuChoice, 2);
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

        public static void PrintMenu(string ord)
        {
            Console.Clear();
            CheckChoice(MenusController.MenuChoice, 0);
            Console.WriteLine("Add {0}", ord);
            Console.ResetColor();
            CheckChoice(MenusController.MenuChoice, 1);
            Console.WriteLine("Remove {0}", ord);
            Console.ResetColor();
            CheckChoice(MenusController.MenuChoice, 2);
            Console.WriteLine("Show all {0}s", ord);
            Console.ResetColor();
            CheckChoice(MenusController.MenuChoice, 3);
            Console.WriteLine("Edit {0}", ord);
            Console.ResetColor();
            CheckChoice(MenusController.MenuChoice, 4);
            Console.WriteLine("Return");
            Console.ResetColor();
        }

        public static Game CreateGame()
        {
            Game newGame = new Game();
            Console.Clear();
            Console.Write("game name: ");
            newGame.Name = Console.ReadLine();

            Console.WriteLine("Game genres:");
            PrintGameGenres();
            Console.Write("Choose a genre: ");
            int choice = int.Parse(Console.ReadLine());
            newGame.Genre = (Game.GenreType)choice;

            return newGame;
        }

        public static Book CreateBook()
        {
            Book newBook = new Book();
            Console.Clear();
            Console.Write("book name: ");
            newBook.Name = Console.ReadLine();

            Console.WriteLine("Book genres:");
            PrintBookGenres();
            Console.Write("Choose a genre: ");
            int choice = int.Parse(Console.ReadLine());
            newBook.Genre = (Book.GenreType)choice;

            return newBook;
        }

        public static void EditGame(Game game)
        {
            Console.Clear();
            Console.WriteLine("1. Change name");
            Console.WriteLine("2. Change genre");
            Console.Write("Choice: ");
            var choice = Console.ReadKey(true).Key;

            Console.Clear();
            Console.WriteLine("Game: {0}. Genre: {1}", game.Name, game.Genre);

            switch (choice)
            {
                case ConsoleKey.D1:
                    Console.Write("New name: ");
                    game.Name = Console.ReadLine();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Genre list:");
                    PrintGameGenres();
                    Console.WriteLine("New genre: ");
                    game.Genre = (Game.GenreType)int.Parse(Console.ReadLine());
                    break;
                default:
                    break;
            }
        }

        public static void EditBook(Book book)
        {
            Console.Clear();
            Console.WriteLine("1. Change name");
            Console.WriteLine("2. Change genre");
            Console.Write("Choice: ");
            var choice = Console.ReadKey(true).Key;

            Console.Clear();
            Console.WriteLine("Game: {0}. Genre: {1}", book.Name, book.Genre);

            switch (choice)
            {
                case ConsoleKey.D1:
                    Console.Write("New name: ");
                    book.Name = Console.ReadLine();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Genre list:");
                    PrintBookGenres();
                    Console.WriteLine("New genre: ");
                    book.Genre = (Book.GenreType)int.Parse(Console.ReadLine());
                    break;
                default:
                    break;
            }
        }

        public static int SelectGame(Game[] games)
        {
            PrintGameList(games);
            Console.Write("Select game: ");
            return int.Parse(Console.ReadLine());
        }

        public static int SelectBook(Book[] books)
        {
            PrintBookList(books);
            Console.Write("Select book: ");
            return int.Parse(Console.ReadLine());
        }

        public static void PrintGameGenres()
        {
            foreach (var genre in Enum.GetValues(typeof(Game.GenreType)))
            {
                Console.WriteLine("{0}, {1}", (int)genre, genre);
            }
        }

        public static void PrintBookGenres()
        {
            foreach (var genre in Enum.GetValues(typeof(Book.GenreType)))
            {
                Console.WriteLine("{0}, {1}", (int)genre, genre);
            }
        }

        public static void PrintGameList(Game[] games)
        {
            Console.Clear();

            foreach (var game in games)
            {
                Console.WriteLine("{0}. Game: {1}, Genre: {2}",
                    Array.IndexOf(games, game) + 1,
                    game.Name,
                    game.Genre);
            }
        }

        public static void PrintBookList(Book[] books)
        {
            Console.Clear();
            foreach (var book in books)
            {
                Console.WriteLine("{0}. Book: {1}, Genre: {2}",
                    Array.IndexOf(books, book) + 1,
                    book.Name,
                    book.Genre);
            }
        }
    }
}
