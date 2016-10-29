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
                Console.ResetColor();
            }

            else if (!TheEpicQuest.HalfwayPoint)
            {
                while (true)
                {
                    Graphics.Clear(5, 6);
                    Console.WriteLine("This is probably the dog the old man asked about. Will you bring it with you (Y/N)");
                    var input = Console.ReadKey(true).Key;
                    switch (input)
                    {
                        case ConsoleKey.Y:
                            TheEpicQuest.HalfwayPoint = true;
                            Console.WriteLine("You pick up the dog and put it in your backpack.");
                            return true;
                        case ConsoleKey.N:
                            Console.WriteLine("The dog just looks at you.");
                            return false;
                        default:
                            break;
                    }
                }
            }
            return false;
        }

        public override string Observe()
        {
            string text = "The dog is just sitting around the yard. It seems to be waiting for something or someone.";
            if(TheEpicQuest.QuestStarted) text += "\nMaybe the old man. Maybe you can help (or not whatever).";
            return text;
        }
    }
}
