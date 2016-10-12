using System;
using System.Collections.Generic;

namespace Labb1
{
    internal class Runtime
    {

        List<Dog> dogs = new List<Dog>();

        public void Start()
        {
            Menu();       
        }

        private void Menu()
        {
            bool loop = false;

            do
            {
                loop = false;

                Console.WriteLine("Choose one: ");
                Console.WriteLine("1. Add new");
                Console.WriteLine("2. Remove");
                Console.WriteLine("3. Show info");
                Console.WriteLine("4. Exit");

                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        AddNew();
                        break;
                    case 2:
                        Remove();
                        break;
                    case 3:
                        ShowInfo();
                        break;
                    case 4:
                        Exit();
                        break;
                    default:
                        loop = true;
                        break;
                }
            } while (loop);
        }

        private void AddNew()
        {
            throw new NotImplementedException();
        }

        private void Remove()
        {
            int i = 0;
            foreach (var dog in dogs)
            {
                i++;
                Console.WriteLine(dog.Introduction());
            }
        }

        private void ShowInfo()
        {
            foreach (var dog in dogs)
            {
                Console.WriteLine(dog.Introduction());
            }

            Console.ReadLine();
        }

        private void Exit()
        {
            return;
        }
    }
}
}