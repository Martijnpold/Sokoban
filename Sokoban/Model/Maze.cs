using Sokoban.Model.Dynamic;
using Sokoban.Model.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class Maze : IMaze
    {
        public StaticGameObject MazeCorner { get; set; }
        public Player Player { get; set; }
        public int RequiredScore { get; set; }
        public int Score { get; set; }
        public int Id { get; set; }

        public Maze(int id)
        {
            Id = id;
        }

        public void ScoreChangeEvent(int score)
        {
            Score += score;
        }

        public void RequiredScoreChangeEvent(int score)
        {
            RequiredScore += score;
        }
    }
}
