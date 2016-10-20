using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_4
{
    public class VehicleManager
    {
        public Lists lists = new Lists();

        public static bool InStockOn { get; private set; }
        public static bool CarOn { get; private set; } = true;
        public static bool MotorcycleOn { get; private set; } = true;

        public static int CurrentMenuChoice { get; set; }

        public VehicleManager()
        {

            lists.AddType(new Car { Price = 200, Manufacturer = "ManufacturerNr1", Model = "CarModel1" });
            lists.AddType(new Car { Price = 123, Manufacturer = "ManufacturerNr1", Model = "CarModel2" });
            lists.AddType(new Car { Price = 290, Manufacturer = "ManufacturerNr2", Model = "CarModel3" });
            lists.AddType(new Car { Price = 100, Manufacturer = "ManufacturerNr2", Model = "CarModel4" });
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
            Console.CursorVisible = true;

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
                    case ConsoleKey.Escape: return;
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
            Vehicle vehicleChoice = VehicleChooser("Välj ett fordonstyp att ta bort");
            if (vehicleChoice == null) return;
            lists.VehiclesInStock.Remove(vehicleChoice);
            Menus.ShowCurrentMenu(lists.currentList);
            Console.WriteLine("Fordonstyp borttagen!");
            Console.ReadKey(true);
        }

        public void AddToStock()
        {
            Menus.ShowCurrentMenu(lists.currentList);
            Vehicle vehicleChoice = VehicleChooser("Välj ett fordontyp att öka mängden hos");

            if (vehicleChoice == null) return;

            bool validInput = false;
            int amount = 0;
            Console.CursorVisible = true;

            while (!validInput)
            {
                Menus.ShowCurrentMenuChooser(lists.currentList);
                Console.WriteLine("Hur många vill du lägga till?");
                validInput = int.TryParse(Console.ReadLine(), out amount);
            }
            Runtime.MenuChoice = 0;
            Console.CursorVisible = false;

            while (true)
            {
                Menus.ShowCurrentMenuChooser(lists.currentList);
                Menus.NewOrUsed();
                if (AddNewOrOld(vehicleChoice, amount)) return;
            }
        }

        private bool AddNewOrOld(Vehicle vehicleToAddToo, int amount)
        {
            var input = Console.ReadKey(true).Key;

            switch (input)
            {
                case ConsoleKey.Enter:
                    if (Runtime.MenuChoice == 0) vehicleToAddToo.NewInStock += amount;
                    if (Runtime.MenuChoice == 1) vehicleToAddToo.UsedInStock += amount;
                    Menus.ShowCurrentMenuChooser(lists.currentList);
                    Console.WriteLine("Fordonen har lagts till!");
                    Console.ReadKey(true);
                    return true;
                case ConsoleKey.DownArrow:
                    if (Runtime.MenuChoice == 1) Runtime.MenuChoice = 0;
                    else Runtime.MenuChoice++;
                    break;
                case ConsoleKey.UpArrow:
                    if (Runtime.MenuChoice == 0) Runtime.MenuChoice = 1;
                    else Runtime.MenuChoice--;
                    break;
                default: break;
            }
            return false;
        }

        public void RemoveFromStock()
        {
            Menus.ShowCurrentMenu(lists.currentList);
            Vehicle vehicleChoice = VehicleChooser("Välj ett fordonstyp att ta bort ifrån");

            if (vehicleChoice == null) return;
            bool validInput = false;
            int amount = 0;
            Console.CursorVisible = true;

            while (!validInput)
            {
                Menus.ShowCurrentMenuChooser(lists.currentList);
                Console.WriteLine("Hur många vill du ta bort?");
                validInput = int.TryParse(Console.ReadLine(), out amount);
            }
            Runtime.MenuChoice = 0;
            Console.CursorVisible = false;

            while (true)
            {
                Menus.ShowCurrentMenuChooser(lists.currentList);
                Menus.NewOrUsed();
                if(RemoveNewOrOld(vehicleChoice, amount)) return;
            }
        }

        private bool RemoveNewOrOld(Vehicle vehicleToRemoveFrom, int amount)
        {
            var input = Console.ReadKey(true).Key;

            FiltersMenu(input);

            switch (input)
            {
                case ConsoleKey.Enter:
                    if (Runtime.MenuChoice == 0)
                    {
                        vehicleToRemoveFrom.NewInStock -= amount;
                        if (vehicleToRemoveFrom.NewInStock < 0)
                            vehicleToRemoveFrom.NewInStock = 0;
                    }
                    if (Runtime.MenuChoice == 1)
                    {
                        vehicleToRemoveFrom.UsedInStock -= amount;
                        if (vehicleToRemoveFrom.UsedInStock < 0)
                            vehicleToRemoveFrom.UsedInStock = 0;
                    }
                    Menus.ShowCurrentMenuChooser(lists.currentList);
                    Console.WriteLine("Fordonen har tagits bort!");
                    Console.ReadKey(true);
                    return true;
                case ConsoleKey.DownArrow:
                    if (Runtime.MenuChoice == 1) Runtime.MenuChoice = 0;
                    else Runtime.MenuChoice++;
                    break;
                case ConsoleKey.UpArrow:
                    if (Runtime.MenuChoice == 0) Runtime.MenuChoice = 1;
                    else Runtime.MenuChoice--;
                    break;
                default: break;
            }
            return false;
        }

        private Vehicle VehicleChooser(string comment)
        {
            CurrentMenuChoice = 0;

            while (true)
            {
                Console.Clear();
                Vehicle vehicleToReturn = Menus.ShowCurrentMenuChooser(lists.currentList);
                Console.WriteLine(comment);

                var input = Console.ReadKey(true).Key;

                FiltersMenu(input);

                switch (input)
                {
                    case ConsoleKey.Enter:
                        Menus.ShowCurrentMenuChooser(lists.currentList);
                        return vehicleToReturn;
                    case ConsoleKey.DownArrow:
                        if (CurrentMenuChoice == lists.currentList.Count - 1) CurrentMenuChoice = 0;
                        else CurrentMenuChoice++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (CurrentMenuChoice == 0) CurrentMenuChoice = lists.currentList.Count - 1;
                        else CurrentMenuChoice--;
                        break;
                    case ConsoleKey.Escape:
                        return null;
                    default: break;
                }
            }
        }

        public void FiltersMenu(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    InStockOn = !InStockOn;
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    CarOn = !CarOn;
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    MotorcycleOn = !MotorcycleOn;
                    break;

                default:
                    break;
            }
            UpdateCurrentList();
        }

        public void UpdateCurrentList()
        {
            lists.VehiclesInStock = lists.VehiclesInStock.OrderBy(vehicle => vehicle.GetType().ToString()).ToList();
            lists.currentList = lists.VehiclesInStock;
            if (InStockOn) lists.currentList = lists.currentList
                         .Where(vehicle => (vehicle.NewInStock != 0 || vehicle.UsedInStock != 0)
                         || !InStockOn).ToList();
            if (!CarOn) lists.currentList = lists.currentList
                        .Where(vehicle => vehicle.GetType().ToString() != "Labb_4.Car").ToList();
            if (!MotorcycleOn) lists.currentList = lists.currentList
                        .Where(vehicle => vehicle.GetType().ToString() != "Labb_4.Motorcycle").ToList();
        }
    }
}