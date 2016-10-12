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
            dogList.Add(new Dog("Domino", 23, 50, true));

            snakeList.Add(new Snake("Snakey", 3, 5));

            spearowList.Add(new Spearow("Birdie", 2, 2));

            UpdateLists();
            
            menus.MainMenu();
        }

        private void UpdateLists()
        {
            
            mammalList.AddRange(dogList);
            
            reptileList.AddRange(snakeList);
            
            birdList.AddRange(spearowList);

            animalList.AddRange(mammalList);
            animalList.AddRange(reptileList);
            animalList.AddRange(birdList);
        }
    }
}