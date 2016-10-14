using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    class AnimalManager
    {
        public void ShowAnimalList(List<Animal> animalList, string typeOfAnimal)
        {
            Console.Clear();
            int i = 0;
            if (animalList.Count == 0)
            {
                Console.WriteLine("Listan är tom!");
                return;
            }

            Console.WriteLine(typeOfAnimal);
            foreach (var animal in animalList)
            {
                i++;
                Console.WriteLine("{0}: {1}", i, animal.Description());
            }
        }

        #region Add Animals
        public void AddNewDogToList()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            int age = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Age: ");
                validInput = int.TryParse(Console.ReadLine(), out age);
            }

            int weight = 0;
            validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Weight: ");
                validInput = int.TryParse(Console.ReadLine(), out weight);
            }

            bool fluffyTail = false;
            bool loop = false;

            do
            {
                loop = false;
                Console.WriteLine("Does the dog have a fluffytail? (Y/N)");

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.Y: fluffyTail = true; break;
                    case ConsoleKey.N: fluffyTail = false; break;
                    default: loop = true; break;
                }
            } while (loop);

            Lists.DogList.Add(new Dog(name, age, weight, fluffyTail));
            Lists.UpdateLists();
            Console.WriteLine("Dog added!");
            Console.ReadLine();
        }

        public void AddNewCatToList()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            int age = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Age: ");
                validInput = int.TryParse(Console.ReadLine(), out age);
            }

            int weight = 0;
            validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Weight: ");
                validInput = int.TryParse(Console.ReadLine(), out weight);
            }

            Lists.CatList.Add(new Cat(name, age, weight));
            Lists.UpdateLists();
            Console.WriteLine("Cat added!");
            Console.ReadLine();
        }

        public void AddNewSnakeToList()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            int age = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Age: ");
                validInput = int.TryParse(Console.ReadLine(), out age);
            }

            int weight = 0;
            validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Weight: ");
                validInput = int.TryParse(Console.ReadLine(), out weight);
            }

            Lists.SnakeList.Add(new Snake(name, age, weight));
            Lists.UpdateLists();
            Console.WriteLine("Snake added!");
            Console.ReadLine();
        }

        public void AddNewPigeonToList()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            int age = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Age: ");
                validInput = int.TryParse(Console.ReadLine(), out age);
            }

            int weight = 0;
            validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Weight: ");
                validInput = int.TryParse(Console.ReadLine(), out weight);
            }

            Lists.PigeonList.Add(new Pigeon(name, age, weight));
            Lists.UpdateLists();
            Console.WriteLine("Pigeon added!");
            Console.ReadLine();
        }

        public void AddNewEagleToList()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            int age = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Age: ");
                validInput = int.TryParse(Console.ReadLine(), out age);
            }

            int weight = 0;
            validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Weight: ");
                validInput = int.TryParse(Console.ReadLine(), out weight);
            }

            Lists.EagleList.Add(new Eagle(name, age, weight));
            Lists.UpdateLists();
            Console.WriteLine("Eagle added!");
            Console.ReadLine();
        }
        #endregion

        public void RemoveAnimalFromLists(List<Animal> animalList, string typeOfAnimal)
        {
            ShowAnimalList(animalList, typeOfAnimal);

            if (animalList.Count == 0)
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Choose a animal to remove:");

            int animalToRemove;

            bool validInput = int.TryParse(Console.ReadLine(), out animalToRemove);
            if (!validInput || animalToRemove > animalList.Count || animalToRemove < 1) return;


            AnimalRemoval(animalList[animalToRemove - 1]);

            Console.WriteLine("Animal removed!");
            Console.ReadLine();
        }

        public void AnimalRemoval(Animal animal)
        {

            if (animal.GetType().ToString() == "Labb_2.Dog")
                Lists.DogList.Remove((Dog)animal);

            else if (animal.GetType().ToString() == "Labb_2.Cat")
                Lists.CatList.Remove((Cat)animal);

            else if (animal.GetType().ToString() == "Labb_2.Snake")
                Lists.SnakeList.Remove((Snake)animal);

            else if (animal.GetType().ToString() == "Labb_2.Pigeon")
                Lists.PigeonList.Remove((Pigeon)animal);

            else if (animal.GetType().ToString() == "Labb_2.Eagle")
                Lists.EagleList.Remove((Eagle)animal);

            Lists.UpdateLists();
        }



    }
}
