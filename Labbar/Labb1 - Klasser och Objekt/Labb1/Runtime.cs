using System;
using System.Collections.Generic;

namespace Labb1
{
    internal class Runtime
    {

        List<Dog> dogs = new List<Dog>()
            ;

        public void Start()
        {
            Menu();       
        }

        private void Menu()
        {
            while (true)
            {
                bool loop = false;

                do
                {
                    Console.Clear();
                    loop = false;

                    Console.WriteLine("Choose one: ");
                    Console.WriteLine("1. Add new");
                    Console.WriteLine("2. Remove");
                    Console.WriteLine("3. Show info");
                    Console.WriteLine("4. Exit");

                    int input;
                        
                    bool validInput  = int.TryParse(Console.ReadLine(), out input);
                    if (!validInput) input = -1;

                    switch (input)
                    {
                        case 1:
                            AddNewDogToList();
                            break;
                        case 2:
                            RemoveDogFromList();
                            break;
                        case 3:
                            ShowDogList();
                            Console.ReadLine();
                            break;
                        case 4:
                            return;

                        default:
                            loop = true;
                            break;
                    }
                } while (loop); 
            }
        }

        private void AddNewDogToList()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            int age = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Age: ");
                validInput = int.TryParse(Console.ReadLine(), out age); 
            }

            Console.WriteLine("Breed: ");
            string breed = Console.ReadLine();

            dogs.Add(new Dog { Name = name, Age = age, Breed = breed });
            Console.WriteLine("Dog added!");
            Console.ReadLine();
        }

        private void RemoveDogFromList()
        {
            ShowDogList();

            if (dogs.Count == 0)
            {
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Choose a dog to remove:");

            int dogToRemove;

            bool validInput = int.TryParse(Console.ReadLine(), out dogToRemove);
            if (!validInput || dogToRemove > dogs.Count || dogToRemove < 1) return;

            dogs.RemoveAt(dogToRemove - 1);

            Console.WriteLine("Dog removed!");
            Console.ReadLine();
        }

        private void ShowDogList()
        {
            int i = 0;
            if (dogs.Count == 0)
            {
                Console.WriteLine("Listan är tom!");
                return;
            }
            foreach (var dog in dogs)
            {
                i++;
                Console.WriteLine("{0}: {1}", i, dog.Introduction());
            }
        }
    }
}
