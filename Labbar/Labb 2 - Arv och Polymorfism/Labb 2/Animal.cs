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
            Name = name;
            Age = age;
            Weight = weight;
        }

        abstract public string Move();

        abstract public string Talk();

        public string Introduction()
        {
            return String.Format("{0}: is {1} years old and weighs {2}", Name, Age, Weight);
        }
    }
}
