using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model.Static
{
    class Wall : StaticGameObject
    {
        public override bool CanMoveOnTop()
        {
            return false;
        }

        public override char GetEmptyIcon()
        {
            return '#';
        }
    }
}
