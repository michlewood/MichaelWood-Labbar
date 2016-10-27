using Labb6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6.Models.Creatures
{
    class Animal : INonPlayerCharacter
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }

        public virtual string Observe()
        {
            return "You see an animal";
        }

        public virtual bool Talk()
        {
            Console.WriteLine("The {0} looks at you", Name);
            return false;
        }
    }
}
