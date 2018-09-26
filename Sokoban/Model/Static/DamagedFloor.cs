using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model.Dynamic;
using Sokoban.Model.Interface;

namespace Sokoban.Model.Static
{
    class DamagedFloor : StaticGameObject
    {
        private int _health = 3;

        public override void AddToMaze(IMaze maze)
        {
            return;
        }

        public override char GetIcon()
        {
            if (ObjectOnTop != null) return ObjectOnTop.GetIcon();
            return _health > 0 ? '~' : ' ';
        }

        public override void MoveOnTop(DynamicGameObject gameObject)
        {
            if (ObjectOnTop == null)
            {
                gameObject.ObjectBelow.MoveOff();
                ObjectOnTop = gameObject;
                gameObject.ObjectBelow = this;

                if (_health <= 0)
                {
                    gameObject.Destroy();
                }

                _health--;
            }
        }

        public override void MoveOff()
        {
            ObjectOnTop = null;
        }

        public override void UpdateScore()
        {
            return;
        }
    }
}
