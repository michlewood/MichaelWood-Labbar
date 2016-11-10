using Labb8.Datastores;
using Labb8.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Labb8.MyDelegates;

namespace Labb8.Manager
{
    class ProductManager
    {
        public MyLists Lists { get; set; }
        public ProductManager()
        {
            Lists = new MyLists();
            Lists.ProductList = new List<Product>
            {
                new Product {Name = "prod1", Price = 5 },
                new Product {Name = "prod2", Price = 10 },
                new Product {Name = "prod3", Price = 7.5 },
                new Product {Name = "prod4", Price = 1002 },
                new Product {Name = "prod5", Price = 1540 },
            };
        }

        public string FormatProductNames(StringConcatinator stringConcatinator)
        {
            return stringConcatinator(Lists.ProductList
                .Select(product => product.Name)
                .ToList());
        }

        public double PriceCalculation(NumberOperator numberOperator)
        {
            return (double)numberOperator(Lists.ProductList
                .Select(product => (float)product.Price)
                .ToList());
        }
    }
}
