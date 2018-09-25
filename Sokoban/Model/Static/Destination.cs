using Sokoban.Model.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model.Static
{
    class Destination : StaticGameObject
    {
        private IMaze _maze;

        public override void AddToMaze(IMaze maze)
        {
            _maze = maze;
            _maze.RequiredScoreChangeEvent(1);
        }

        public override char GetIcon()
        {
            return ObjectOnTop == null ? 'X' : ObjectOnTop.GetIcon();
        }

        public override void MoveOnTop(DynamicGameObject gameObject)
        {
            if (ObjectOnTop == null)
            {
                gameObject.ObjectBelow.MoveOff();
                ObjectOnTop = gameObject;
                gameObject.ObjectBelow = this;
                _maze.ScoreChangeEvent(1);
            }
        }

        public override void MoveOff()
        {
            if (ObjectOnTop != null)
            {
                ObjectOnTop = null;
                _maze.ScoreChangeEvent(-1);
            }
        }
    }
}
