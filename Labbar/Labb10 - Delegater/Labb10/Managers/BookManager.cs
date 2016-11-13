using Labb10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb10.Managers
{
    class BookManager
    {
        public List<Book> Books { get; set; }

        #region Delegates
        public delegate bool BookFilter(Book book);

        public bool IsNovel(Book book)
        {
            if (book.Pages > 160) return true;
            else return false;
        }

        public bool IsShortStory(Book book)
        {
            if (book.Pages <= 35) return true;
            else return false;
        }

        public bool IsGenreMystery(Book book)
        {
            if (book.Genre == Book.Genres.Mystery) return true;
            else return false;
        }

        public bool IsGenreFantasy(Book book)
        {
            if (book.Genre == Book.Genres.Fantasy) return true;
            else return false;
        }

        public bool IsGenreRomance(Book book)
        {
            if (book.Genre == Book.Genres.Romance) return true;
            else return false;
        }

        public bool IsCheap(Book book)
        {
            if (book.Price < 45) return true;
            else return false;
        }

        public bool IsExpensive(Book book)
        {
            if (!IsCheap(book)) return true;
            else return false;
        }
        #endregion

        public BookManager()
        {
            Books = new List<Book>
            {
                new Book { Title = "At the Mountains of Madness", Pages = 116, Genre = Book.Genres.Wierd, Price =  50 },
                new Book { Title = "The Hitchhiker's Guide to the Galaxy", Pages = 224, Genre = Book.Genres.Comedy, Price = 15 },
                new Book { Title = "The Murders in the Rue Morgue", Pages = 32, Genre = Book.Genres.Mystery, Price = 40 },
                new Book { Title = "A Wizard of Earthsea", Pages = 308, Genre = Book.Genres.Fantasy, Price = 70 }
            };
        }

        public void FiltersChoice(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    PrintWhere(IsNovel);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    PrintWhere(IsShortStory);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    PrintWhere(IsGenreMystery);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    PrintWhere(IsGenreFantasy);
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    PrintWhere(IsGenreRomance);
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    PrintWhere(IsCheap);
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    PrintWhere(IsExpensive);
                    break;
                default:
                    return;
            }
            Console.ReadKey(true);
        }

        public void PrintWhere(BookFilter filter)
        {
            bool isEmpty = true;
            foreach (var book in Books)
            {
                if (filter(book))
                {
                    Graphics.PrintBook(book);
                    isEmpty = false;
                }
            }
            if (isEmpty)
                Console.WriteLine("No such book");
        }
    }
}
