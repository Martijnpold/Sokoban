using Sokoban.Model;
using Sokoban.Model.Static;
using Sokoban.Proces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Presentation
{
    class OutputView
    {
        public void PrintMaze(Maze maze)
        {
            StaticGameObject x, y;
            bool xDone, yDone;
            y = maze.MazeCorner;
            yDone = false;
            while (!yDone)
            {
                x = y;
                xDone = false;
                while (!xDone)
                {
                    Console.Write(x.GetIcon());
                    xDone = !x.Neighbours.ContainsKey(Direction.Right);
                    if (!xDone) x = x.Neighbours[Direction.Right];
                }
                Console.Write("\n");
                yDone = !y.Neighbours.ContainsKey(Direction.Down);
                if (!yDone) y = y.Neighbours[Direction.Down];
            }
        }

        public void PrintMainMenuView()
        {
            System.Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║    Welkom Bij Sokoban!                               ║");
            Console.WriteLine("║                                                      ║");
            Console.WriteLine("║    betekenis van de symbolen   ║  doel van het spel  ║");
            Console.WriteLine("║                                ║                     ║");
            Console.WriteLine("║    spatie : outerspace         ║                     ║");
            Console.WriteLine("║         █ : muur               ║  duw met de truck   ║");
            Console.WriteLine("║         · : vloer              ║  de krat(ten)       ║");
            Console.WriteLine("║         O : krat               ║  naar de bestemming ║");
            Console.WriteLine("║         Ø : krat op bestemming ║                     ║");
            Console.WriteLine("║         x : bestemming         ║                     ║");
            Console.WriteLine("║         @ : speler             ║                     ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝");
            Console.WriteLine("");
            Console.WriteLine("> Kies een doolhof (1 - 4) s = stop");
        }

        public void PrintLevelView(Maze maze)
        {
            System.Console.Clear();
            Console.WriteLine("╔═════════════════╗");
            Console.WriteLine("║     Sokoban     ║");
            Console.WriteLine("╚═════════════════╝");
            Console.WriteLine("════════════════════════════════════════════════════════");
            PrintMaze(maze);
            Console.WriteLine("════════════════════════════════════════════════════════");
            
            Console.WriteLine("> gebruik de pijltjestoetsen <s = stop, r = reset>");
        }

        public void PrintWinView(Maze maze)
        {
            System.Console.Clear();
            Console.WriteLine("╔═════════════════╗");
            Console.WriteLine("║     Sokoban     ║");
            Console.WriteLine("╚═════════════════╝");
            Console.WriteLine("════════════════════════════════════════════════════════");
            PrintMaze(maze);
            Console.WriteLine("═══════════════════ Gefeliciflapstaart ═════════════════");
            Console.WriteLine("> press any key to continue");
        }
    }
}
