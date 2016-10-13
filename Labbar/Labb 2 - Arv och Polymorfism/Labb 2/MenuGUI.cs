using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    class MenuGUI
    {
        static public void MainMenuGUI()
        {
            Console.WriteLine("Choose one: ");
            Console.WriteLine("1. All animals");
            Console.WriteLine("2. Mammals");
            Console.WriteLine("3. Reptiles");
            Console.WriteLine("4. Birds");
            Console.WriteLine("5. Exit");
        }

        static public void FamilyMenuGUI(string typeOfAnimal)
        {
            Console.WriteLine(typeOfAnimal);
            Console.WriteLine("1. Show info");
            Console.WriteLine("2. Add New");
            Console.WriteLine("3. Remove");
            Console.WriteLine("4. Return");
        }

        static public void SpeciesMenuGUI(string typeOfAnimal)
        {
            Console.WriteLine(typeOfAnimal);
            Console.WriteLine("1. Show info");
            Console.WriteLine("2. Add new");
            Console.WriteLine("3. Remove");
            Console.WriteLine("4. Return");
        }
    }
}
