using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6.Models.Creatures
{
    class Dog : Animal
    {
        public Dog(string name = "Dog") : base (name)
        {

        }
        public override bool Talk()
        {
            if (!TheEpicQuest.QuestStarted)
            {
                Console.WriteLine("You try talking to the dog, it does not reply. You feel foolish.");
                Console.ReadKey(true);
                Console.ResetColor();
            }

            else if (!TheEpicQuest.HalfwayPoint)
            {
                Console.WriteLine("This is probobly the dog the old man asked about. Will you bring it with you (Y/N)");
                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.Y:
                        TheEpicQuest.HalfwayPoint = true;
                        Console.WriteLine("You pick up the dog and put it in your backpack.");
                        return true;
                    case ConsoleKey.N:
                        Console.WriteLine("The dog just looks at you.");
                        break;
                    default:
                        break;
                }
            }
            return false;
        }  
    }
}
