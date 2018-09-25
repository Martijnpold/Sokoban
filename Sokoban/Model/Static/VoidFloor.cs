﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Model.Dynamic;
using Sokoban.Model.Interface;

namespace Sokoban.Model.Static
{
    class VoidFloor : StaticGameObject
    {
        public override void AddToMaze(IMaze maze)
        {
            return;
        }

        public override char GetIcon()
        {
            return ' ';
        }

        public override void MoveOnTop(DynamicGameObject gameObject)
        {
            gameObject.Destroy();
        }

        public override void MoveOff()
        {
            return;
        }

        public override void UpdateScore()
        {
            return;
        }
    }
}
