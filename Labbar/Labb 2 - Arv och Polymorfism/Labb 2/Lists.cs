using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    class Lists
    {
        static readonly public List<Animal> allTypesOfAnimals = new List<Animal>();

        static List<Animal> animalList = new List<Animal>();
        public static List<Animal> AnimalList { get { return animalList; } set { animalList = value; } }

        static List<Mammal> mammalList = new List<Mammal>();
        public static List<Mammal> MammalList { get { return mammalList; } set { mammalList = value; } }
        static List<Dog> dogList = new List<Dog>();
        public static List<Dog> DogList { get { return dogList; } set { dogList = value; } }
        static List<Cat> catList = new List<Cat>();
        public static List<Cat> CatList { get { return catList; } set { catList = value; } }

        static List<Reptile> reptileList = new List<Reptile>();
        public static List<Reptile> ReptileList { get { return reptileList; } set { reptileList = value; } }
        static List<Snake> snakeList = new List<Snake>();
        public static List<Snake> SnakeList { get { return snakeList; } set { snakeList = value; } }

        static List<Bird> birdList = new List<Bird>();
        public static List<Bird> BirdList { get { return birdList; } set { birdList = value; } }
        static List<Pigeon> pigeonList = new List<Pigeon>();
        public static List<Pigeon> PigeonList { get { return pigeonList; } set { pigeonList = value; } }
        static List<Eagle> eagleList = new List<Eagle>();
        public static List<Eagle> EagleList { get { return eagleList; } set { eagleList = value; } }

        public static void UpdateLists()
        {
            MammalList.Clear();
            MammalList.AddRange(DogList);
            MammalList.AddRange(CatList);

            ReptileList.Clear();
            ReptileList.AddRange(SnakeList);

            BirdList.Clear();
            BirdList.AddRange(PigeonList);
            BirdList.AddRange(EagleList);

            AnimalList.Clear();
            AnimalList.AddRange(MammalList);
            AnimalList.AddRange(ReptileList);
            AnimalList.AddRange(BirdList);
        }

        public static void createListOfAllAnimals()
        {
            allTypesOfAnimals.Add(new Dog("", 0, 0, true));
            allTypesOfAnimals.Add(new Cat("", 0, 0));
            allTypesOfAnimals.Add(new Snake("", 0, 0));
            allTypesOfAnimals.Add(new Pigeon("", 0, 0));
            allTypesOfAnimals.Add(new Eagle("", 0, 0));
        }

    }
}
