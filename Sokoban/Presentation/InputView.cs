﻿using Sokoban.Proces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Presentation
{
    class InputView
    {
        private char getKeyPress()
        {
            return Console.ReadKey().KeyChar;
        }
    }
}
