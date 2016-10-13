using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    abstract public class Mammal : Animal
    {
        public int NumberOfLegs { get; private set; }

        public Mammal(string name, int age, int weight, int numberOfLegs) : base(name, age, weight)
        {
            NumberOfLegs = numberOfLegs;
        }
    }

    public class Dog : Mammal
    {
        public bool FluffyTail { get; private set; }
        public Dog(string name, int age, int weight, bool fluffyTail) : base(name, age, weight, 4)
        {
            FluffyTail = fluffyTail;
        }

        public override string Move()
        {
            return "walks on the ground";
        }

        public override string Talk()
        {
            return "barks";
        }
    }

    public class Cat : Mammal
    {
        public Cat(string name, int age, int weight, int numberOfLegs) : base(name, age, weight, 4)
        {
        }

        public override string Move()
        {
            return "Walks on the ground";
        }

        public override string Talk()
        {
            return "Meows";
        }
    }
}
