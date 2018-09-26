using Sokoban.Model.Dynamic;
using Sokoban.Model.Interface;
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
        private bool _hasScore;

        public override void AddToMaze(IMaze maze)
        {
            _maze = maze;
            _maze.RequiredScoreChangeEvent(1);
        }

        public override char GetIcon()
        {
            if (_hasScore) return 'Ø';
            return ObjectOnTop == null ? 'X' : ObjectOnTop.GetIcon();
        }

        public override void MoveOnTop(DynamicGameObject gameObject)
        {
            if (ObjectOnTop == null)
            {
                gameObject.ObjectBelow.MoveOff();
                ObjectOnTop = gameObject;
                gameObject.ObjectBelow = this;
            }
        }

        public override void MoveOff()
        {
            if (ObjectOnTop != null)
            {
                ObjectOnTop = null;
                if(_hasScore) _maze.ScoreChangeEvent(-1);
                _hasScore = false;
            }
        }

        public override void UpdateScore()
        {
            _maze.ScoreChangeEvent(1);
            _hasScore = true;
        }
    }
}
