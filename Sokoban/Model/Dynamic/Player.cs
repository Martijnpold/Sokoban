using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Player : DynamicGameObject
    {
        public override bool IsSolved { get { return true; } set { this.IsSolved = value; } }

        public override char GetIcon()
        {
            return '@';
        }

        public override void move(Direction direction)
        {
            throw new NotImplementedException();
        }
    }
}
