using Labb6.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb6
{
    class Graphics
    {
        public static void HelpScreen()
        {
            Console.Clear();
            Console.WriteLine("Movment:");
            Console.WriteLine("\"n\" (to go north)");
            Console.WriteLine("\"s\" (to go south)");
            Console.WriteLine("\"e\" (to go east)");
            Console.WriteLine("\"w\" (to go west)");
            Console.WriteLine();
            Console.WriteLine("\"observe\" (see a description of the room and whats in the room. Creatures you can talk to names are in white)");
            Console.WriteLine("\"talk\" (if there is only one creature in the Envornment you can just type talk to speak to it.)");
            Console.WriteLine("\"talk [name]\" (enter the name of the person/animal you wish to speak to");
            Console.WriteLine();
            Console.WriteLine("\"h\" to open the help screen (this screen)");
        }

        public static void Map(IEnvironment currentEnvironment)
        {
            Console.WriteLine("Map:");
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

            for (int i = 0; i < 3; i++)
            {
                for (int j = i; j < mapTiles.Length; j += 3)
                {
                    if (mapTiles[j] == "") Console.Write("   ");
                    else Console.Write("[{0}]", mapTiles[j]);
                }
                Console.WriteLine();
            }
        }
    }
}
