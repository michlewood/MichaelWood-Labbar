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
}
