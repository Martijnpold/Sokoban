using Sokoban.Model.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model.Dynamic
{
    class Box : DynamicGameObject
    {
        public override char GetIcon()
        {
            return 'O';
        }

        public override void Move(Direction direction)
        {
            Push(direction);
        }

        public override void Push(Direction direction)
        {
            StaticGameObject to = ObjectBelow.Neighbours[direction];
            to.MoveOnTop(this);
        }
    }
}
