using Sokoban.Model.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model.Dynamic
{
    abstract class DynamicGameObject
    {
        public StaticGameObject ObjectBelow { get; set; }

        public abstract void Move(Direction direction);

        public abstract void Push(Direction direction);

        public abstract char GetIcon();
    }
}
