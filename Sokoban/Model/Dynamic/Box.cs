using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model.Dynamic
{
    class Box : DynamicGameObject
    {
        public override bool IsSolved { get { return IsSolved; } set { this.IsSolved = value; } }

        public override char GetIcon()
        {
            return (IsSolved) ? 'O' : 'Ø';
        }

        public override void move(Direction direction)
        {
            throw new NotImplementedException();
        }
    }
}
