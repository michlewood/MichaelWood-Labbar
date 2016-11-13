using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb10.Models;

namespace Labb10
{
    class Graphics
    {
        public static void FiltersGraphics()
        {
            Console.WriteLine("Choose a Filter to apply");
            Console.WriteLine("1. Novels");
            Console.WriteLine("2. Short Stories");
            Console.WriteLine("3. Mysteries");
            Console.WriteLine("4. Fantasy");
            Console.WriteLine("5. Romance");
            Console.WriteLine("6. Only cheap books");
            Console.WriteLine("7. Only expensive books");
            Console.WriteLine("8. Exit");
        }

        public static void BookList(List<Book> books)
        {
            foreach (var book in books)
            {
                PrintBook(book);
            }
        }

        public static void PrintBook(Book book)
        {
            Console.WriteLine("{0}: {1} Pages long, Genre :{2}, Price: {3} kr", book.Title, book.Pages, book.Genre, book.Price);
        }
    }
}
