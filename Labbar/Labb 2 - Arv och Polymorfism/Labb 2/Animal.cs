using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    abstract public class Animal
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Weight { get; private set; }


        public Animal(string name, int age, int weight)
        {

        }

        abstract public string Move();

        abstract public string Talk();

    }
}
