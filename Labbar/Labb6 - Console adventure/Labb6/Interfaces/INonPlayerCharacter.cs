using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6.Interfaces
{
    interface INonPlayerCharacter
    {
        string Name { get; set; }

        void Talk();
        string Observe();
    }
}
