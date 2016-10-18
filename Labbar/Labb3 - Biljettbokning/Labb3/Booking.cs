using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb3
{
    public class Booking
    {
        public string BookingHolder { get; set; }
        public Event BookedEvent { get; set; }

        public string Description()
        {
            return string.Format("Booking Holder: {0}. {1}: {2}", BookingHolder, BookedEvent.GetType().ToString().Substring(6) ,BookedEvent.Description());
        }
    }
}
