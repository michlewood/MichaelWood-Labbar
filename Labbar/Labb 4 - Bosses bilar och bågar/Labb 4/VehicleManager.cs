using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_4
{
    public class VehicleManager
    {
        public List<Vehicle> VehiclesInStock { get; set; }

        public VehicleManager()
        {
            VehiclesInStock = new List<Vehicle>()
            {
                new Car {Price = 200, Manufacturer = "ManufacturerNr1", Model = "CarModel1", isNew = true},
                new Car {Price = 123, Manufacturer = "ManufacturerNr1", Model = "CarModel2", isNew = true},
                new Car {Price = 290, Manufacturer = "ManufacturerNr2", Model = "CarModel1", isNew = true},
                new Motorcycle {Price = 100, Manufacturer = "ManufacturerNr3", Model = "MotorbikeModel1", isNew = true},
                new Motorcycle {Price = 200, Manufacturer = "ManufacturerNr3", Model = "MotorbikeModel2", isNew = true}
            };
        }

        public void ShowStock()
        {
            foreach (var vehicle in VehiclesInStock)
            {
                Console.WriteLine("{0}: {1} {2} price: {3}", vehicle.GetType().ToString().Substring(7), vehicle.Manufacturer, vehicle.Model, vehicle.Price);
            }
        }
    }
}