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
            Console.WriteLine("{0}s", typeOfAnimal);
            Console.WriteLine("1. Show info");
            Console.WriteLine("2. Add New");
            Console.WriteLine("3. Remove");
            Console.WriteLine("4. Return");
        }

        static public void SpeciesMenuGUI(string typeOfAnimal)
        {
            Console.WriteLine("{0}s", typeOfAnimal);
            Console.WriteLine("1. Show info");
            Console.WriteLine("2. Add new");
            Console.WriteLine("3. Remove");
            Console.WriteLine("4. Return");
        }

        static public void FamilyMenuChooserGUI(string typeOfAnimal)
        {
            int subTypeNr = 2;
            string subTypeName = "" ;
            Console.WriteLine("{0}s", typeOfAnimal);
            Console.WriteLine("1. All {0}s", typeOfAnimal);
            foreach (Animal animal in Lists.allTypesOfAnimals)
            {
                if(animal.GetType().ToString() != subTypeName && animal.GetType().BaseType.ToString().Substring(7) == typeOfAnimal)
                {
                    subTypeName = animal.GetType().ToString();
                    Console.WriteLine("{0}: {1}", subTypeNr, subTypeName.Substring(7));
                    subTypeNr++;
                }
            }
            Console.WriteLine("{0}. Return", subTypeNr);
        }
    }
}
