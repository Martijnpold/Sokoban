using Sokoban.Model.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model.Static
{
    abstract class StaticGameObject
    {
        public Dictionary<Direction, StaticGameObject> Neighbours { get; }
        public DynamicGameObject ObjectOnTop { get; set; }

        public StaticGameObject()
        {
            Neighbours = new Dictionary<Direction, StaticGameObject>();
        }

        public abstract void MoveOnTop(DynamicGameObject gameObject);

        public abstract void MoveOff();

        public abstract char GetIcon();

        public abstract void AddToMaze(IMaze maze);
    }
}
