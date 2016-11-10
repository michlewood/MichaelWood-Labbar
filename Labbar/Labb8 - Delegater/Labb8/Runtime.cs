using Labb8.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Labb8.MyDelegates;

namespace Labb8
{
    class Runtime
    {


        public void Start()
        {
            MyDelegates delegates = new MyDelegates();

            #region G-Uppgift
            //StringConcatinator scDel = StringConcatinatorMethod;
            //NumberOperator noDelAdder = NumberOperatorAddMethod;
            //NumberOperator noDelmultiplier = NumberOperatorMultiplierMethod;
            //MyLists lists = new MyLists();
            //string stringer = scDel(lists.StringList);
            //Console.WriteLine(stringer);
            //float floatResult = noDelAdder(lists.FloatList);
            //Console.WriteLine(floatResult);
            //floatResult = noDelmultiplier(lists.FloatList);
            //Console.WriteLine(floatResult);
            #endregion

            ProductManager productManager = new ProductManager();
            StringConcatinator scDel = delegates.StringConcatinatorMethod;
            NumberOperator noDelAddWithTax = delegates.NumberOperatorAddWithTaxMethod;
            NumberOperator noDelAddOver1000 = delegates.NumberOperatorAddOver1000AndOnly90ProcentOfSum;

            while (true)
            {
                Console.Clear();
                Graphics.MainMenuGraphics();

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        Console.WriteLine("Names:");
                        Console.WriteLine(productManager.FormatProductNames(scDel));
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        Console.WriteLine("Sum of prices with tax:");
                        Console.WriteLine(productManager.PriceCalculation(noDelAddWithTax));
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        Console.WriteLine("90% of sum of prices for products over 1000 kr:");
                        Console.WriteLine(productManager.PriceCalculation(noDelAddOver1000));
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        return;
                    default:
                        break;
                }
            }

        }
    }
}
