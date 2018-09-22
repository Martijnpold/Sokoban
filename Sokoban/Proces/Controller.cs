using Sokoban.Model;
using Sokoban.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Proces
{
    class Controller
    {
        private InputView _inputView;
        private OutputView _outputView;
        public Maze Maze { get; set; }

        public Controller()
        {
            _inputView = new InputView();
            _outputView = new OutputView();
            SelectLevel();
        }

        /// <summary>
        /// Show level select screen and wait for a selection to be made.
        /// </summary>
        public void SelectLevel()
        {
            //Show main menu
            while (true)
            {
                char input = _inputView.getKeyPress();
                if (input >= '1' && input <= '4')
                {
                    int selection = input - '1' + 1;
                    PlayLevel(selection);
                    break;
                }
                if (input == 's')
                {
                    QuitGame();
                }
            }
        }

        /// <summary>
        /// Load a level into the Maze property.
        /// </summary>
        /// <param name="id">Level to load</param>
        public void LoadLevel(int id)
        {
            Parser parser = new Parser();
            parser.ParseMaze(id);
            Maze = parser.Maze;
        }

        /// <summary>
        /// Load and play a level.
        /// </summary>
        /// <param name="id">Level to load</param>
        public void PlayLevel(int id)
        {
            LoadLevel(id);

            while (true)
            {
                char input = _inputView.getKeyPress();
                if (input == 37) DoMove(Direction.Left);
                if (input == 38) DoMove(Direction.Up);
                if (input == 39) DoMove(Direction.Right);
                if (input == 40) DoMove(Direction.Down);
                if (input == 'r') { PlayLevel(Maze.Id); break; }
                if (input == 's') { SelectLevel(); break; }
                if (IsFinished()) FinishLevel();
            }
        }

        /// <summary>
        /// Do one game move in a direction.
        /// </summary>
        /// <param name="direction">Direction to move the player in.</param>
        public void DoMove(Direction direction)
        {
            Maze.Player.Move(direction);
        }

        /// <summary>
        /// Check if the level has been solved.
        /// </summary>
        /// <returns>boolean if level has been completed</returns>
        public bool IsFinished()
        {
            return Maze.IsSolved();
        }

        /// <summary>
        /// End the level and show the win screen
        /// </summary>
        public void FinishLevel()
        {
            //Show win screen
            _inputView.getKeyPress();
            SelectLevel();
        }

        /// <summary>
        /// Quit the game (Exits the process).
        /// </summary>
        public void QuitGame()
        {
            Environment.Exit(0);
        }
    }
}
