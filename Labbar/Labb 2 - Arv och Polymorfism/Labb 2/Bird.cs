using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    abstract public class Bird : Animal
    {
        public bool CanFly { get; set; }

        public Bird(bool canFly = true)
        {
            CanFly = canFly;
        }
    }

    public class Pigeon : Bird
    {
        public Pigeon() { }

        public override string Move()
        {
            return "flies through the sky";
        }

        public override string Talk()
        {
            return "twerping";
        }
    }

    public class Eagle : Bird
    {
        public Eagle() { }

        public override string Move()
        {
            return "soars through the sky";
        }

        public override string Talk()
        {
            return "high-pitched whistling";
        }
    }
}
