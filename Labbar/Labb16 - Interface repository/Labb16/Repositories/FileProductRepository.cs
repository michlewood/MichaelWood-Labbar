using Labb16.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb16.Models;
using Newtonsoft.Json;
using System.IO;

namespace Labb16.Repositories
{
    class FileProductRepository : IProductRepository
    {
        string directory;
        string file;

        public FileProductRepository()
        {
            directory = Environment.CurrentDirectory;
            file = String.Format("{0}{1}", directory, "\\data.json");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if (!File.Exists(file))
                File.Create(file);
        }

        public void Add()
        {
            Console.WriteLine("What is the Product called?");
            List<Product> tempList = GetAll();
            if (tempList == null)
                tempList = new List<Product>();
            tempList.Add(new Product { Name = Console.ReadLine() });
            string jsonString = JsonConvert.SerializeObject(tempList);
            File.WriteAllText(file, jsonString);
        }

        public void Delete(int id)
        {
            List<Product> tempList = GetAll();
            if (0 <= id && id < tempList.Count)
            {
                tempList.RemoveAt(id);
                string jsonString = JsonConvert.SerializeObject(tempList);
                File.WriteAllText(file, jsonString);
            }
        }

        public Product Get(int id)
        {
            List<Product> tempList = GetAll();
            if (0 <= id && id < tempList.Count)
            {
                return tempList.ElementAt(id);
            }
            return null;
        }

        public List<Product> GetAll()
        {
            string jsonFromFile = File.ReadAllText(file);

            return JsonConvert.DeserializeObject<List<Product>>(jsonFromFile);
        }

        public void Update(Product updatedProduct)
        {
            List<Product> tempList = GetAll();
            Console.WriteLine("Please enter a new name for the product");
            Product tempProduct = tempList.Find(product => product.Equals(updatedProduct));
            tempProduct.Name = Console.ReadLine();

            if (true)
            {
                string jsonString = JsonConvert.SerializeObject(tempList);
                File.WriteAllText(file, jsonString);
            }
        }
    }
}
