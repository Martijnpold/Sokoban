using Sokoban.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Proces
{
    class Controller
    {
        public Maze Maze { get; set; }

        public void StartGame()
        {
            Maze.Player.Move(Direction.Up);
            Maze.Player.Move(Direction.Right);
            Maze.Player.Move(Direction.Right);
            Maze.Player.Move(Direction.Down);
            Maze.Player.Move(Direction.Right);
            Maze.Player.Move(Direction.Up);
        }

        public void QuitGame()
        {

        }

        public void SelectLevel()
        {

        }

        public void doMove()
        {

        }
    }
}
