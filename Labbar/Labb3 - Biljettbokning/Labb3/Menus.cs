using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb3
{
    public class Menus
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine(Runtime.User);
            Console.WriteLine("1. See Bookings");
            Console.WriteLine("2. New Booking");
            Console.WriteLine("3. Exit");
        }

        public static void AddBookingMenu()
        {
            Console.Clear();
            Console.WriteLine(Runtime.User);
            Console.WriteLine("What Kind of Event do you wish to see?");
            Console.WriteLine("1. Concerts");
            Console.WriteLine("2. Films");
            Console.WriteLine("3. Festivals");
            Console.WriteLine("4. Return");
        }
    }
}