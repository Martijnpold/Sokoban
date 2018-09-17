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
        public override bool CanMoveOnTop()
        {
            return true;
        }

        public override char GetEmptyIcon()
        {
            return 'x';
        }

        public override void MoveOnTop(DynamicGameObject gameObject)
        {
            gameObject.IsOnDestination = true;
            base.MoveOnTop(gameObject);
        }

        public override void MoveOff()
        {
            ObjectOnTop.IsOnDestination = false;
            base.MoveOff();
        }
    }
}
