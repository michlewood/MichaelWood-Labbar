using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb14.Models.Publications
{
    class Book : Publication
    {
        public string Genre { get; set; }
        public int Pages { get; set; }

    }
}
