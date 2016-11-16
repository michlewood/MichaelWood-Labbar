using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb13
{
    class Graphics
    {
        public static void PrintTypesList(List<Type> typeList)
        {
            foreach (var type in typeList)
            {
                Console.WriteLine(TypeManager.PrintType(type));
            }
        }

        public static void MainMenuGraphics()
        {
            Console.WriteLine("1. Add new type");
            Console.WriteLine("2. Filters");
            Console.WriteLine("3. Exit");
        }

        internal static void FiltesMenu()
        {
            Console.WriteLine("1. Filter1");
            Console.WriteLine("2. Filter2");
            Console.WriteLine("3. Filter3");
            Console.WriteLine("4. Return");
        }
    }
}
