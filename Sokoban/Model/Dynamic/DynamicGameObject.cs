using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    abstract class DynamicGameObject
    {
        public StaticGameObject ObjectBelow { get; set; }
        public abstract bool IsSolved { get; set; }

        public void LinkObjectBelow(StaticGameObject gameObject)
        {
            gameObject.ObjectOnTop = this;
            ObjectBelow = gameObject;
        }

        public abstract void move(Direction direction);

        public abstract char GetIcon();
    }
}
