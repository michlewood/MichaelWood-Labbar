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

        static public void FamilyMenuChooserGUI(List<Animal> animalList, string typeOfAnimal)
        {
            int subTypeNr = 2;
            string subTypeName = "" ;
            string baseType = animalList[0].GetType().BaseType.ToString();
            Console.WriteLine("1. All {0}", typeOfAnimal);
            foreach (Animal animal in Lists.allTypesOfAnimals)
            {
                if(animal.GetType().ToString() != subTypeName && animal.GetType().BaseType.ToString() == baseType)
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
