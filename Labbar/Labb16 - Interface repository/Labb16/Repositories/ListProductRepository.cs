using Labb16.Interfaces;
using Labb16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb16.Repositories
{
    class ListProductRepository : IProductRepository
    {
        List<Product> ProductList { get; set; }

        public void Add()
        {
            Console.WriteLine("What is the Product called?");
            ProductList.Add(new Product { Name = Console.ReadLine() });
        }

        public void Delete(int id)
        {
            if (0 <= id && id < ProductList.Count)
            {
                ProductList.RemoveAt(id); 
            }
        }

        public Product Get(int id)
        {
            return ProductList.ElementAtOrDefault(id);
        }

        public List<Product> GetAll()
        {
            return ProductList;
        }

        public void Update(Product updatedProduct)
        {
            Console.WriteLine("Please enter a new name for the product");
            updatedProduct.Name = Console.ReadLine();
        }
    }
}
