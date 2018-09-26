using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model.Interface
{
    interface IMaze
    {
        void ScoreChangeEvent(int score);

        void RequiredScoreChangeEvent(int score);
    }
}
