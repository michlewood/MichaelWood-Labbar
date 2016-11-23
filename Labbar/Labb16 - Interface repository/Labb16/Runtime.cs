using Labb16.Interfaces;
using Labb16.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb16
{
    class Runtime
    {
        IProductRepository FileRepository = new FileProductRepository();
        IProductRepository ListRepository = new ListProductRepository();
        public void Start()
        {

        }
    }
}
