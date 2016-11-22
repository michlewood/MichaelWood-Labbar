using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb15.Interfaces
{
    interface IVehicle
    {
        bool Locked { get; set; } 
        bool Started { get; set; }

        void Start();
        void Stop();
        void Lock();
        void Unlock();
    }
}
