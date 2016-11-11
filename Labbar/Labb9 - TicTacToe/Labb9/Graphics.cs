using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb9
{
    class Graphics
    {
        public static void GameboardGraphics(Gameboard gb)
        {
            PlayerScoresGraphics();

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (gb.Grid[i, j].Player == 1)
                    {
                        Console.Write("X│");
                    }
                    else if (gb.Grid[i, j].Player == 2)
                    {
                        Console.Write("O│");
                    }
                    else Console.Write(" │");
                }

                if (gb.Grid[i, 2].Player == 1)
                {
                    Console.WriteLine("X");
                }
                else if (gb.Grid[i, 2].Player == 2)
                {
                    Console.WriteLine("O");
                }
                else Console.WriteLine(" ");
                Console.WriteLine("─┼─┼─");
            }
            for (int j = 0; j < 2; j++)
            {
                if (gb.Grid[2, j].Player == 1)
                {
                    Console.Write("X│");
                }
                else if (gb.Grid[2, j].Player == 2)
                {
                    Console.Write("O│");
                }
                else Console.Write(" │");
            }
            if (gb.Grid[2, 2].Player == 1)
            {
                Console.WriteLine("X");
            }
            else if (gb.Grid[2, 2].Player == 2)
            {
                Console.WriteLine("O");
            }
            else Console.WriteLine(" ");

        }

        private static void PlayerScoresGraphics()
        {
            var row = 1;
            Console.SetCursorPosition(8, row++);
            Console.WriteLine("Scores:");
            Console.SetCursorPosition(8, row++);
            Console.WriteLine("Player One: {0}", Runtime.PlayerScores[0]);
            Console.SetCursorPosition(8, row++);
            Console.WriteLine("Player Two: {0}", Runtime.PlayerScores[1]);
            Console.SetCursorPosition(0, 1);
        }
    }
}
