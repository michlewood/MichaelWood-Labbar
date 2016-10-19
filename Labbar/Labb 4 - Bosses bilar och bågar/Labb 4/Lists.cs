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

        public Lists()
        {
            VehiclesInStock = new List<Vehicle>();
        }

        public void AddToStock(int indexOFVehicle, bool isNew = true, int nrToAdd = 1)
        {
            for (int i = 0; i < nrToAdd; i++)
            {
                if (isNew) VehiclesInStock[indexOFVehicle].NewInStock++;
                else VehiclesInStock[indexOFVehicle].UsedInStock++;
            }
        }

        public void AddType(Vehicle vehicle)
        {
            VehiclesInStock.Add(vehicle);
        }
    }
}
