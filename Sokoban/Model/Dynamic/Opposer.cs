using Sokoban.Model.Interface;
using Sokoban.Model.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model.Dynamic
{
    class Opposer : DynamicGameObject, ITickable
    {
        private bool _sleepy;

        public override void Destroy()
        {
            return;
        }

        public override char GetIcon()
        {
            return _sleepy ? 'Z' : '$';
        }

        public override void Move(Direction direction)
        {
            StaticGameObject to = ObjectBelow.Neighbours[direction];
            if (to.ObjectOnTop != null) to.ObjectOnTop.Push(direction);
            to.MoveOnTop(this);
        }

        public override void Push(Direction direction)
        {
            _sleepy = false;
        }

        public void Tick()
        {
            int sleepChance = new Random().Next(100);
            if (_sleepy)
            {
                if(sleepChance < 10) _sleepy = false;
            }
            else
            {
                if (sleepChance < 25) _sleepy = true;
            }

            if (!_sleepy)
            {
                Array values = Enum.GetValues(typeof(Direction));
                Random random = new Random();
                Direction randomDirection = (Direction)values.GetValue(random.Next(values.Length));
                Move(randomDirection);
            }
        }
    }
}
