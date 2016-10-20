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
            Console.Clear();
            Dog newDog = new Dog();
            AddAnimalProperties(newDog);

            bool loop = false;

            do
            {
                loop = false;
                Console.WriteLine("Does the dog have a fluffytail? (Y/N)");

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.Y: newDog.FluffyTail = true; break;
                    case ConsoleKey.N: newDog.FluffyTail = false; break;
                    default: loop = true; break;
                }
            } while (loop);

            Lists.DogList.Add(newDog);
            Lists.UpdateLists();
            Console.WriteLine("Dog added!");
            Console.ReadLine();
        }

        public void AddNewCatToList()
        {
            Console.Clear();
            Cat newCat = new Cat();
            AddAnimalProperties(newCat);

            bool loop = false;

            do
            {
                loop = false;
                Console.WriteLine("Does the cat have nine lives? (Y/N)");

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.Y: break;
                    case ConsoleKey.N:
                        loop = true;
                        while (loop)
                        {
                            Console.WriteLine("How many lives does it have?");
                            int lives = 0;
                            bool validInput = false;

                            while (!validInput)
                            {
                                Console.Write("Lives: ");
                                validInput = int.TryParse(Console.ReadLine(), out lives);
                            }
                            newCat.Lives = lives;
                            loop = false;
                        }
                        break;

                    default: loop = true; break;
                }
            } while (loop);

            Lists.CatList.Add(newCat);
            Lists.UpdateLists();
            Console.WriteLine("Cat added!");
            Console.ReadLine();
        }

        public void AddNewSnakeToList()
        {
            Console.Clear();
            Snake newSnake = new Snake();
            AddAnimalProperties(newSnake);
            Lists.SnakeList.Add(newSnake);
            Lists.UpdateLists();
            Console.WriteLine("Snake added!");
            Console.ReadLine();
        }

        public void AddNewPigeonToList()
        {
            Console.Clear();
            Pigeon newPigeon = new Pigeon();
            AddAnimalProperties(newPigeon);
            Lists.PigeonList.Add(newPigeon);
            Lists.UpdateLists();
            Console.WriteLine("Pigeon added!");
            Console.ReadLine();
        }

        public void AddNewEagleToList()
        {
            Console.Clear();
            Eagle newEagle = new Eagle();
            AddAnimalProperties(newEagle);
            Lists.EagleList.Add(newEagle);
            Lists.UpdateLists();
            Console.WriteLine("Eagle added!");
            Console.ReadLine();
        }
        #endregion

        private void AddAnimalProperties(Animal newAnimal)
        {
            Console.WriteLine("Name: ");
            newAnimal.Name = Console.ReadLine();

            int age = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Age: ");
                validInput = int.TryParse(Console.ReadLine(), out age);
            }
            newAnimal.Age = age;

            validInput = false;

            int weight = 0;
            while (!validInput)
            {
                Console.WriteLine("Weight: ");
                validInput = int.TryParse(Console.ReadLine(), out weight);
            }
            newAnimal.Weight = weight;
        }

        public void RemoveAnimalFromLists(List<Animal> animalList, string typeOfAnimal)
        {
            ShowAnimalList(animalList, typeOfAnimal);

            if (animalList.Count == 0)
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Choose an animal to remove:");

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
