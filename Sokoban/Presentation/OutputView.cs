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
        private Controller _controller;

        public OutputView(Controller controller)
        {
            _controller = controller;
        }

        public void PrintMaze()
        {
            StaticGameObject x, y;
            bool xDone, yDone;
            y = _controller.Maze.MazeCorner;
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
