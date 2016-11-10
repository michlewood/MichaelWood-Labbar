using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb9
{
    class Runtime
    {
        int CurrentPlayer { get; set; } = 1;
        public static int[] PlayerScores { get; set; } = { 0, 0 };
        bool won = false;
        Gameboard gb = new Gameboard();
        public event EventHandler GameOver;


        public void Start()
        {
            GameLoop();
        }

        private void GameLoop()
        {
            var loop = true;
            GameOver += (sender, e) =>
            {
                Console.Clear();
                if (won == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Player {0} Won", CurrentPlayer == 1 ? "One" : "Two");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    PlayerScores[CurrentPlayer - 1]++;
                    won = false;
                }
                else Console.WriteLine("Board is full");
                Graphics.GameboardGraphics(gb);
                Console.ReadKey(true);
                gb = new Gameboard();
                CurrentPlayer = 0;
            };

            while (loop)
            {
                Console.Clear();
                Console.WriteLine("Player {0} turn", CurrentPlayer == 1 ? "Ones" : "Twos");
                Graphics.GameboardGraphics(gb);


                bool validMove = ReadInput();

                CheckIfOver();

                if (validMove)
                {
                    if (CurrentPlayer == 1) CurrentPlayer = 2;
                    else CurrentPlayer = 1; 
                }
            }
        }

        private void CheckIfOver()
        {
            CheckIfWon();
            bool emptyNode = false;
            foreach (var node in gb.Grid)
            {
                if (node.Taken == false)
                {
                    emptyNode = true;
                }
            }
            if (emptyNode == false)
                OnGameOver(EventArgs.Empty);
        }

        private void CheckIfWon()
        {
            for (int i = 0; i < 3; i++)
            {
                if (gb.Grid[i, 0].Taken && gb.Grid[i, 1].Taken && gb.Grid[i, 2].Taken 
                    && gb.Grid[i, 0].Player == gb.Grid[i, 1].Player 
                    && gb.Grid[i, 0].Player == gb.Grid[i, 2].Player)
                {
                    won = true;
                }
                else if (gb.Grid[0, i].Taken && gb.Grid[1, i].Taken && gb.Grid[2, i].Taken
                    && gb.Grid[0, i].Player == gb.Grid[1, i].Player
                    && gb.Grid[0, i].Player == gb.Grid[2, i].Player)
                {
                    won = true;
                }
            }

            if (gb.Grid[0, 0].Taken && gb.Grid[1,1].Taken && gb.Grid[2, 2].Taken
                    && gb.Grid[0, 0].Player == gb.Grid[1, 1].Player
                    && gb.Grid[0, 0].Player == gb.Grid[2, 2].Player 
                    || gb.Grid[0, 2].Taken && gb.Grid[1, 1].Taken && gb.Grid[2, 0].Taken
                    && gb.Grid[0, 2].Player == gb.Grid[1, 1].Player
                    && gb.Grid[0, 2].Player == gb.Grid[2, 0].Player)
            {
                won = true;
            }

            if (won)
            {
                OnGameOver(EventArgs.Empty);
            }
        }

        private bool ReadInput()
        {
            Console.WriteLine("Make a move (format: row,column)");
            
            var input = Console.ReadLine();

            int row = int.Parse(input[0].ToString())-1;
            int column = int.Parse(input[2].ToString())-1;

            return gb.PlaceMarker(row, column, CurrentPlayer);
        }

        protected virtual void OnGameOver(EventArgs e)
        {
            EventHandler handler = GameOver;

            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
