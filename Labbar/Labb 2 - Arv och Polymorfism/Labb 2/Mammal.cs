using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    abstract public class Mammal : Animal
    {
        public int NumberOfLegs { get; set; }

        public Mammal(int numberOfLegs)
        {
            NumberOfLegs = numberOfLegs;
        }

        public override string Description()
        {
            return string.Format("{0} It has {1} legs", base.Description(), NumberOfLegs);
        }
    }

    public class Dog : Mammal
    {
        public bool FluffyTail { get; set; }

        public Dog() : base(4) { }

        public override string Move()
        {
            return "walks on the ground";
        }

        public override string Talk()
        {
            return "barking";
        }

        public override string Description()
        {

            if (FluffyTail)
            {
                return base.Description() + " and it has a fluffy tail";
            }

            else return base.Description() + ".";

        }
    }

    public class Cat : Mammal
    {
        public int Lives { get; set; }

        public Cat(int lives = 9) : base(4)
        {
            Lives = lives;
        }

        public override string Move()
        {
            return "Walks on the ground";
        }

        public override string Talk()
        {
            return "meowing";
        }

        public override string Description()
        {
            return string.Format("{0}, and it have {1} lives ", base.Description(), Lives);
        }
    }
}
