using System;
using System.Collections.Generic;

namespace Labb_2
{
    internal class Runtime
    {
        public static List<Animal> AnimalList { get; set; }
        

        public static List<Mammal> MammalList { get; set; }
        public static List<Dog> DogList { get; set; }

        public static List<Reptile> ReptileList { get; set; }
        public static List<Snake> SnakeList { get; set; }

        public static List<Bird> BirdList { get; set; }
        public static List<Spearow> SpearowList { get; set; }

        public static List<Cat> CatList { get; set; }

        Menus menus = new Menus();

        internal void Start()
        {
            AnimalList = new List<Animal>();
            MammalList = new List<Mammal>();
            DogList = new List<Dog>();
            CatList = new List<Cat>();
            ReptileList = new List<Reptile>();
            SnakeList = new List<Snake>();
            BirdList = new List<Bird>();
            SpearowList = new List<Spearow>();

            DogList.Add(new Dog("Domino", 23, 50, true));

            SnakeList.Add(new Snake("Snakey", 3, 5));

            SpearowList.Add(new Spearow("Birdie", 2, 2));

            UpdateLists();
            
            menus.MainMenu();
        }

        public static void UpdateLists()
        {
            MammalList.Clear();
            MammalList.AddRange(DogList);
            MammalList.AddRange(CatList);

            ReptileList.Clear();
            ReptileList.AddRange(SnakeList);

            BirdList.Clear();
            BirdList.AddRange(SpearowList);

            AnimalList.Clear();
            AnimalList.AddRange(MammalList);
            AnimalList.AddRange(ReptileList);
            AnimalList.AddRange(BirdList);
        }
    }
}