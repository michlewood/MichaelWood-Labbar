using Labb15.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb15.Models
{
    class Car : IVehicle
    {
        public bool Locked { get; set; }
        public bool Started { get; set; }

        public void Lock()
        {
            if (Locked)
            {
                Console.WriteLine("Already locked");
            }
            else
            {
                Console.WriteLine("Car locked");
                Locked = true;
            }
        }

        public void Start()
        {
            if (Started)
            {
                Console.WriteLine("Already going");
            }
            else
            {
                Console.WriteLine("The Car starts");
                Started = true;
            }
        }

        public void Stop()
        {
            if (!Started)
            {
                Console.WriteLine("The Car is still");
            }
            else
            {
                Console.WriteLine("The Brakes seem to be broken. You cant stop!");
            }
        }

        public void Unlock()
        {
            if (Locked)
            {
                Console.WriteLine("Already unlocked");
            }
            else
            {
                Console.WriteLine("Car unlocked");
                Locked = false;
            }
        }
}
