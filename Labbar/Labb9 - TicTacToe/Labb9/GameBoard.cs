using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb9
{
    class Gameboard
    {
        Node[,] grid;
        public Node[,] Grid
        {
            get
            {
                return grid;
            }
        }

        public Gameboard()
        {
            grid = new Node[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    grid[i, j] = new Node();
                }
            }
        }

        public bool PlaceMarker(int row, int col, int player)
        {
            if (grid[row, col].Taken == false)
            {
                grid[row, col].Taken = true;
                grid[row, col].Player = player;
                return true;
            }
            else return false;
        }
    }
}
