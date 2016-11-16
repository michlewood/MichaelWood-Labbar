using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb13
{
    class Type
    {
        public string Name { get; set; }
        public enum TypesOfType
        {
            Type1 = 1,
            Type2,
            Type3
        }
        public TypesOfType TypeType { get; set; }
        public int Typeness { get; set; }
    }
}
