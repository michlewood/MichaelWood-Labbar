using System;
using System.Collections.Generic;

namespace Labb_2
{
    internal class Menus
    {
        public void MainMenu()
        {
            while (true)
            {
                Console.Clear();

                MenuGUI.MainMenuGUI();

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        AnimalOptions();
                        break;
                    case ConsoleKey.D2:
                        MammalChooser();
                        break;
                    case ConsoleKey.D3:
                        ReptileChooser();
                        break;
                    case ConsoleKey.D4:
                        BirdChooser();
                        break;
                    case ConsoleKey.D5:
                        return;

                    default:
                        break;
                }
            }
        }

        #region Animal
        private void AnimalOptions()
        {
            while (true)
            {
                bool loop = false;

                do
                {
                    Console.Clear();
                    loop = false;

                    MenuGUI.FamilyMenuGUI();

                    var input = Console.ReadKey(true).Key;

                    switch (input)
                    {
                        case ConsoleKey.D1:
                            ShowAnimalList();
                            Console.ReadLine();
                            break;
                        case ConsoleKey.D2:
                            RemoveAnimalFromLists();
                            break;
                        case ConsoleKey.D3:
                            return;

                        default:
                            loop = true;
                            break;
                    }
                } while (loop);
            }
        }

        public void ShowAnimalList()
        {
            Console.Clear();
            int i = 0;
            if (Runtime.animalList.Count == 0)
            {
                Console.WriteLine("Listan är tom!");
                return;
            }
            foreach (var animal in Runtime.animalList)
            {
                i++;
                Console.WriteLine("{0}: {1}", i, animal.Description());
            }
        }

        private void AddNewAnimalToList()
        {

        }

        private void RemoveAnimalFromLists()
        {
            ShowAnimalList();

            if (Runtime.animalList.Count == 0)
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Choose a animal to remove:");

            int animalToRemove;

            bool validInput = int.TryParse(Console.ReadLine(), out animalToRemove);
            if (!validInput || animalToRemove > Runtime.animalList.Count || animalToRemove < 1) return;


            AnimalRemoval(Runtime.animalList[animalToRemove - 1]);

            Console.WriteLine("Animal removed!");
            Console.ReadLine();
        }
        #endregion

        #region Mammals
        private void MammalChooser()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Choose one: ");
                Console.WriteLine("1. List of all mammals");
                Console.WriteLine("2. List of all dogs");
                Console.WriteLine("3. return");

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        MammalOptions();
                        break;
                    case ConsoleKey.D2:
                        DogOptions();
                        break;
                    case ConsoleKey.D3:
                        return;

                    default:
                        break;
                }
            }
        }

        private void MammalOptions()
        {
            while (true)
            {
                Console.Clear();

                MenuGUI.FamilyMenuGUI();

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ShowMammalList();
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        RemoveMammalFromLists();
                        break;
                    case ConsoleKey.D3:
                        return;

                    default:
                        break;
                }
            }
        }

        private void ShowMammalList()
        {
            Console.Clear();
            int i = 0;
            if (Runtime.mammalList.Count == 0)
            {
                Console.WriteLine("Listan är tom!");
                return;
            }
            foreach (var mammal in Runtime.mammalList)
            {
                i++;
                Console.WriteLine("{0}: {1}", i, mammal.Description());
            }
        }

        private void RemoveMammalFromLists()
        {
            ShowMammalList();

            if (Runtime.mammalList.Count == 0)
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Choose a mammal to remove:");

            int animalToRemove;

            bool validInput = int.TryParse(Console.ReadLine(), out animalToRemove);
            if (!validInput || animalToRemove > Runtime.mammalList.Count || animalToRemove < 1) return;


            AnimalRemoval(Runtime.mammalList[animalToRemove - 1]);

            Console.WriteLine("Mammal removed!");
            Console.ReadLine();
        }

        #region Dog
        private void DogOptions()
        {
            while (true)
            {
                Console.Clear();

                MenuGUI.SpeciesMenuGUI();

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ShowDogList();
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        AddNewDogToList();
                        break;
                    case ConsoleKey.D3:
                        RemoveDogFromLists();
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
            }
        }

        private void ShowDogList()
        {
            Console.Clear();
            int i = 0;
            if (Runtime.dogList.Count == 0)
            {
                Console.WriteLine("Listan är tom!");
                return;
            }
            foreach (var dog in Runtime.dogList)
            {
                i++;
                Console.WriteLine("{0}: {1}", i, dog.Description());
            }
        }

        private void AddNewDogToList()
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

            Runtime.dogList.Add(new Dog(name, age, weight, fluffyTail));
            Console.WriteLine("Dog added!");
            Console.ReadLine();
        }

        private void RemoveDogFromLists()
        {
            ShowDogList();

            if (Runtime.dogList.Count == 0)
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Choose a dog to remove:");

            int animalToRemove;

            bool validInput = int.TryParse(Console.ReadLine(), out animalToRemove);
            if (!validInput || animalToRemove > Runtime.dogList.Count || animalToRemove < 1) return;


            AnimalRemoval(Runtime.dogList[animalToRemove - 1]);

            Console.WriteLine("Dog removed!");
            Console.ReadLine();
        }
        #endregion

        #endregion

        #region Reptiles
        private void ReptileChooser()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Choose one: ");
                Console.WriteLine("1. List of all reptiles");
                Console.WriteLine("2. List of all snake");
                Console.WriteLine("3. return");

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ReptileOptions();
                        break;
                    case ConsoleKey.D2:
                        SnakeOptions();
                        break;
                    case ConsoleKey.D3:
                        return;

                    default:
                        break;
                }
            }
        }

        private void ReptileOptions()
        {
            while (true)
            {
                Console.Clear();

                MenuGUI.FamilyMenuGUI();

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ShowReptileList();
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        RemoveReptileFromLists();
                        break;
                    case ConsoleKey.D3:
                        return;

                    default:
                        break;
                }
            }
        }

        private void ShowReptileList()
        {
            Console.Clear();
            int i = 0;
            if (Runtime.reptileList.Count == 0)
            {
                Console.WriteLine("Listan är tom!");
                return;
            }
            foreach (var reptile in Runtime.reptileList)
            {
                i++;
                Console.WriteLine("{0}: {1}", i, reptile.Description());
            }
        }

        private void RemoveReptileFromLists()
        {
            ShowReptileList();

            if (Runtime.reptileList.Count == 0)
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Choose a reptile to remove:");

            int animalToRemove;

            bool validInput = int.TryParse(Console.ReadLine(), out animalToRemove);
            if (!validInput || animalToRemove > Runtime.reptileList.Count || animalToRemove < 1) return;


            AnimalRemoval(Runtime.reptileList[animalToRemove - 1]);

            Console.WriteLine("Reptile removed!");
            Console.ReadLine();
        }

        #region Snake
        private void SnakeOptions()
        {
            while (true)
            {
                Console.Clear();

                MenuGUI.SpeciesMenuGUI();

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ShowSnakeList();
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        AddNewSnakeToList();
                        break;
                    case ConsoleKey.D3:
                        RemoveSnakeFromLists();
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
            }
        }

        private void ShowSnakeList()
        {
            Console.Clear();
            int i = 0;
            if (Runtime.snakeList.Count == 0)
            {
                Console.WriteLine("Listan är tom!");
                return;
            }
            foreach (var snake in Runtime.snakeList)
            {
                i++;
                Console.WriteLine("{0}: {1}", i, snake.Description());
            }
        }

        private void AddNewSnakeToList()
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

            Runtime.snakeList.Add(new Snake(name, age, weight));
            Console.WriteLine("Snake added!");
            Console.ReadLine();
        }

        private void RemoveSnakeFromLists()
        {
            ShowSnakeList();

            if (Runtime.reptileList.Count == 0)
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Choose a snake to remove:");

            int animalToRemove;

            bool validInput = int.TryParse(Console.ReadLine(), out animalToRemove);
            if (!validInput || animalToRemove > Runtime.reptileList.Count || animalToRemove < 1) return;


            AnimalRemoval(Runtime.reptileList[animalToRemove - 1]);

            Console.WriteLine("Snake removed!");
            Console.ReadLine();
        }
        #endregion

        #endregion

        #region Bird
        private void BirdChooser()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("Choose one: ");
                Console.WriteLine("1. List of all birds");
                Console.WriteLine("2. List of all spearow");
                Console.WriteLine("3. return");

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        BirdOptions();
                        break;
                    case ConsoleKey.D2:
                        SpearowOptions();
                        break;
                    case ConsoleKey.D3:
                        return;

                    default:
                        break;
                }
            }
        }

        private void BirdOptions()
        {
            while (true)
            {
                Console.Clear();

                MenuGUI.FamilyMenuGUI();

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ShowBirdList();
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        RemoveBirdFromLists();
                        break;
                    case ConsoleKey.D3:
                        return;

                    default:
                        break;
                }
            }
        }

        private void ShowBirdList()
        {
            Console.Clear();
            int i = 0;
            if (Runtime.birdList.Count == 0)
            {
                Console.WriteLine("Listan är tom!");
                return;
            }
            foreach (var bird in Runtime.birdList)
            {
                i++;
                Console.WriteLine("{0}: {1}", i, bird.Description());
            }
        }

        private void RemoveBirdFromLists()
        {
            ShowBirdList();

            if (Runtime.birdList.Count == 0)
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Choose a bird to remove:");

            int animalToRemove;

            bool validInput = int.TryParse(Console.ReadLine(), out animalToRemove);
            if (!validInput || animalToRemove > Runtime.birdList.Count || animalToRemove < 1) return;


            AnimalRemoval(Runtime.birdList[animalToRemove - 1]);

            Console.WriteLine("Bird removed!");
            Console.ReadLine();
        }

        #region Spearow
        private void SpearowOptions()
        {
            while (true)
            {
                Console.Clear();

                MenuGUI.SpeciesMenuGUI();

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ShowSpearowList();
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        AddNewSpearowToList();
                        break;
                    case ConsoleKey.D3:
                        RemoveSpearowFromLists();
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
            }
        }

        private void ShowSpearowList()
        {
            Console.Clear();
            int i = 0;
            if (Runtime.spearowList.Count == 0)
            {
                Console.WriteLine("Listan är tom!");
                return;
            }
            foreach (var spearow in Runtime.spearowList)
            {
                i++;
                Console.WriteLine("{0}: {1}", i, spearow.Description());
            }
        }

        private void AddNewSpearowToList()
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

            Runtime.spearowList.Add(new Spearow(name, age, weight));
            Console.WriteLine("Bird added!");
            Console.ReadLine();
        }

        private void RemoveSpearowFromLists()
        {
            ShowSpearowList();

            if (Runtime.spearowList.Count == 0)
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Choose a spearow to remove:");

            int animalToRemove;

            bool validInput = int.TryParse(Console.ReadLine(), out animalToRemove);
            if (!validInput || animalToRemove > Runtime.spearowList.Count || animalToRemove < 1) return;


            AnimalRemoval(Runtime.spearowList[animalToRemove - 1]);

            Console.WriteLine("Spearow removed!");
            Console.ReadLine();
        }
        #endregion

        #endregion

        private void AnimalRemoval(Animal animal)
        {
            Runtime.animalList.Remove(animal);

            if (animal.GetType().BaseType.ToString() == "Labb_2.Mammal")
            {
                Runtime.mammalList.Remove((Mammal)animal);
                if (animal.GetType().ToString() == "Labb_2.Dog")
                {
                    Runtime.dogList.Remove((Dog)animal);
                }

            }
            if (animal.GetType().BaseType.ToString() == "Labb_2.Reptile")
            {
                Runtime.reptileList.Remove((Reptile)animal);
                if (animal.GetType().ToString() == "Labb_2.Snake")
                {
                    Runtime.snakeList.Remove((Snake)animal);
                }
            }

            if (animal.GetType().BaseType.ToString() == "Labb_2.Bird")
            {
                Console.ReadLine();
                Runtime.birdList.Remove((Bird)animal);
                if (animal.GetType().ToString() == "Labb_2.Spearow")
                {
                    Runtime.spearowList.Remove((Spearow)animal);
                }
            }


        }
    }
}