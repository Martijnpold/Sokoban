using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    abstract class StaticGameObject
    {
        private Dictionary<Direction, StaticGameObject> _dictionary;
        public DynamicGameObject ObjectOnTop { get; set; }

        public StaticGameObject()
        {
            _dictionary = new Dictionary<Direction, StaticGameObject>();
        }

        public StaticGameObject GetObjectAt(Direction direction)
        {
            return _dictionary[direction];
        }

        public void SetObjectAt(Direction direction, StaticGameObject gameObject)
        {
            _dictionary[direction] = gameObject;
        }

        public void LinkObjectOnTop(DynamicGameObject gameObject)
        {
            gameObject.ObjectBelow = this;
            ObjectOnTop = gameObject;
        }

        public abstract bool canLinkObjectOnTop();

        public abstract char GetIcon();
    }
}
