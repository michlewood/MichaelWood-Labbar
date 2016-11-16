using Labb13.Filters;
using Labb13.Managers;
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
        TypeFilter filter;

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
                        filter = TypeFilters.LowTypeness;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        filter = TypeFilters.HighTypeness;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        filter = TypeFilters.IsTypeType1;
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        return;
                }
                Console.Clear();
                var filteredtypes = typeManager.Types.Where(type => filter(type)).ToList();
                Graphics.PrintTypesList(filteredtypes);
                Console.ReadKey(true);
            }
        }
    }
}
