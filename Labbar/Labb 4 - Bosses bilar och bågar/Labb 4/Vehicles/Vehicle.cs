using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb_4
{
    public abstract class Vehicle
    {
        public int Price { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public bool isNew { get; set; }
    }
}