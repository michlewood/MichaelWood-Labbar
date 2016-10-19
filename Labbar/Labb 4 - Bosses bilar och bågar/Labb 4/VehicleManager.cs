using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_4
{
    public class VehicleManager
    {
        public Lists lists = new Lists();

        public VehicleManager()
        {

            lists.AddType(new Car { Price = 200, Manufacturer = "ManufacturerNr1", Model = "CarModel1" });
            lists.AddType(new Car { Price = 123, Manufacturer = "ManufacturerNr1", Model = "CarModel2" });
            lists.AddType(new Car { Price = 290, Manufacturer = "ManufacturerNr2", Model = "CarModel3" });
            lists.AddType(new Car { Price = 290, Manufacturer = "ManufacturerNr2", Model = "CarModel4" });
            lists.AddType(new Motorcycle { Price = 100, Manufacturer = "ManufacturerNr3", Model = "MotorbikeModel1" });
            lists.AddType(new Motorcycle { Price = 200, Manufacturer = "ManufacturerNr3", Model = "MotorbikeModel2" });

            lists.AddToStock(0, true, 6);
            lists.AddToStock(0, false, 3);
            lists.AddToStock(1, true, 10);
            lists.AddToStock(2, false, 4);
            lists.AddToStock(3, false, 0);
            lists.AddToStock(4, false, 3);
            lists.AddToStock(4, true, 7);
            lists.AddToStock(5, false, 5);
        }

        public void AddTypeOfVehicle()
        {
            Menus.ShowCurrentMenu(lists.currentList);
            bool loop = false;

            do
            {
                loop = false;
                Console.WriteLine("Är det en (b)il eller en (m)otorcykel?");

                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.B: AddNewTypeOfCar(); break;
                    case ConsoleKey.M: AddNewTypeOfMotorcycle(); break;
                    default: loop = true; break;
                }
            } while (loop);
        }

        private void AddNewTypeOfCar()
        {
            Car newCar = new Car();
            AddNewTypeOfVehicle(newCar);
            lists.AddType(newCar);
        }

        private void AddNewTypeOfMotorcycle()
        {
            Motorcycle newMotorcycle = new Motorcycle();
            AddNewTypeOfVehicle(newMotorcycle);
            lists.AddType(newMotorcycle);
        }

        private void AddNewTypeOfVehicle(Vehicle newVehicle)
        {
            Console.WriteLine("Vem är tillverkaren?");
            newVehicle.Manufacturer = Console.ReadLine();
            Console.WriteLine("Vilken modell är bilen?");
            newVehicle.Model = Console.ReadLine();
            Console.WriteLine("Vad är priset?");
            bool validInput = false;

            int Price = 0;
            while (!validInput)
            {
                Console.Write("Pris: ");
                validInput = int.TryParse(Console.ReadLine(), out Price);
            }
            newVehicle.Price = Price;

        }

        public void RemoveTypeOfVehicle()
        {
            Menus.ShowCurrentMenu(lists.currentList);
            Console.WriteLine("Välj ett fordonstyp att ta bort:");

            int vehicleToRemove;

            bool validInput = int.TryParse(Console.ReadLine(), out vehicleToRemove);
            if (!validInput || vehicleToRemove > lists.currentList.Count || vehicleToRemove < 1)
            {
                Console.WriteLine("Inget borttaget");
                Console.ReadKey(true);
                return;
            }
            lists.VehiclesInStock.Remove(lists.currentList[vehicleToRemove - 1]);

            Console.WriteLine("Fordonstyp borttagen!");
            Console.ReadLine();
        }

        public void AddToStock()
        {
            Menus.ShowCurrentMenu(lists.currentList);
            Console.WriteLine("Välj ett fordonstyp att lägga till:");

            int vehicleToAddToo;

            bool validInput = int.TryParse(Console.ReadLine(), out vehicleToAddToo);
            if (!validInput || vehicleToAddToo > lists.currentList.Count || vehicleToAddToo < 1)
            {
                Console.WriteLine("Inget tillagd");
                Console.ReadKey(true);
                return;
            }

            validInput = false;
            int amount = 0;

            while (!validInput)
            {
                Console.WriteLine("Hur många vill du lägga till?");
                validInput = int.TryParse(Console.ReadLine(), out amount);
            }

            do
            {
                validInput = true;
                Console.WriteLine("Är bilen begagnad (Y/N)?");
                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.Y:
                        lists.currentList[vehicleToAddToo - 1].UsedInStock += amount;
                        break;
                    case ConsoleKey.N:
                        lists.currentList[vehicleToAddToo - 1].NewInStock += amount;
                        break;
                    default: validInput = false; break;
                }
            } while (!validInput);

            Console.WriteLine("Fordonen har lagts till!");
            Console.ReadLine();
        }

        public void RemoveFromStock()
        {
            Menus.ShowCurrentMenu(lists.currentList);
            Console.WriteLine("Välj ett fordonstyp att ta bort ifrån:");

            int vehicleToRemoveFrom;

            bool validInput = int.TryParse(Console.ReadLine(), out vehicleToRemoveFrom);
            if (!validInput || vehicleToRemoveFrom > lists.currentList.Count || vehicleToRemoveFrom < 1)
            {
                Console.WriteLine("Inget borttaget");
                Console.ReadKey(true);
                return;
            }

            validInput = false;
            int amount = 0;
            while (!validInput)
            {
                Console.WriteLine("Hur många vill du ta bort?");
                validInput = int.TryParse(Console.ReadLine(), out amount);
            }
            do
            {
                validInput = true;
                Console.WriteLine("vill du ta bort begagnade (Y/N)?");
                var input = Console.ReadKey(true).Key;

                switch (input)
                {
                    case ConsoleKey.Y:
                        lists.currentList[vehicleToRemoveFrom - 1].UsedInStock -= amount;
                        if (lists.currentList[vehicleToRemoveFrom - 1].UsedInStock < 0)
                            lists.currentList[vehicleToRemoveFrom - 1].UsedInStock = 0;
                        break;
                    case ConsoleKey.N:
                        lists.currentList[vehicleToRemoveFrom - 1].NewInStock -= amount;
                        if (lists.currentList[vehicleToRemoveFrom - 1].NewInStock < 0)
                            lists.currentList[vehicleToRemoveFrom - 1].NewInStock = 0;
                        break;
                    default: validInput = false; break;
                }
            } while (!validInput);
            Console.WriteLine("Fordonet har tagits bort!");
            Console.ReadLine();
        }
    }
}