using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4
{
    public class Lists
    {
        public List<Vehicle> VehiclesInStock { get; set; }
        public List<Vehicle> currentList { get; set; }
        public List<List<Vehicle>> VehicleList { get; set; }

        public Lists()
        {
            VehiclesInStock = new List<Vehicle>();
            VehicleList = new List<List<Vehicle>>();
        }

        public void AddType(Vehicle vehicle)
        {
            VehiclesInStock.Add(vehicle);
            VehicleList.Add(new List<Vehicle> { vehicle });
        }

        public void AddToStock(int indexOFVehicle, bool isNew = true, int nrToAdd = 1)
        {
            for (int i = 0; i < nrToAdd; i++)
            {
                if (isNew) VehiclesInStock[indexOFVehicle].NewInStock++;
                else VehiclesInStock[indexOFVehicle].UsedInStock++;
            }
        }

        public void addVehicle(int indexOFVehicleType, string description)
        {
            if (VehicleList[indexOFVehicleType][0].GetType().ToString() == "Labb_4.Car")
            {
                VehicleList[indexOFVehicleType].Add(
                    new Car
                    {
                        Manufacturer = VehicleList[indexOFVehicleType][0].Manufacturer,
                        Model = VehicleList[indexOFVehicleType][0].Model,
                        Price = VehicleList[indexOFVehicleType][0].Price
                    });
            }
            else if (VehicleList[indexOFVehicleType][0].GetType().ToString() == "Labb_4.Motorcycle")
            {
                VehicleList[indexOFVehicleType].Add(
                    new Motorcycle
                    {
                        Manufacturer = VehicleList[indexOFVehicleType][0].Manufacturer,
                        Model = VehicleList[indexOFVehicleType][0].Model,
                        Price = VehicleList[indexOFVehicleType][0].Price
                    });
            }
        }
    }
}
