using Labb15.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb15.Models
{
    class Boulder : IPushable
    {
        public void Push()
        {
            Console.WriteLine("The Boulder starts rolling");
        }
    }
}
