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
        TypeFilter[] filters = { TypeFilters.LowTypeness, TypeFilters.HighTypeness, TypeFilters.IsTypeType1, null};

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

                #region Method1
                //switch (input)
                //{
                //    case ConsoleKey.D1:
                //    case ConsoleKey.NumPad1:
                //        filter = TypeFilters.LowTypeness;
                //        break;
                //    case ConsoleKey.D2:
                //    case ConsoleKey.NumPad2:
                //        filter = TypeFilters.HighTypeness;
                //        break;
                //    case ConsoleKey.D3:
                //    case ConsoleKey.NumPad3:
                //        filter = TypeFilters.IsTypeType1;
                //        break;
                //    case ConsoleKey.D4:
                //    case ConsoleKey.NumPad4:
                //        return;
                //}

                //if (filter != null)
                //{
                //    Console.Clear();
                //    var filteredtypes = typeManager.Types.Where(type => filter(type)).ToList();
                //    Graphics.PrintTypesList(filteredtypes);
                //    filter = null;
                //    Console.ReadKey(true);
                //}
                #endregion

                #region Method2
                int number = 0;
                if (int.TryParse(input.ToString()[input.ToString().Length - 1].ToString(), out number) && (input.ToString()[0] == 'D' || input.ToString()[0] == 'N') && number <= filters.Length)
                {
                    if (filters[number - 1] == null) return;
                    Console.Clear();
                    var filteredtypes = typeManager.Types.Where(type => filters[number - 1](type)).ToList();
                    Graphics.PrintTypesList(filteredtypes);
                    filter = filters[number - 1];
                    filter = null;
                    Console.ReadKey(true);
                }
                #endregion
            }
        }
    }
}
