using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb13.Models;
namespace Labb13.Filters
{
    class TypeFilters
    {
        public static bool LowTypeness(Models.Type type)
        {
            return type.Typeness < 6; 
        }

        public static bool HighTypeness(Models.Type type)
        {
            return type.Typeness > 10;
        }

        public static bool IsTypeType1(Models.Type type)
        {
            return CheackTypeType(type, Models.Type.TypesOfType.Type1);
        }

        private static bool CheackTypeType(Models.Type type, Models.Type.TypesOfType typeType)
        {
            return type.TypeType == typeType;
        }
    }
}
