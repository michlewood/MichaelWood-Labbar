using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb8
{
    class Graphics
    {
        public static void MainMenuGraphics()
        {
            Console.WriteLine("1. Show names of products.");
            Console.WriteLine("2. Show sum of prices with tax.");
            Console.WriteLine("3. Show 90% of sum of prices for products over 1000 kr.");
            Console.WriteLine("4. Exit");
        }
    }
}
