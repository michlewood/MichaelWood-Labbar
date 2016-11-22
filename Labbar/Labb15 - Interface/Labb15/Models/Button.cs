using Labb15.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb15.Models
{
    class Button : IPushable
    {
        public void Push()
        {
            Console.WriteLine("Please do not push this button again!");
        }
    }
}
