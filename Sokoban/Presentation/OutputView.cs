using Sokoban.Model;
using Sokoban.Model.Static;
using Sokoban.Proces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Presentation
{
    class OutputView
    {
        public void PrintMaze(Maze maze)
        {
            StaticGameObject x, y;
            bool xDone, yDone;
            y = maze.MazeCorner;
            yDone = false;
            while (!yDone)
            {
                x = y;
                xDone = false;
                while (!xDone)
                {
                    Console.Write(x.GetIcon());
                    xDone = !x.Neighbours.ContainsKey(Direction.Right);
                    if (!xDone) x = x.Neighbours[Direction.Right];
                }
                Console.Write("\n");
                yDone = !y.Neighbours.ContainsKey(Direction.Down);
                if (!yDone) y = y.Neighbours[Direction.Down];
            }
        }
    }
}
