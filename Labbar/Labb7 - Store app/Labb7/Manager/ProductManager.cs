using Labb7.DataStores;
using Labb7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb7.Manager
{
    class ProductManager
    {
        public MyLists lists = new MyLists();

        public ProductManager()
        {
            lists.Products.Add(new Electronic
            {
                Name = "Computer",
                Price = 200,
                ProductInformation = "This is a computer"
            });
            lists.Products.Add(new Toy
            {
                Name = "Plushie",
                Price = 50,
                ProductInformation = "This is a small, cute plushie"
            });
            lists.Products.Add(new VideoGame
            {
                Name = "Dark Souls",
                Price = 60,
                ProductInformation = "A action, roleplaying game",
                GenreType = VideoGame.Genre.RolePlayingGame
            });

            lists.UpdateCurrentList();
        }

        public void TypeOfProductToAdd()
        {
            bool validInput = false;
            while (!validInput)
            {
                Console.Clear();
                foreach (var name in Enum.GetValues(typeof(Product.TypesOfProduct)))
                {
                    Console.WriteLine("{0}. {1}", (int)name, name);
                }
                Console.WriteLine("What type of product do you want to add?");
                int typeOfProduct;
                validInput = int.TryParse(Console.ReadLine(), out typeOfProduct);
                switch (typeOfProduct)
                {
                    case 1:
                        AddCommonElements(new Electronic(), 1);
                        break;
                    case 2:
                        AddCommonElements(new Toy(), 1);
                        break;
                    case 3:
                        VideoGame newVideoGame = new VideoGame();
                        AddCommonElements(newVideoGame, 1);
                        newVideoGame.GenreType = VideoGame.Genre.RolePlayingGame;
                        break;
                    default:
                        validInput = false;
                        break;
                } 
            }
            lists.UpdateCurrentList();
        }

        private void AddCommonElements(Product newProduct, int typeOfProduct)
        {
            lists.Products.Add(newProduct);

            newProduct.Type = (Product.TypesOfProduct)typeOfProduct;
            Console.WriteLine("Enter name of the product");
            newProduct.Name = Console.ReadLine();

            bool validInput = false;
            int price = 0;
            Console.WriteLine("Enter Price of the product: ");
            while (!validInput)
            {
                validInput = int.TryParse(Console.ReadLine(), out price);
            }
            newProduct.Price = price;

            Console.WriteLine("Enter a description of the product");
            newProduct.ProductInformation = Console.ReadLine();
        }

        public void PrintSingleProduct(Product product)
        {
            string output = string.Format("{0}: {1} monies. {2}.", product.Name, product.Price, product.ProductInformation);

            Console.WriteLine(output);
        }

        public void PrintSingleProductForCart(Product product)
        {
            string output = string.Format("{0}: {1} monies. {2}. Amount: {3}",
                product.Name, product.Price, product.ProductInformation, 
                lists.AmountList.ElementAt(lists.CartList.IndexOf(product)));

            Console.WriteLine(output);
        }
    }
}
