using System;
using System.Collections.Generic;

namespace Labb_2
{
    internal class Runtime
    {
        List<Animal> ListOfCurrentTypeOFAnimal = new List<Animal>();
        string TypeOfAnimal { get; set; }
        AnimalManager animalManager = new AnimalManager();

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
                        animalManager.ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        NewAnimal();
                        break;
                    case ConsoleKey.D3:
                        animalManager.RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
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
                        animalManager.ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        NewMammal();
                        break;
                    case ConsoleKey.D3:
                        animalManager.RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
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
                    animalManager.AddNewDogToList();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    animalManager.AddNewCatToList();
                    break;
                case ConsoleKey.D3:
                    return;

                default:
                    break;
            }
        }

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
                        animalManager.ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        animalManager.AddNewDogToList();
                        break;
                    case ConsoleKey.D3:
                        animalManager.RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
            }
        }
      
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
                        animalManager.ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        animalManager.AddNewCatToList();
                        break;
                    case ConsoleKey.D3:
                        animalManager.RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
            }
        }
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
                        animalManager.ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        NewReptile();
                        break;
                    case ConsoleKey.D3:
                        animalManager.RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
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
                    animalManager.AddNewSnakeToList();
                    break;

                case ConsoleKey.D2:
                    return;

                default:
                    break;
            }
        }

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
                        animalManager.ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        animalManager.AddNewSnakeToList();
                        break;
                    case ConsoleKey.D3:
                        animalManager.RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
            }
        }
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
                        animalManager.ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        NewBird();
                        break;
                    case ConsoleKey.D3:
                        animalManager.RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
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
                    animalManager.AddNewPigeonToList();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    animalManager.AddNewEagleToList();
                    break;
                case ConsoleKey.D3:
                    return;

                default:
                    break;
            }
        }

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
                        animalManager.ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        animalManager.AddNewPigeonToList();
                        break;
                    case ConsoleKey.D3:
                        animalManager.RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
            }
        }

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
                        animalManager.ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
                        animalManager.AddNewEagleToList();
                        break;
                    case ConsoleKey.D3:
                        animalManager.RemoveAnimalFromLists(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        break;
                    case ConsoleKey.D4:
                        return;

                    default:
                        break;
                }
            }
        }
        #endregion

    }
}