using Labb6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6.Models.Creatures
{
    class Human : INonPlayerCharacter
    {
        public string Name { get; set; }

        public string Observe()
        {
            return "You see a person";
        }

        public void Talk()
        {
            if (TheEpicQuest.QuestComplete)
            {
                Console.WriteLine("Thank you again.");
            }
            if (!TheEpicQuest.QuestStarted)
            {
                Console.WriteLine("Can you help me find my dog? (Y/N)");
                var input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.Y:
                        TheEpicQuest.QuestStarted = true;
                        Console.WriteLine("Thank you");
                        break;
                    case ConsoleKey.N:
                        Console.WriteLine("To bad, if you change your mind i'll be here.");
                        break;
                    default:
                        break;
                } 
            }
            else if (!TheEpicQuest.HalfwayPoint)
            {
                Console.WriteLine("Please find my dog!");
            }

            else if (TheEpicQuest.HalfwayPoint)
            {
                Console.WriteLine("You found my dog thank you so much!");
                TheEpicQuest.QuestComplete = true;
            }
        }
    }
}
