using Sokoban.Model.Dynamic;
using Sokoban.Model.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Maze
    {
        public StaticGameObject MazeCorner { get; set; }
        public Player Player { get; set; }

        public bool IsSolved()
        {
            return false;
        }
    }
}
