using Labb13.Managers;
using Labb13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb13
{
    class Graphics
    {
        public static void PrintTypesList(List<Models.Type> typeList)
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
            Console.WriteLine("1. Show types with low typeness");
            Console.WriteLine("2. Show types with high typeness");
            Console.WriteLine("3. Show types of type 1s");
            Console.WriteLine("4. Return");
        }
    }
}
