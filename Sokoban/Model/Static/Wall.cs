using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Wall : StaticGameObject
    {
        public override bool canLinkObjectOnTop()
        {
            throw new NotImplementedException();
        }

        public override char GetIcon()
        {
            throw new NotImplementedException();
        }
    }
}
