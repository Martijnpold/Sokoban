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
            Console.Write("╔══════════════════════════════════════════════════════╗");
            Console.Write("║    Welkom Bij Sokoban!                               ║");
            Console.Write("║                                                      ║");
            Console.Write("║    betekenis van de symbolen   ║  doel van het spel  ║");
            Console.Write("║                                ║                     ║");
            Console.Write("║    spatie : outerspace         ║                     ║");
            Console.Write("║         █ : muur               ║  duw met de truck   ║");
            Console.Write("║         · : vloer              ║  de krat(ten)       ║");
            Console.Write("║         O : krat               ║  naar de bestemming ║");
            Console.Write("║         Ø : krat op bestemming ║                     ║");
            Console.Write("║         x : bestemming         ║                     ║");
            Console.Write("║         @ : speler             ║                     ║");
            Console.Write("╚══════════════════════════════════════════════════════╝");
            Console.Write("");
            Console.Write("> Kies een doolhof (1 - 4) s = stop");
        }

        public void PrintLevelView()
        {
            Console.Write("╔═════════════════╗");
            Console.Write("║     Sokoban     ║");
            Console.Write("╚═════════════════╝");
            Console.Write("════════════════════════════════════════════════════════");
            PrintMaze();
            Console.Write("════════════════════════════════════════════════════════");
            
            Console.Write("> gebruik de pijltjestoetsen <s = stop, r = reset>");
        }

        public void PrintWinView()
        {
            Console.Write("═══════════════👌👌 Gefeliciflapstaart 👌👌══════════════");
            Console.Write("> press any key to continue");
        }
    }
}
