using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_4
{
    public abstract class Vehicle
    {
        public int Price { get; set; }
        public int NewInStock { get; set; } = 0;
        public int UsedInStock { get; set; } = 0;
        public string Manufacturer { get; set; }
        public string Model { get; set; }
    }
}