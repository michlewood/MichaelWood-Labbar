using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb13
{
    class TypeManager
    {
        public List<Type> Types { get; set; }

        public TypeManager()
        {
            Types = new List<Type>
            {
                new Type {Name = "Type1", Typeness = 7, TypeType = Type.TypesOfType.Type1 },
                new Type {Name = "Type2", Typeness = 12, TypeType = Type.TypesOfType.Type2 },
                new Type {Name = "Type3", Typeness = 3, TypeType = Type.TypesOfType.Type1 },
                new Type {Name = "Type4", Typeness = 5, TypeType = Type.TypesOfType.Type3 }
            };
        }

        public void AddType()
        {
            Type newType = new Type();
            Console.WriteLine("Name of type:");
            newType.Name = Console.ReadLine();
            Console.WriteLine("How much Typeness does it have:");
            newType.Typeness = int.Parse(Console.ReadLine());
            
                for (int i = 1; i <= 3; i++)
                {
                    Console.WriteLine("{0}: {1}", i, (Type.TypesOfType)i);
                }
                Console.WriteLine("What type of type:");

            newType.TypeType = (Type.TypesOfType)int.Parse(Console.ReadLine());
            Types.Add(newType);
        }

        public static string PrintType(Type type)
        {
            return string.Format("{0}: typeness: {1}, type of type {2}", type.Name, type.Typeness, type.TypeType);
        }
    }
}
