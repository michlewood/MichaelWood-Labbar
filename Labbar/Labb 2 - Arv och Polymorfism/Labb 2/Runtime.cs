using System;
using System.Collections.Generic;

namespace Labb_2
{
    internal class Runtime
    {
        List<Animal> animalList = new List<Animal>();

        List<Mammal> mammalList = new List<Mammal>();
        List<Dog> dogList = new List<Dog>();

        

        List<Reptile> reptileList = new List<Reptile>();

        List<Bird> birdList = new List<Bird>();


        internal void Start()
        {
            mammalList.AddRange(dogList);
        }
    }
}