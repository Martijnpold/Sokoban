﻿using Sokoban.Model;
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
        public InputView _inputView;
        public OutputView _outputView;
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
            while (true)
            {
                _outputView.PrintMainMenuView();
                ConsoleKey input = _inputView.getKeyPress();
                if (input == ConsoleKey.D1) PlayLevel(1);
                if (input == ConsoleKey.D2) PlayLevel(2);
                if (input == ConsoleKey.D3) PlayLevel(3);
                if (input == ConsoleKey.D4) PlayLevel(4);
                if (input == ConsoleKey.S) QuitGame();
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
                _outputView.PrintLevelView(Maze);
                ConsoleKey input = _inputView.getKeyPress();
                if (input == ConsoleKey.LeftArrow) DoMove(Direction.Left);
                if (input == ConsoleKey.UpArrow) DoMove(Direction.Up);
                if (input == ConsoleKey.RightArrow) DoMove(Direction.Right);
                if (input == ConsoleKey.DownArrow) DoMove(Direction.Down);
                if (input == ConsoleKey.R) PlayLevel(Maze.Id);
                if (input == ConsoleKey.S) SelectLevel();
                if (IsFinished()) FinishLevel();
            }
        }

        public void DoMove(Direction direction)
        {
            Maze.Player.Move(direction);
        }

        public bool IsFinished()
        {
            return Maze.IsSolved();
        }

        public void FinishLevel()
        {
            _outputView.PrintWinView(Maze);
            _inputView.getKeyPress();
            SelectLevel();
        }

        public void QuitGame()
        {
            Environment.Exit(0);
        }

        public void doMove()
        {
            _outputView.PrintWinView(Maze);
            _inputView.getKeyPress();
            SelectLevel();
        }
    }
}
