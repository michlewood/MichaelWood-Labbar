
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb5.Controllers;

namespace Labb5
{
    class Client
    {
        public void Start()
        {
            MenusController menuController = new MenusController();
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                UI.PrintMainMenu();
                loop = menuController.MainMenuChooser(loop);
            }
        }
    }
}
