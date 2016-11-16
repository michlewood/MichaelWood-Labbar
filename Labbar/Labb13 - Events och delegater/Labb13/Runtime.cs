using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb13
{
    class Runtime
    {
        TypeManager typeManager = new TypeManager();

        public void Start()
        {
            ProgramLoop();
        }

        private void ProgramLoop()
        {
            while (true)
            {
                Console.Clear();
                Graphics.PrintTypesList(typeManager.Types);
                Console.WriteLine("-------");
                Graphics.MainMenuGraphics();
                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        typeManager.AddType();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        Filters();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        return;
                }
            }
        }

        private void Filters()
        {
            while (true)
            {
                Console.Clear();
                Graphics.PrintTypesList(typeManager.Types);
                Console.WriteLine("-------");
                Graphics.FiltesMenu();
                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        return;
                }
            }
        }
    }
}
