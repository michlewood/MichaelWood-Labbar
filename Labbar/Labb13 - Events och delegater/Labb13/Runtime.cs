using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb13
{
    class Runtime
    {
        TypeManager typeManager = new TypeManager();

        public void Start()
        {
            ProgramLoop();
        }

        private void ProgramLoop()
        {
            while (true)
            {
                Console.Clear();
                Graphics.PrintTypesList(typeManager.Types);
                typeManager.AddType();
            }
        }

        
    }
}
