using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_2
{
    abstract public class Mammel : Animal
    {

    }

    public class Dog : Mammel
    {
        public Dog()
        {
            NumberOfLegs = 4;
        }
        

        public override string Move()
        {
            return "Walks on the ground";
        }

        public override string Talk()
        {
            throw new NotImplementedException();
        }
    }
}
