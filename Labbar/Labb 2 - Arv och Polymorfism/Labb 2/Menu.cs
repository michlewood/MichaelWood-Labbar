using System;
using System.Collections.Generic;

namespace Labb_2
{
    internal class Menus
    {
        List<Animal> ListOfCurrentTypeOFAnimal = new List<Animal>();
        private string TypeOfAnimal { get; set; }

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
                TypeOfAnimal = "Animals";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Runtime.AnimalList);
                Console.Clear();

                MenuGUI.FamilyMenuGUI(TypeOfAnimal);

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        NewAnimal();
                        break;
                    case ConsoleKey.D3:
                        RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
            }
        }

        private void NewAnimal()
        {
            Console.WriteLine("What type of animal do you want to add? ");
            Console.WriteLine("1. Add mammal");
            Console.WriteLine("2. Add reptile");
            Console.WriteLine("3. Add bird");
            Console.WriteLine("4. Return");

            var input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    NewMammal();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    NewReptile();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    NewBird();
                    break;
                case ConsoleKey.D4:
                    return;

                default:
                    break;
            }
        }

        #endregion

        #region Mammals
        private void MammalChooser()
        {
            while (true)
            {
                TypeOfAnimal = "Mammals";
                Console.Clear();

                Console.WriteLine(TypeOfAnimal);
                Console.WriteLine("1. List of all mammals");
                Console.WriteLine("2. List of all dogs");
                Console.WriteLine("3. List of all cats");
                Console.WriteLine("4. return");

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
                        CatOptions();
                        break;
                    case ConsoleKey.D4:
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
                TypeOfAnimal = "Mammal";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Runtime.MammalList);
                Console.Clear();

                MenuGUI.FamilyMenuGUI(TypeOfAnimal);

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        NewMammal();
                        break;
                    case ConsoleKey.D3:
                        RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
            }
        }

        private void NewMammal()
        {
            Console.WriteLine("What type of mammal do you want to add? ");
            Console.WriteLine("1. Add dog");
            Console.WriteLine("2. Add cat");
            Console.WriteLine("3. Return");

            var input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    AddNewDogToList();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    AddNewCatToList();
                    break;
                case ConsoleKey.D3:
                    return;

                default:
                    break;
            }
        }

        #region Dog
        private void DogOptions()
        {
            while (true)
            {
                TypeOfAnimal = "Dogs";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Runtime.DogList);
                Console.Clear();

                MenuGUI.SpeciesMenuGUI(TypeOfAnimal);

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        AddNewDogToList();
                        break;
                    case ConsoleKey.D3:
                        RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
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

            Runtime.DogList.Add(new Dog(name, age, weight, fluffyTail));
            Runtime.UpdateLists();
            Console.WriteLine("Dog added!");
            Console.ReadLine();
        }
        #endregion

        #region Cat
        private void CatOptions()
        {
            while (true)
            {
                TypeOfAnimal = "Cats";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Runtime.CatList);
                Console.Clear();

                MenuGUI.SpeciesMenuGUI(TypeOfAnimal);

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        AddNewCatToList();
                        break;
                    case ConsoleKey.D3:
                        RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
            }
        }

        private void AddNewCatToList()
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

            Runtime.CatList.Add(new Cat(name, age, weight));
            Runtime.UpdateLists();
            Console.WriteLine("Cat added!");
            Console.ReadLine();
        }
        #endregion

        #endregion

        #region Reptiles
        private void ReptileChooser()
        {
            while (true)
            {
                TypeOfAnimal = "Reptiles";
                Console.Clear();

                Console.WriteLine(TypeOfAnimal);
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
                TypeOfAnimal = "Reptiles";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Runtime.ReptileList);
                Console.Clear();

                MenuGUI.FamilyMenuGUI(TypeOfAnimal);

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        NewReptile();
                        break;
                    case ConsoleKey.D3:
                        RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
            }
        }

        private void NewReptile()
        {
            Console.WriteLine("What type of reptile do you want to add? ");
            Console.WriteLine("1. add snake");
            Console.WriteLine("2. return");

            var input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    AddNewSnakeToList();
                    break;

                case ConsoleKey.D2:
                    return;

                default:
                    break;
            }
        }

        #region Snake
        private void SnakeOptions()
        {
            while (true)
            {
                TypeOfAnimal = "Snakes";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Runtime.SnakeList);
                Console.Clear();

                MenuGUI.SpeciesMenuGUI(TypeOfAnimal);

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        AddNewSnakeToList();
                        break;
                    case ConsoleKey.D3:
                        RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
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

            Runtime.SnakeList.Add(new Snake(name, age, weight));
            Runtime.UpdateLists();
            Console.WriteLine("Snake added!");
            Console.ReadLine();
        }
        #endregion

        #endregion

        #region Bird
        private void BirdChooser()
        {
            while (true)
            {
                TypeOfAnimal = "Birds";
                Console.Clear();

                Console.WriteLine(TypeOfAnimal);
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
                TypeOfAnimal = "Birds";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Runtime.BirdList);
                Console.Clear();

                MenuGUI.FamilyMenuGUI(TypeOfAnimal);

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        NewBird();
                        break;
                    case ConsoleKey.D3:
                        RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
            }
        }

        private void NewBird()
        {
            Console.WriteLine("What type of bird do you want to add? ");
            Console.WriteLine("1. Add spearow");
            Console.WriteLine("2. Return");

            var input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    AddNewSpearowToList();
                    break;

                case ConsoleKey.D2:
                    return;

                default:
                    break;
            }
        }

        #region Spearow
        private void SpearowOptions()
        {
            while (true)
            {
                TypeOfAnimal = "Spearow";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Runtime.SpearowList);
                Console.Clear();

                MenuGUI.SpeciesMenuGUI(TypeOfAnimal);

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        AddNewSpearowToList();
                        break;
                    case ConsoleKey.D3:
                        RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
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

            Runtime.SpearowList.Add(new Spearow(name, age, weight));
            Runtime.UpdateLists();
            Console.WriteLine("Bird added!");
            Console.ReadLine();
        }      
        #endregion

        #endregion

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

        private void RemoveAnimalFromLists(List<Animal> animalList, string typeOfAnimal)
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

        private void AnimalRemoval(Animal animal)
        {
            Runtime.AnimalList.Remove(animal);

            if (animal.GetType().BaseType.ToString() == "Labb_2.Mammal")
            {
                Runtime.MammalList.Remove((Mammal)animal);
                if (animal.GetType().ToString() == "Labb_2.Dog")
                {
                    Runtime.DogList.Remove((Dog)animal);
                }

            }
            if (animal.GetType().BaseType.ToString() == "Labb_2.Reptile")
            {
                Runtime.ReptileList.Remove((Reptile)animal);
                if (animal.GetType().ToString() == "Labb_2.Snake")
                {
                    Runtime.SnakeList.Remove((Snake)animal);
                }
            }

            if (animal.GetType().BaseType.ToString() == "Labb_2.Bird")
            {
                Console.ReadLine();
                Runtime.BirdList.Remove((Bird)animal);
                if (animal.GetType().ToString() == "Labb_2.Spearow")
                {
                    Runtime.SpearowList.Remove((Spearow)animal);
                }
            }


        }
    }
}