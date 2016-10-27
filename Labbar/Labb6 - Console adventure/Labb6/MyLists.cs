using Labb6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6
{
    class MyLists
    {
        static List<IEnvironment> environments;

        public static List<IEnvironment> Environments
        {
            get
            {
                if (environments == null)
                    environments = new List<IEnvironment>();

                return environments;
            }
        }
    }
}
