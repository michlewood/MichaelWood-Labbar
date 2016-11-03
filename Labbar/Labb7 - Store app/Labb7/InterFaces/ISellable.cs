using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb7.InterFaces
{
    interface ISellable
    {
        int Price { get; set; }
        string ProductInformation { get; set; }
    }
}
