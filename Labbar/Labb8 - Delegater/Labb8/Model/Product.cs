using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb8.Model
{
    class Product
    {
        private static int idTotal;
        public int Id { get; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product()
        {
            Id = ++idTotal;
        }
    }
}
