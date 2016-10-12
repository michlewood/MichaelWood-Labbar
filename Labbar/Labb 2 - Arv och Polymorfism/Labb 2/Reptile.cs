using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    abstract public class Reptile : Animal
    {
        public Reptile(string name, int age, int weight) : base(name, age, weight)
        {
        }
    }

    public class Snake : Reptile
    {
        public Snake(string name, int age, int weight) : base(name, age, weight)
        {
        }

        public override string Move()
        {
            return "slithers on the ground";
        }

        public override string Talk()
        {
            return "hisses";
        }
    }
}
