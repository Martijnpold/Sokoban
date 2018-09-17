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
        public DynamicGameObject ObjectOnTop { get; private set; }
        public bool IsFree { get { return (ObjectOnTop == null && CanMoveOnTop()); } }

        public StaticGameObject()
        {
            Neighbours = new Dictionary<Direction, StaticGameObject>();
        }

        public virtual void MoveOff()
        {
            if (!IsFree) ObjectOnTop.ObjectBelow = null;
            ObjectOnTop = null;
        }

        public virtual void MoveOnTop(DynamicGameObject gameObject)
        {
            ObjectOnTop = gameObject;
            gameObject.ObjectBelow = this;
        }

        public abstract bool CanMoveOnTop();

        public char GetIcon()
        {
            if (!CanMoveOnTop()) return GetEmptyIcon();
            return (IsFree) ? GetEmptyIcon() : ObjectOnTop.GetIcon();
        }

        public abstract char GetEmptyIcon();
    }
}
