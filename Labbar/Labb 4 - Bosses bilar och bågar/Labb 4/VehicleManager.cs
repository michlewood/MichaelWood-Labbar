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
        public static int NewOrUsedMenuChoice { get; set; }

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
                    case ConsoleKey.B: Car newCar = new Car(); AddNewTypeOfVehicle(newCar); break;
                    case ConsoleKey.M: Motorcycle newMotorcycle = new Motorcycle(); AddNewTypeOfVehicle(newMotorcycle); break;
                    case ConsoleKey.Escape: return;
                    default: loop = true; break;
                }
            } while (loop);
        }

        private void AddNewTypeOfVehicle(Vehicle newVehicle)
        {
            Menus.ShowCurrentMenu(lists.currentList);
            Console.WriteLine("Typ: {0}.",
                newVehicle.GetType().ToString().Substring(7) == "Car" ? "Bil" : "Motorcyckel" );
            Console.WriteLine("Vem är tillverkaren?");
            newVehicle.Manufacturer = Console.ReadLine();
            Menus.ShowCurrentMenu(lists.currentList);
            Console.WriteLine("Typ: {0}. Tillverkare: {1}",
                newVehicle.GetType().ToString().Substring(7) == "Car" ? "Bil" : "Motorcyckel",
                newVehicle.Manufacturer);
            Console.WriteLine("Vilken modell är bilen?");
            newVehicle.Model = Console.ReadLine();
            bool validInput = false;

            int Price = 0;
            while (!validInput)
            {
                Menus.ShowCurrentMenu(lists.currentList);
                Console.WriteLine("Typ: {0}. Tillverkare: {1} Modell: {2}",
                newVehicle.GetType().ToString().Substring(7) == "Car" ? "Bil" : "Motorcyckel",
                newVehicle.Manufacturer, newVehicle.Model);
                Console.WriteLine("Vad är priset?");
                validInput = int.TryParse(Console.ReadLine(), out Price);
            }
            newVehicle.Price = Price;

            lists.AddType(newVehicle);
            UpdateCurrentList();
            Menus.ShowCurrentMenu(lists.currentList);
            Console.WriteLine("Typ: {0}. Tillverkare: {1} Modell: {2} Pris: {3}.",
                newVehicle.GetType().ToString().Substring(7) == "Car" ? "Bil" : "Motorcyckel",
                newVehicle.Manufacturer, newVehicle.Model, newVehicle.Price);
            Console.WriteLine("Tillagd i listan!");
            Console.ReadKey(true);

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
                Console.WriteLine("{0}: {1} {2} pris som ny: {3}. Det finns {4} nya och {5} begagnade.",
                                    vehicleChoice.GetType().ToString().Substring(7), vehicleChoice.Manufacturer,
                                    vehicleChoice.Model, vehicleChoice.Price,
                                    vehicleChoice.NewInStock, vehicleChoice.UsedInStock);
                Console.WriteLine("Hur många vill du lägga till?");
                validInput = int.TryParse(Console.ReadLine(), out amount);
            }
            NewOrUsedMenuChoice = 0;
            Console.CursorVisible = false;

            while (true)
            {
                Menus.ShowCurrentMenuChooser(lists.currentList);
                Console.WriteLine("{0}: {1} {2} pris som ny: {3}. Det finns {4} nya och {5} begagnade.",
                                    vehicleChoice.GetType().ToString().Substring(7), vehicleChoice.Manufacturer,
                                    vehicleChoice.Model, vehicleChoice.Price,
                                    vehicleChoice.NewInStock, vehicleChoice.UsedInStock);
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
                    if (NewOrUsedMenuChoice == 0) vehicleToAddToo.NewInStock += amount;
                    if (NewOrUsedMenuChoice == 1) vehicleToAddToo.UsedInStock += amount;
                    Menus.ShowCurrentMenuChooser(lists.currentList);
                    Console.WriteLine("{0}: {1} {2} pris som ny: {3}. Det finns {4} nya och {5} begagnade.",
                                    vehicleToAddToo.GetType().ToString().Substring(7), vehicleToAddToo.Manufacturer,
                                    vehicleToAddToo.Model, vehicleToAddToo.Price,
                                    vehicleToAddToo.NewInStock, vehicleToAddToo.UsedInStock);
                    Console.WriteLine("Fordonen har lagts till!");
                    Console.ReadKey(true);
                    return true;
                case ConsoleKey.DownArrow:
                    if (NewOrUsedMenuChoice == 1) NewOrUsedMenuChoice = 0;
                    else NewOrUsedMenuChoice++;
                    break;
                case ConsoleKey.UpArrow:
                    if (NewOrUsedMenuChoice == 0) NewOrUsedMenuChoice = 1;
                    else NewOrUsedMenuChoice--;
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
                Console.WriteLine("{0}: {1} {2} pris som ny: {3}. Det finns {4} nya och {5} begagnade.",
                                    vehicleChoice.GetType().ToString().Substring(7), vehicleChoice.Manufacturer,
                                    vehicleChoice.Model, vehicleChoice.Price,
                                    vehicleChoice.NewInStock, vehicleChoice.UsedInStock);
                Console.WriteLine("Hur många vill du ta bort?");
                validInput = int.TryParse(Console.ReadLine(), out amount);
            }
            NewOrUsedMenuChoice = 0;
            Console.CursorVisible = false;

            while (true)
            {
                Menus.ShowCurrentMenuChooser(lists.currentList);
                Console.WriteLine("{0}: {1} {2} pris som ny: {3}. Det finns {4} nya och {5} begagnade.",
                                    vehicleChoice.GetType().ToString().Substring(7), vehicleChoice.Manufacturer,
                                    vehicleChoice.Model, vehicleChoice.Price,
                                    vehicleChoice.NewInStock, vehicleChoice.UsedInStock);
                Menus.NewOrUsed();
                if (RemoveNewOrOld(vehicleChoice, amount)) return;
            }
        }

        private bool RemoveNewOrOld(Vehicle vehicleToRemoveFrom, int amount)
        {
            var input = Console.ReadKey(true).Key;

            FiltersMenu(input);

            switch (input)
            {
                case ConsoleKey.Enter:
                    if (NewOrUsedMenuChoice == 0)
                    {
                        vehicleToRemoveFrom.NewInStock -= amount;
                        if (vehicleToRemoveFrom.NewInStock < 0)
                            vehicleToRemoveFrom.NewInStock = 0;
                    }
                    if (NewOrUsedMenuChoice == 1)
                    {
                        vehicleToRemoveFrom.UsedInStock -= amount;
                        if (vehicleToRemoveFrom.UsedInStock < 0)
                            vehicleToRemoveFrom.UsedInStock = 0;
                    }
                    Menus.ShowCurrentMenuChooser(lists.currentList);
                    Console.WriteLine("{0}: {1} {2} pris som ny: {3}. Det finns {4} nya och {5} begagnade.",
                                     vehicleToRemoveFrom.GetType().ToString().Substring(7), vehicleToRemoveFrom.Manufacturer,
                                     vehicleToRemoveFrom.Model, vehicleToRemoveFrom.Price,
                                     vehicleToRemoveFrom.NewInStock, vehicleToRemoveFrom.UsedInStock);
                    Console.WriteLine("Fordonen har tagits bort!");
                    Console.ReadKey(true);
                    return true;
                case ConsoleKey.DownArrow:
                    if (NewOrUsedMenuChoice == 1) NewOrUsedMenuChoice = 0;
                    else NewOrUsedMenuChoice++;
                    break;
                case ConsoleKey.UpArrow:
                    if (NewOrUsedMenuChoice == 0) NewOrUsedMenuChoice = 1;
                    else NewOrUsedMenuChoice--;
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