using Labb10.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb10
{
    class Runtime
    {
        BookManager bookManager = new BookManager();

        public void Start()
        {
            Loop();
        }

        private void Loop()
        {
            while (true)
            {
                Console.Clear();
                Graphics.BookList(bookManager.Books);
                Console.WriteLine("---------");
                Graphics.FiltersGraphics();
                var input = Console.ReadKey(true).Key;

                if (input == ConsoleKey.D8 || input == ConsoleKey.NumPad8)
                    return;

                FiltersInput(input);
            }
        }

        private void FiltersInput(ConsoleKey input)
        {
            Console.Clear();
            bookManager.FiltersChoice(input);
            Console.ReadKey(true);
        }
    }
}
