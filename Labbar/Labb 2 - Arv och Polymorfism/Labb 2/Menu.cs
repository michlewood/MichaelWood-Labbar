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

                Console.WriteLine("Choose one: ");
                Console.WriteLine("1. All animals");
                Console.WriteLine("2. Mammals");
                Console.WriteLine("3. Reptiles");
                Console.WriteLine("4. Birds");
                Console.WriteLine("5. Exit");

                int input;

                bool validInput = int.TryParse(Console.ReadLine(), out input);
                if (!validInput) input = -1;

                switch (input)
                {
                    case 1:
                        AnimalOptions();
                        break;
                    case 2:
                        MammalChooser();
                        break;
                    case 3:
                        ReptileChooser();
                        break;
                    case 4:
                        BirdChooser();
                        break;
                    case 5:
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

                    Console.WriteLine("Choose one: ");
                    Console.WriteLine("1. Add new");
                    Console.WriteLine("2. Remove");
                    Console.WriteLine("3. Show info");
                    Console.WriteLine("4. Return");

                    int input;

                    bool validInput = int.TryParse(Console.ReadLine(), out input);
                    if (!validInput) input = -1;

                    switch (input)
                    {
                        case 1:
                            AddNewAnimalToList();
                            break;
                        case 2:
                            RemoveAnimalFromLists();
                            break;
                        case 3:
                            ShowAnimalList();
                            Console.ReadLine();
                            break;
                        case 4:
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
            int i = 0;
            if (Runtime.animalList.Count == 0)
            {
                Console.WriteLine("Listan är tom!");
                return;
            }
            foreach (var animal in Runtime.animalList)
            {
                i++;
                Console.WriteLine("{0}: {1}", i, animal.Introduction());
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
            bool loop = true;

            do
            {
                Console.Clear();
                loop = true;

                Console.WriteLine("Choose one: ");
                Console.WriteLine("1. List of all mammals");
                Console.WriteLine("2. List of all dogs");
                Console.WriteLine("3. return");

                int input;

                bool validInput = int.TryParse(Console.ReadLine(), out input);
                if (!validInput) input = -1;

                switch (input)
                {
                    case 1:
                        MammalOptions();
                        Console.ReadLine();
                        break;
                    case 2:
                        DogOptions();
                        //ShowDogList();
                        Console.ReadLine();
                        break;
                    case 3:
                        return;

                    default:
                        loop = false;
                        break;
                }
            } while (loop);
        }

        private void MammalOptions()
        {
            while (true)
            {
                bool loop = false;

                do
                {
                    Console.Clear();
                    loop = false;

                    Console.WriteLine("Choose one: ");
                    Console.WriteLine("1. Add new");
                    Console.WriteLine("2. Remove");
                    Console.WriteLine("3. Show info");
                    Console.WriteLine("4. Return");

                    int input;

                    bool validInput = int.TryParse(Console.ReadLine(), out input);
                    if (!validInput) input = -1;

                    switch (input)
                    {
                        case 1:
                            break;
                        case 2:
                            RemoveMammalFromLists();
                            break;
                        case 3:
                            ShowMammalList();
                            Console.ReadLine();
                            break;
                        case 4:
                            return;

                        default:
                            loop = true;
                            break;
                    }
                } while (loop);
            }
        }

        private void DogOptions()
        {
            while (true)
            {
                bool loop = false;

                do
                {
                    Console.Clear();
                    loop = false;

                    Console.WriteLine("Choose one: ");
                    Console.WriteLine("1. Add new");
                    Console.WriteLine("2. Remove");
                    Console.WriteLine("3. Show info");
                    Console.WriteLine("4. Return");

                    int input;

                    bool validInput = int.TryParse(Console.ReadLine(), out input);
                    if (!validInput) input = -1;

                    switch (input)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            ShowDogList();
                            Console.ReadLine();
                            break;
                        case 4:
                            return;

                        default:
                            loop = true;
                            break;
                    }
                } while (loop);
            }
        }

        private void ShowMammalList()
        {
            int i = 0;
            if (Runtime.mammalList.Count == 0)
            {
                Console.WriteLine("Listan är tom!");
                return;
            }
            foreach (var mammal in Runtime.mammalList)
            {
                i++;
                Console.WriteLine("{0}: {1}", i, mammal.Introduction());
            }
        }

        private void RemoveMammalFromLists()
        {
            ShowMammalList();

            if (Runtime.animalList.Count == 0)
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Choose a mammal to remove:");

            int animalToRemove;

            bool validInput = int.TryParse(Console.ReadLine(), out animalToRemove);
            if (!validInput || animalToRemove > Runtime.animalList.Count || animalToRemove < 1) return;


            AnimalRemoval(Runtime.animalList[animalToRemove - 1]);

            Console.WriteLine("Mammal removed!");
            Console.ReadLine();
        }

        private void ShowDogList()
        {
            int i = 0;
            if (Runtime.dogList.Count == 0)
            {
                Console.WriteLine("Listan är tom!");
                return;
            }
            foreach (var dog in Runtime.dogList)
            {
                i++;
                Console.WriteLine("{0}: {1}", i, dog.Introduction());
            }
        }
        #endregion

        #region Reptiles
        private void ReptileChooser()
        {
            bool loop = true;

            do
            {
                Console.Clear();
                loop = true;

                Console.WriteLine("Choose one: ");
                Console.WriteLine("1. List of all reptiles");
                Console.WriteLine("2. return");

                int input;

                bool validInput = int.TryParse(Console.ReadLine(), out input);
                if (!validInput) input = -1;

                switch (input)
                {
                    case 1:
                        ShowReptileList();
                        Console.ReadLine();
                        break;

                    case 2:
                        return;

                    default:
                        loop = false;
                        break;
                }
            } while (loop);
        }

        private void ShowReptileList()
        {
            int i = 0;
            if (Runtime.reptileList.Count == 0)
            {
                Console.WriteLine("Listan är tom!");
                return;
            }
            foreach (var reptile in Runtime.reptileList)
            {
                i++;
                Console.WriteLine("{0}: {1}", i, reptile.Introduction());
            }
        }
        #endregion

        #region Birds
        private void BirdChooser()
        {
            bool loop = true;

            do
            {
                Console.Clear();
                loop = true;

                Console.WriteLine("Choose one: ");
                Console.WriteLine("1. List of all birds");
                Console.WriteLine("2. return");

                int input;

                bool validInput = int.TryParse(Console.ReadLine(), out input);
                if (!validInput) input = -1;
                List<Animal> animalList = new List<Animal>();

                switch (input)
                {

                    case 1:
                        ShowBirdList();
                        Console.ReadLine();
                        break;

                    case 2:
                        return;

                    default:
                        loop = false;
                        break;
                }
            } while (loop);
        }

        private void ShowBirdList()
        {
            int i = 0;
            if (Runtime.birdList.Count == 0)
            {
                Console.WriteLine("Listan är tom!");
                return;
            }
            foreach (var bird in Runtime.birdList)
            {
                i++;
                Console.WriteLine("{0}: {1}", i, bird.Introduction());
            }
        }
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
            }

            if (animal.GetType().BaseType.ToString() == "Labb_2.Bird")
            {
                Runtime.birdList.Remove((Bird)animal);
            }


        }
    }
}