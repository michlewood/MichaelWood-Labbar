using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3
{
    abstract public class Event
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Location { get; set; }

        public string Description()
        {
            return string.Format("{0} at {1}. Price {2}", Name, Location, Price);
        }
    }
}