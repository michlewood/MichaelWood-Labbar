using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6.Models.Creatures
{
    class QuestGiver : Human
    {
        public override bool Talk()
        {
            if (TheEpicQuest.QuestComplete)
            {
                Console.WriteLine("{0}: Time for me to go home.", Name);
                return true;
            }
            if (!TheEpicQuest.QuestStarted)
            {
                Console.WriteLine("{0}: Can you help me find my dog? (Y/N)", Name);
                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.Y:
                        TheEpicQuest.QuestStarted = true;
                        Console.WriteLine("{0}: Thank you", Name);
                        break;
                    case ConsoleKey.N:
                        Console.WriteLine("{0}: To bad, if you change your mind i'll be here.", Name);
                        break;
                    default:
                        break;
                }
            }
            else if (!TheEpicQuest.HalfwayPoint)
            {
                Console.WriteLine("{0}:Please find my dog!", Name);
            }

            else if (TheEpicQuest.HalfwayPoint)
            {
                Console.WriteLine("{0}: You found my dog thank you so much!", Name);
                TheEpicQuest.QuestComplete = true;
            }

            return false;
        }
    }
}
