using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb13.Models;

namespace Labb13.Managers
{
    class TypeManager
    {
        public event PrintMessage WrongInput;
        public List<Models.Type> Types { get; set; }

        public TypeManager()
        {
            WrongInput = new PrintMessage(WrongInputErrorMessage);
            Types = new List<Models.Type>
            {
                new Models.Type {Name = "Type1", Typeness = 7, TypeType = Models.Type.TypesOfType.Type1 },
                new Models.Type {Name = "Type2", Typeness = 12, TypeType = Models.Type.TypesOfType.Type2 },
                new Models.Type {Name = "Type3", Typeness = 3, TypeType = Models.Type.TypesOfType.Type1 },
                new Models.Type {Name = "Type4", Typeness = 5, TypeType = Models.Type.TypesOfType.Type3 }
            };
        }

        private void WrongInputErrorMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey(true);
        }

        public void AddType()
        {
            Models.Type newType = new Models.Type();
            Console.WriteLine("Name of type:");
            newType.Name = Console.ReadLine();
            bool validInput = false;
            int input = 0;
            while (!validInput)
            {
                Console.Clear();
                Console.WriteLine("How much Typeness does it have:");
                 validInput = int.TryParse(Console.ReadLine(), out input);
                if (!validInput) WrongInput("Please enter a number.");
            }
            newType.Typeness = input;
            validInput = false;
            int numberofTypes = 3;
            while (!validInput)
            {
                Console.Clear();
                for (int i = 1; i <= numberofTypes; i++)
                {
                    Console.WriteLine("{0}: {1}", i, (Models.Type.TypesOfType)i);
                }
                Console.WriteLine("What type of type:");

                 validInput = int.TryParse(Console.ReadLine(), out input);
                if (!validInput || 0 >= input || input > numberofTypes)
                {
                    validInput = false;
                    WrongInput(string.Format("Please enter a number between 1 and {0}.", numberofTypes));
                }
            }
            newType.TypeType = (Models.Type.TypesOfType)input;
            Types.Add(newType);
        }

        public static string PrintType(Models.Type type)
        {
            return string.Format("{0}: typeness: {1}, type of type {2}", type.Name, type.Typeness, type.TypeType);
        }

        
    }
}
