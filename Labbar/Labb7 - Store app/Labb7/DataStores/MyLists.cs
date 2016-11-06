using Labb7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb7.DataStores
{
    class MyLists
    {
        List<Product> products = new List<Product>();
        public List<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
            }
        }

        public List<Product> CurrentProducts { get; set; }

        public void UpdateCurrentList()
        {
            Products = Products.
                OrderBy(product => product.GetType().ToString()).ToList();
            CurrentProducts = Products;
            if (!Graphics.ElecronicsOn) CurrentProducts = CurrentProducts
                        .Where(product => product.GetType() != typeof(Electronic)).ToList();
            if (!Graphics.ToysOn) CurrentProducts = CurrentProducts
                        .Where(product => product.GetType() != typeof(Toy)).ToList();
            if (!Graphics.VideoGamesOn) CurrentProducts = CurrentProducts
                        .Where(product => product.GetType() != typeof(VideoGame)).ToList();
        }
    }
}
