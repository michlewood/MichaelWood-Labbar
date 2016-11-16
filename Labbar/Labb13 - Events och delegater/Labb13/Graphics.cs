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
    }
}
