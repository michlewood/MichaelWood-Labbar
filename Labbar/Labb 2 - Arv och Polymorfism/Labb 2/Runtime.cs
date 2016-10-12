using System;
using System.Collections.Generic;

namespace Labb_2
{
    internal class Runtime
    {
        static public List<Animal> animalList = new List<Animal>();

        static public List<Mammal> mammalList = new List<Mammal>();
        static public List<Dog> dogList = new List<Dog>();

        static public List<Reptile> reptileList = new List<Reptile>();
        static public List<Snake> snakeList = new List<Snake>();

        static public List<Bird> birdList = new List<Bird>();
        static public List<Spearow> spearowList = new List<Spearow>();

        Menus menus = new Menus();

        internal void Start()
        {
            CreateLists();
            
            menus.MainMenu();
        }

        private void CreateLists()
        {
            dogList.Add(new Dog("michael", 23, 100, true));
            mammalList.AddRange(dogList);

            snakeList.Add(new Snake("snakey", 3, 5));
            reptileList.AddRange(snakeList);

            spearowList.Add(new Spearow("Birdie", 2, 2));
            birdList.AddRange(spearowList);

            animalList.AddRange(mammalList);
            animalList.AddRange(reptileList);
            animalList.AddRange(birdList);
        }

        

        private void AddNewAnimalToList()
        {

        }

        private void RemoveAnimalFromList()
        {
            menus.ShowAnimalList();

            if (animalList.Count == 0)
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Choose a animal to remove:");

            int animalToRemove;

            bool validInput = int.TryParse(Console.ReadLine(), out animalToRemove);
            if (!validInput || animalToRemove > animalList.Count || animalToRemove < 1) return;

            animalList.RemoveAt(animalToRemove - 1);

            Console.WriteLine("Animal removed!");
            Console.ReadLine();
        }
    }
}