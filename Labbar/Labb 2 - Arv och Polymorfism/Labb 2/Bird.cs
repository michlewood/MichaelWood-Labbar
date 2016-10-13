using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    abstract public class Bird : Animal
    {
        public bool CanFly { get; private set; }

        public Bird(string name, int age, int weight, bool canFly = true) : base(name, age, weight)
        {
            CanFly = canFly;
        }
    }

    public class Pigeon : Bird
    {

        public Pigeon(string name, int age, int weight) : base(name, age, weight)
        {
        }

        public override string Move()
        {
            return "flies through the sky";
        }

        public override string Talk()
        {
            return "twerp";
        }
    }

    public class Eagle : Bird
    {
        public Eagle(string name, int age, int weight) : base(name, age, weight)
        {
        }

        public override string Move()
        {
            return "soars through the sky";
        }

        public override string Talk()
        {
            return "high-pitched whistle";
        }
    }
}
