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

        public override string Description()
        {
            return string.Format("{0} I have {1} legs", base.Description(), NumberOfLegs);
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

        public override string Description()
        {

            if (FluffyTail)
            {
                return base.Description() + " and i have a fluffy tail";
            }

            else return base.Description() + ".";

        }
    }

    public class Cat : Mammal
    {
        public int Lives { get; set; }

        public Cat(string name, int age, int weight, int lives = 9) : base(name, age, weight, 4)
        {
            Lives = lives;
        }

        public override string Move()
        {
            return "Walks on the ground";
        }

        public override string Talk()
        {
            return "Meows";
        }

        public override string Description()
        {
            return string.Format("{0}, and i have {1} lives ",base.Description(), Lives);
        }
    }
}
