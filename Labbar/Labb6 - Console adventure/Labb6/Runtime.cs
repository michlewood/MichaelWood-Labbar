using Labb6.Interfaces;
using Labb6.Models;
using Labb6.Models.Creatures;
using Labb6.Models.Environments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6
{
    class Runtime
    {
        public static IEnvironment CurrentEnvironment { get; private set; }

        public void Start()
        {
            Graphics.HelpScreen();
            Console.ReadKey(true);
            CreateEnvironments();
            CurrentEnvironment = MyLists.Environments[0];
            GameLoop();

            Console.Clear();
            Console.WriteLine("You won!");
            Console.ReadKey(true);
        }

        private void CreateEnvironments()
        {
            IEnvironment newEnvironment = new Room(0, "You are in a dark room lit only by some candles", "You see a man in the flickering candlelight");
            newEnvironment.NonPlayerCharacters.Add(new QuestGiver { Name = "Old man" });
            newEnvironment.NonPlayerCharacters.Add(new Rat());
            MyLists.Environments.Add(newEnvironment);

            newEnvironment = new Room(1, "You are in a lit room", "You see sunlight come in through the window, you realize you must be near the outdoors");
            MyLists.Environments.Add(newEnvironment);

            newEnvironment = new Yard(2, "You are outside",
                "The sun shines down on you as you bask in the sun. As you look around you see a dog sitting infront of you.",
                "The sun shines down on you as you bask in the sun.");
            newEnvironment.NonPlayerCharacters.Add(new Dog());
            MyLists.Environments.Add(newEnvironment);

            newEnvironment = new Yard(5, "You are in a garden", "You see lots of pretty flowers");
            MyLists.Environments.Add(newEnvironment);
        }

        private void GameLoop()
        {
            while (!TheEpicQuest.QuestComplete)
            {
                Console.Clear();
                Graphics.Map(CurrentEnvironment);
                Console.WriteLine("{0}", CurrentEnvironment.Description);
                Commands();
                CurrentEnvironment.UpdateDescription();
            }
        }

        private void Commands()
        {
            Console.WriteLine("What do you want to do: ");
            var input = Console.ReadLine();

            if (CheckMovement(input)) { }

            else if (input.ToLower() == "h")
            {
                Graphics.HelpScreen();
            }

            else if (input.ToLower() == "observe")
            {
                Console.Clear();
                CurrentEnvironment.Observe();
            }

            else if (CheckTalk(input)) { }

            else Console.WriteLine("Invalid action");

            Console.ReadKey(true);
        }

        private bool CheckTalk(string input)
        {
            INonPlayerCharacter npcToRemove = null;
            if (input.ToLower() == "talk" && CurrentEnvironment.NonPlayerCharacters.Count == 1)
            {
                Console.Clear();
                if (CurrentEnvironment.NonPlayerCharacters[0].Talk()) npcToRemove = CurrentEnvironment.NonPlayerCharacters[0];
                if (npcToRemove != null) CurrentEnvironment.NonPlayerCharacters.Remove(npcToRemove);
                return true;
            }
            else if (input.Length > 5 && input.Substring(0, 5).ToLower() == "talk ")
            {
                foreach (var npc in CurrentEnvironment.NonPlayerCharacters)
                {
                    if (input.Substring(5).ToLower() == npc.Name.ToLower())
                    {
                        Console.Clear();
                        if (npc.Talk()) npcToRemove = npc;
                        if (npcToRemove != null) CurrentEnvironment.NonPlayerCharacters.Remove(npcToRemove);
                        return true;
                    }
                }
                Console.WriteLine("There is no such creature");
            }
            else if (3 < input.Length && input.Length <= 5 && input.Substring(0, 4).ToLower() == "talk")
            {
                Console.WriteLine("Please enter with whom you wish to speak");
                return true;
            }
            return false;
        }

        private bool CheckMovement(string input)
        {
            if (input != "n" && input != "s" && input != "e" && input != "w") return false;

            else if (input == "n")
            {
                if (MyLists.Environments.
                    Find(environment => environment.PositionInMap == CurrentEnvironment.PositionInMap - 1) != null)
                    {
                        CurrentEnvironment = MyLists.Environments.
                            Find(environment => environment.PositionInMap == CurrentEnvironment.PositionInMap - 1);

                    Console.WriteLine("You went north");
                }
                else Console.WriteLine("Can't go there!");
            }

            else if (input == "s")
            {
                if (MyLists.Environments.
                    Find(environment => environment.PositionInMap == CurrentEnvironment.PositionInMap + 1) != null)
                {
                    CurrentEnvironment = MyLists.Environments.
                        Find(environment => environment.PositionInMap == CurrentEnvironment.PositionInMap + 1);

                    Console.WriteLine("You went south");
                }
                else Console.WriteLine("Can't go there!");
            }

            else if (input == "e")
            {
                if (MyLists.Environments.
                    Find(environment => environment.PositionInMap == CurrentEnvironment.PositionInMap + 3) != null)
                {
                    CurrentEnvironment = MyLists.Environments.
                        Find(environment => environment.PositionInMap == CurrentEnvironment.PositionInMap + 3);
                    Console.WriteLine("You went east");
                }
                else Console.WriteLine("Can't go there!");
            }

            else if (input == "w")
            {
                if (MyLists.Environments.
                    Find(environment => environment.PositionInMap == CurrentEnvironment.PositionInMap - 3) != null)
                {
                    CurrentEnvironment = MyLists.Environments.
                        Find(environment => environment.PositionInMap == CurrentEnvironment.PositionInMap - 3);
                    Console.WriteLine("You went west");
                }
                else Console.WriteLine("Can't go there!");
            }
            return true;
        }
    }
}
