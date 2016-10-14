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
            Lists.DogList.Add(new Dog { Name = "Domino", Age = 10, Weight = 50, FluffyTail = true });
            Lists.DogList.Add(new Dog { Name = "woof", Age = 15, Weight = 3, FluffyTail = false });

            Lists.SnakeList.Add(new Snake { Name = "Snakey", Age = 3, Weight = 5 });

            Lists.PigeonList.Add(new Pigeon { Name = "Birdie", Age = 2,  Weight = 2 });

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
                TypeOfAnimal = "Animal";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.AnimalList);
                Console.Clear();

                MenuGUI.OptionsMenuGUI(TypeOfAnimal);

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        animalManager.ShowAnimalList(ListOfCurrentTypeOFAnimal, TypeOfAnimal);
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D2:
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
            while (true)
            {
                Console.Clear();
                MenuGUI.NewAnimalGUI();

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

                MenuGUI.OptionsMenuGUI(TypeOfAnimal);

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
            while (true)
            {
                TypeOfAnimal = "Mammal";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.MammalList);
                Console.Clear();

                MenuGUI.NewFamilyGUI(TypeOfAnimal);

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
        }

        private void DogOptions()
        {
            while (true)
            {
                TypeOfAnimal = "Dog";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.DogList);
                Console.Clear();

                MenuGUI.OptionsMenuGUI(TypeOfAnimal);

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

                MenuGUI.OptionsMenuGUI(TypeOfAnimal);

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

                MenuGUI.OptionsMenuGUI(TypeOfAnimal);

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
            while (true)
            {
                TypeOfAnimal = "Reptile";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.MammalList);
                Console.Clear();

                MenuGUI.NewFamilyGUI(TypeOfAnimal);

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
        }

        private void SnakeOptions()
        {
            while (true)
            {
                TypeOfAnimal = "Snake";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.SnakeList);
                Console.Clear();

                MenuGUI.OptionsMenuGUI(TypeOfAnimal);

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

                MenuGUI.OptionsMenuGUI(TypeOfAnimal);

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
            while (true)
            {
                TypeOfAnimal = "Bird";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.MammalList);
                Console.Clear();

                MenuGUI.NewFamilyGUI(TypeOfAnimal);

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
        }

        private void PigeonOptions()
        {
            while (true)
            {
                TypeOfAnimal = "Pigeon";
                ListOfCurrentTypeOFAnimal.Clear();
                ListOfCurrentTypeOFAnimal.AddRange(Lists.PigeonList);
                Console.Clear();

                MenuGUI.OptionsMenuGUI(TypeOfAnimal);

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

                MenuGUI.OptionsMenuGUI(TypeOfAnimal);

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