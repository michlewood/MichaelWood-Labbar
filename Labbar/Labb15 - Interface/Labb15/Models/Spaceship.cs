using Labb15.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb15.Models
{
    class Spaceship : IVehicle
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
                Console.WriteLine("Spaceship locked");
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
                Console.WriteLine("The Spaceship Explodes");
            }
        }

        public void Stop()
        {
            if (!Started)
            {
                Console.WriteLine("The Spaceship is still");
            }
            else
            {
                Console.WriteLine("The Spaceship Stops");
                Started = false;
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
                Console.WriteLine("Bicycle unlocked");
                Locked = false;
            }
        }
}
