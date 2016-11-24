using Labb16.Interfaces;
using Labb16.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
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
            while (true)
            {
                FileRepository.Add();
                foreach (var product in FileRepository.GetAll())
                {
                    Console.WriteLine(product.Name);
                }
                FileRepository.Update(FileRepository.Get(0));
                //FileRepository.Delete(int.Parse(Console.ReadLine()));
            }
        }
    }
}
