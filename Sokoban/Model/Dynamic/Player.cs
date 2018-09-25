using Sokoban.Model.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model.Dynamic
{
    class Player : DynamicGameObject
    {
        public override char GetIcon()
        {
            return '@';
        }

        public override void Move(Direction direction)
        {
            StaticGameObject to = ObjectBelow.Neighbours[direction];
            if (to.ObjectOnTop != null) to.ObjectOnTop.Push(direction);
            to.MoveOnTop(this);
        }

        public override void Push(Direction direction)
        {
            return;
        }
    }
}
