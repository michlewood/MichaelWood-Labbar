using Labb16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb16.Interfaces
{
    interface IProductRepository
    {
        void Add();
        Product Get(int id);
        List<Product> GetAll();
        void Update(Product updatedProduct);
        void Delete(int id);
    }
}
