﻿using Sokoban.Model;
using Sokoban.Model.Dynamic;
using Sokoban.Model.Static;
using Sokoban.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Proces
{
    class Parser
    {
        public Maze Maze { get; set; }

        public void ParseMaze(int id)
        {
            Maze = new Maze();

            string[] lines = System.IO.File.ReadAllLines("Doolhof/doolhof" + id + ".txt");

            //Find maze size
            int mazeHeight = lines.Length;
            int mazeWidth = 0;
            foreach (string line in lines)
            {
                if (line.Length > mazeWidth) mazeWidth = line.Length;
            }

            //Create all maze objects
            StaticGameObject[,] mazeLayout = new StaticGameObject[mazeWidth, mazeHeight];
            for (int lineNr = 0; lineNr < mazeHeight; lineNr++)
            {
                String line = lines[lineNr];
                for (int charNr = 0; charNr < line.Length; charNr++)
                {
                    char tile = line[charNr];
                    switch (tile)
                    {
                        //Wall
                        case '#':
                        mazeLayout[charNr, lineNr] = new Wall();
                        break;

                        //Floor
                        case '.':
                        case ' ':
                        mazeLayout[charNr, lineNr] = new Floor();
                        break;

                        //Destination
                        case 'x':
                        mazeLayout[charNr, lineNr] = new Destination();
                        break;

                        //Box
                        case 'o':
                        mazeLayout[charNr, lineNr] = new Floor();
                        mazeLayout[charNr, lineNr].MoveOnTop(new Box());
                        break;

                        //Player
                        case '@':
                        mazeLayout[charNr, lineNr] = new Floor();
                        Maze.Player = new Player();
                        mazeLayout[charNr, lineNr].MoveOnTop(Maze.Player);
                        break;

                        default:
                        mazeLayout[charNr, lineNr] = new Floor();
                        break;
                    }
                }
            }

            //Link all tiles
            for (int x = 0; x < mazeLayout.GetLength(0); x++)
            {
                for (int y = 0; y < mazeLayout.GetLength(1); y++)
                {
                    StaticGameObject tile = mazeLayout[x, y];
                    foreach (Direction dir in Enum.GetValues(typeof(Direction)))
                    {
                        int x1 = x;
                        int y1 = y;

                        switch (dir)
                        {
                            case Direction.Up:
                            y1--;
                            break;
                            case Direction.Right:
                            x1++;
                            break;
                            case Direction.Down:
                            y1++;
                            break;
                            case Direction.Left:
                            x1--;
                            break;
                        }

                        if (x1 >= 0 && x1 < mazeLayout.GetLength(0))
                            if (y1 >= 0 && y1 < mazeLayout.GetLength(1))
                                tile.Neighbours[dir] = mazeLayout[x1, y1];
                    }
                }
            }

            Maze.MazeCorner = mazeLayout[0, 0];

            Controller controller = new Controller() { Maze = this.Maze };
            OutputView output = new OutputView(controller);
            controller.StartGame();
            output.PrintMaze();
        }
    }
}
