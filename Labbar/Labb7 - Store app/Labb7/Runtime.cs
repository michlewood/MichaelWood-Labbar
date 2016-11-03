using Labb7.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb7
{
    class Runtime
    {
        public void Start()
        {
            ProductManager productManager = new ProductManager();
            MenusManager menusManager = new MenusManager();

            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Graphics.ShowCurrentMenu(productManager.lists.CurrentProducts);
                loop = menusManager.MainMenuChooser(productManager.lists); 
            }
        }
    }
}
