using System;
using System.Collections.Generic;

namespace Labb_2
{
    internal class Runtime
    {
        List<Animal> ListOfCurrentTypeOFAnimal = new List<Animal>();
        string TypeOfAnimal { get; set; }

        public void Start()
        {

            Lists.DogList.Add(new Dog("Domino", 23, 50, true));
            Lists.DogList.Add(new Dog("woof", 15, 3, false));

            Lists.SnakeList.Add(new Snake("Snakey", 3, 5));

            Lists.PigeonList.Add(new Pigeon("Birdie", 2, 2));

            Lists.UpdateLists();
            Lists.createListOfAllAnimals();

            MainMenu();
        }

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
                ListOfCurrentTypeOFAnimal.AddRange(Lists.AnimalList);
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
                TypeOfAnimal = "Mammal";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.MammalList);
                Console.Clear();

                MenuGUI.FamilyMenuChooserGUI(TypeOfAnimal);

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
                ListOfCurrentTypeOFAnimal.AddRange(Lists.MammalList);
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
            Console.WriteLine("1. Dog");
            Console.WriteLine("2. Cat");
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
                TypeOfAnimal = "Dog";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.DogList);
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

            Lists.DogList.Add(new Dog(name, age, weight, fluffyTail));
            Lists.UpdateLists();
            Console.WriteLine("Dog added!");
            Console.ReadLine();
        }
        #endregion

        #region Cat
        private void CatOptions()
        {
            while (true)
            {
                TypeOfAnimal = "Cat";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.CatList);
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

            Lists.CatList.Add(new Cat(name, age, weight));
            Lists.UpdateLists();
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
                TypeOfAnimal = "Reptile";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.ReptileList);
                Console.Clear();

                MenuGUI.FamilyMenuChooserGUI(TypeOfAnimal);

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
                ListOfCurrentTypeOFAnimal.AddRange(Lists.ReptileList);
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
            Console.WriteLine("1. Snake");
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
                TypeOfAnimal = "Snake";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.SnakeList);
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

            Lists.SnakeList.Add(new Snake(name, age, weight));
            Lists.UpdateLists();
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
                TypeOfAnimal = "Bird";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.BirdList);
                Console.Clear();

                MenuGUI.FamilyMenuChooserGUI(TypeOfAnimal);

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        BirdOptions();
                        break;
                    case ConsoleKey.D2:
                        PigeonOptions();
                        break;
                    case ConsoleKey.D3:
                        EagleOptions();
                        break;
                    case ConsoleKey.D4:
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
                TypeOfAnimal = "Bird";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.BirdList);
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
            Console.WriteLine("1. Pidgeon");
            Console.WriteLine("2. Eagle");
            Console.WriteLine("3. Return");

            var input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    AddNewPigeonToList();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    AddNewEagleToList();
                    break;
                case ConsoleKey.D3:
                    return;

                default:
                    break;
            }
        }

        #region Pigeon
        private void PigeonOptions()
        {
            while (true)
            {
                TypeOfAnimal = "Pigeon";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.PigeonList);
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
                        AddNewPigeonToList();
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

        private void AddNewPigeonToList()
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
        #endregion

        #region Eagle
        private void EagleOptions()
        {
            while (true)
            {
                TypeOfAnimal = "Eagle";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.EagleList);
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
                        AddNewEagleToList();
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

        private void AddNewEagleToList()
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