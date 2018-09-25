using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model.Dynamic;
using Sokoban.Model.Interface;

namespace Sokoban.Model.Static
{
    class Floor : StaticGameObject
    {
        public override void AddToMaze(IMaze maze)
        {
            return;
        }

        public override char GetIcon()
        {
            return ObjectOnTop == null ? '·' : ObjectOnTop.GetIcon();
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
            ObjectOnTop = null;
        }

        public override void UpdateScore()
        {
            return;
        }
    }
}
