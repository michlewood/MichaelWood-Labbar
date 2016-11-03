using Labb7.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb7.Models
{
    abstract class Product : ISellable
    {
        public enum TypesOfProduct
        {
            Electronics = 1,
            Toys
        }

        public TypesOfProduct Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ProductInformation { get; set; }
    }
}
