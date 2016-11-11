using Labb7.DataStores;
using Labb7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb7.Manager
{
    class MenusManager
    {
        public static int MainMenuChoice { get; set; }
        public static int CartMenuChoice { get; set; }
        public static int CurrentMenuChoice { get; set; }
        public static int MenuChoice { get; set; }

        public void FiltersMenu(ConsoleKey input, MyLists myLists)
        {
            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Graphics.ElecronicsOn = !Graphics.ElecronicsOn;
                    CurrentMenuChoice = 0;
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Graphics.ToysOn = !Graphics.ToysOn;
                    CurrentMenuChoice = 0;
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Graphics.VideoGamesOn = !Graphics.VideoGamesOn;
                    CurrentMenuChoice = 0;
                    break;
                default:
                    break;
            }
            myLists.UpdateCurrentList();
        }

        public bool MainMenuChooser(ProductManager productManager)
        {
            bool loop = true;
            Console.CursorVisible = false;
            Graphics.PrintMainMenu();
            var input = Console.ReadKey(true).Key;
            FiltersMenu(input, productManager.lists);
            MainMenuChoice = MenuChooser(MainMenuChoice, 4, input);
            if (input == ConsoleKey.Enter)
            {
                switch (MainMenuChoice)
                {
                    case 0:
                        Console.Clear();
                        productManager.TypeOfProductToAdd();
                        MenuChoice = 0;
                        break;
                    case 1:
                        Console.Clear();
                        RemoveMenu(productManager);
                        MenuChoice = 0;
                        break;
                    case 2:
                        CartMenu(productManager);
                        break;
                    case 3:
                        loop = false;
                        break;
                    default:
                        break;
                }
            }
            return loop;
        }

        private void CartMenu(ProductManager productManager)
        {
            while (true)
            {
                Graphics.ShowCurrentMenu(productManager.lists.CartList, productManager, false, true);

                Graphics.PrintCartMenu();

                var input = Console.ReadKey(true).Key;
                FiltersMenu(input, productManager.lists);
                CartMenuChoice = MenuChooser(CartMenuChoice, 3, input);
                if (input == ConsoleKey.Enter)
                {
                    switch (CartMenuChoice)
                    {
                        case 0:
                            AddProductToCart(productManager);
                            break;
                        case 1:
                            if (productManager.lists.CartList.Count != 0)
                            {
                                EditAmountProductChoice(productManager); 
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Add products to cart");
                                Console.ReadKey(true);
                            }
                            break;
                        case 2:
                            return;
                        default:
                            break;
                    }
                }

                if (input == ConsoleKey.Escape)
                {
                    return;
                }
            }
        }

        private void EditAmountProductChoice(ProductManager productManager)
        {
            while (true)
            {
                Graphics.ShowCurrentMenu(productManager.lists.CartList, productManager, true, true);
                var input = Console.ReadKey(true).Key;
                FiltersMenu(input, productManager.lists);
                CurrentMenuChoice = MenuChooser(CurrentMenuChoice, productManager.lists.CartList.Count, input);
                if (input == ConsoleKey.Enter)
                {
                    Product ProductToEditAmount = productManager.lists.CartList[CurrentMenuChoice];
                    EditAmount(ProductToEditAmount, productManager);
                    return;
                }
            }
        }

        private void EditAmount(Product productToEditAmount, ProductManager productManager)
        {
            var validInput = false;
            var newAmount = 0;

            while (!validInput)
            {
                Console.Clear();
                productManager.PrintSingleProductForCart(productToEditAmount);
                Console.WriteLine("Enter new amount (0 to remove)");
                validInput = int.TryParse(Console.ReadLine(), out newAmount);
                if (newAmount < 0) newAmount = 0;
            }

            productManager.lists.AmountList[productManager.lists.CartList.IndexOf(productToEditAmount)] = newAmount;
            if (productManager.lists.AmountList[productManager.lists.CartList.IndexOf(productToEditAmount)] == 0)
            {
                productManager.lists.AmountList.RemoveAt(productManager.lists.CartList.IndexOf(productToEditAmount));
                productManager.lists.CartList.Remove(productToEditAmount);
            }
        }

        private void AddProductToCart(ProductManager productManager)
        {
            while (true)
            {
                Console.Clear();
                Graphics.ShowCurrentMenu(productManager.lists.CurrentProducts, productManager, true);
                var input = Console.ReadKey(true).Key;
                FiltersMenu(input, productManager.lists);
                CurrentMenuChoice = MenuChooser(CurrentMenuChoice, productManager.lists.CurrentProducts.Count, input);
                if (input == ConsoleKey.Enter)
                {
                    Product NewProductForCart = productManager.lists.CurrentProducts[CurrentMenuChoice];
                    if (productManager.lists.CartList.Contains(NewProductForCart) == false)
                    {
                        productManager.lists.CartList.Add(NewProductForCart);
                        productManager.lists.AmountList.Add(1);
                    }
                    return; 
                }
            }
        }

        private void RemoveMenu(ProductManager productManager)
        {
            CurrentMenuChoice = 0;
            while (true)
            {
                Graphics.ShowCurrentMenu(productManager.lists.CurrentProducts, productManager, true);
                var input = Console.ReadKey(true).Key;
                FiltersMenu(input, productManager.lists);
                CurrentMenuChoice = MenuChooser(CurrentMenuChoice, productManager.lists.CurrentProducts.Count, input);
                if (input == ConsoleKey.Enter)
                {
                    Product productToRemove = productManager.lists.CurrentProducts[CurrentMenuChoice];
                    productManager.lists.Products.Remove(productToRemove);
                    productManager.lists.UpdateCurrentList();
                    return;
                }
            }
        }

        private int MenuChooser(int menuChoice, int sizeOfMenu, ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.UpArrow:
                    menuChoice--;
                    if (menuChoice < 0) menuChoice = sizeOfMenu - 1;
                    break;
                case ConsoleKey.DownArrow:
                    menuChoice++;
                    if (menuChoice == sizeOfMenu) menuChoice = 0;
                    break;
                default:
                    break;
            }

            return menuChoice;
        }
    }
}
