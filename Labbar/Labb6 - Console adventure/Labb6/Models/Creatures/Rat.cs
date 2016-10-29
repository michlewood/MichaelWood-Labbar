using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6.Models.Creatures
{
    class Rat : Animal
    {
        public Rat() : base("Rat")
        {
        }
        public override string Observe()
        {
            return "The rat avoids you as it looks for anything to call food (propaply with an intent to eat it).";
        }
    }
}
