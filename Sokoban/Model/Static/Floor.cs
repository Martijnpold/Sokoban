using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model.Dynamic;

namespace Sokoban.Model.Static
{
    class Floor : StaticGameObject
    {
        public override bool CanMoveOnTop()
        {
            return true;
        }

        public override char GetEmptyIcon()
        {
            return '·';
        }
    }
}
