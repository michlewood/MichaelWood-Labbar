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
        IEnvironment currentEnvironment;
        public void Start()
        {
            HelpScreen();
            Console.ReadKey(true);
            CreateEnvironments();
            currentEnvironment = MyLists.Environments[0];
            GameLoop();

            Console.Clear();
            Console.WriteLine("You won!");
            Console.ReadKey(true);
        }

        private void CreateEnvironments()
        {
            Room newRoom = new Room(0, "You are in a dark room lit only by some candles", "You see a man in the flickering candlelight");
            newRoom.NonPlayerCharacters.Add(new Human { Name = "Old man" });
            MyLists.Environments.Add(newRoom);

            newRoom = new Room(1, "You are in a lit room", "You see sunlight come in through the window, you realize you must be near the outdoors");

            MyLists.Environments.Add(newRoom);

            Yard newYard = new Yard(2, "You are outside", "The sun shines down on you as you bask in the sun. As you look around you see a dog sitting infront of you.");
            newYard.NonPlayerCharacters.Add(new Dog { Name = "Dog" });
            MyLists.Environments.Add(newYard);
        }

        private void GameLoop()
        {
            while (!TheEpicQuest.QuestComplete)
            {
                Console.Clear();
                Map();
                Console.WriteLine("{0}", currentEnvironment.Description);
                Commands();
            }
        }

        private void Commands()
        {
            Console.WriteLine("What do you want to do: ");
            var input = Console.ReadLine();

            checkMovement(input);

            if (input.ToLower() == "h")
            {
                HelpScreen();
            }

            if (input.ToLower() == "observe")
            {
                Console.Clear();
                currentEnvironment.Observe();
            }
            if (input.Length > 5 && input.Substring(0, 5).ToLower() == "talk ")
                foreach (var npc in currentEnvironment.NonPlayerCharacters)
                {
                    if (input.Substring(5).ToLower() == npc.Name.ToLower())
                    {
                        Console.Clear();
                        npc.Talk();
                    }
                    else Console.WriteLine("There is no such creature");
                }
            if (3 < input.Length && input.Length <= 5 && input.Substring(0, 4).ToLower() == "talk")
            {
                Console.WriteLine("Please enter with whom you wish to speak");
            }

            Console.ReadKey(true);
        }

        private void HelpScreen()
        {
            Console.Clear();
            Map();
            Console.WriteLine("Movment:");
            Console.WriteLine("n (to go north)");
            Console.WriteLine("s (to go south)");
            Console.WriteLine("e (to go east)");
            Console.WriteLine("w (to go west)");
            Console.WriteLine();
            Console.WriteLine("observe (see a description of the room and whats in the room. Creatures you can talk to names are in white)");
            Console.WriteLine("talk [name] (enter the name of the person/animal you wish to speak to");
            Console.WriteLine();
            Console.WriteLine("h to open the help screen (this screen)");
        }

        private void checkMovement(string input)
        {
            if (input == "n")
            {
                if (currentEnvironment.PositionInMap % 3 != 0 && MyLists.Environments[currentEnvironment.PositionInMap - 1] != null)
                {
                    currentEnvironment = MyLists.Environments[currentEnvironment.PositionInMap - 1];
                    Console.WriteLine("You went north");
                }
                else Console.WriteLine("Can't go there!");
            }

            if (input == "s")
            {
                if (currentEnvironment.PositionInMap % 3 != 2 && MyLists.Environments[currentEnvironment.PositionInMap + 1] != null)
                {
                    currentEnvironment = MyLists.Environments[currentEnvironment.PositionInMap + 1];
                    Console.WriteLine("You went south");
                }
                else Console.WriteLine("Can't go there!");
            }

            if (input == "e")
            {
                if (currentEnvironment.PositionInMap + 3 < MyLists.Environments.Count && MyLists.Environments[currentEnvironment.PositionInMap + 3] != null)
                {
                    currentEnvironment = MyLists.Environments[currentEnvironment.PositionInMap + 1];
                    Console.WriteLine("You went east");
                }
                else Console.WriteLine("Can't go there!");
            }

            if (input == "w")
            {
                if (currentEnvironment.PositionInMap - 3 > 0 && MyLists.Environments[currentEnvironment.PositionInMap - 3] != null)
                {
                    currentEnvironment = MyLists.Environments[currentEnvironment.PositionInMap - 3];
                    Console.WriteLine("You went west");
                }
                else Console.WriteLine("Can't go there!");
            }
        }

        private void Map()
        {
            int highestPositionInMap = 0;
            foreach (var room in MyLists.Environments)
            {
                if (room.PositionInMap > highestPositionInMap) highestPositionInMap = room.PositionInMap;
            }
            string[] mapTiles = new string[highestPositionInMap + 1];


            for (int i = 0; i < mapTiles.Length; i++)
            {
                if (MyLists.Environments.Find(x => x.PositionInMap == i) == null) mapTiles[i] = "";
                else if (i == currentEnvironment.PositionInMap)
                {
                    mapTiles[i] = "@";
                }

                else mapTiles[i] = "#";
            }

            for (int i = 0; i < mapTiles.Length; i++)
            {
                if ((i) % 3 == 0)
                {
                    if (mapTiles[i] == "") Console.Write("   ");
                    else Console.Write("[{0}]", mapTiles[i]);
                }
            }
            Console.WriteLine();
            for (int i = 0; i < mapTiles.Length; i++)
            {
                if ((i) % 3 == 1)
                {
                    if (mapTiles[i] == "") Console.Write("   ");
                    else Console.Write("[{0}]", mapTiles[i]);
                }
            }
            Console.WriteLine(); for (int i = 0; i < mapTiles.Length; i++)
            {
                if ((i) % 3 == 2)
                {
                    if (mapTiles[i] == "") Console.Write("   ");
                    else Console.Write("[{0}]", mapTiles[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
