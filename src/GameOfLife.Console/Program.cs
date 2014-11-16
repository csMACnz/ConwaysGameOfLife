using System.Linq;
using System.Threading;
using GameOfLife.Core;

namespace GameOfLife.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputState = new[,]
            {
                {State.Dead,  State.Dead,  State.Dead,  State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Alive, State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Alive, State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Alive, State.Dead,  State.Dead},
                {State.Dead,  State.Dead,  State.Dead,  State.Dead,  State.Dead},
            };
            var world = new WrappingSquareWorld(5, 5);
            var initialState = world.CreateState(inputState);
            var game = new Game(world, initialState);
            while (true)
            {
                game.Tick();
                System.Console.Clear();
                foreach (var row in Enumerable.Range(0, 5))
                {
                    foreach (var column in Enumerable.Range(0, 5))
                    {
                        Cell cell = world.GetCell(row,column);
                        var state = game.GetState(cell);
                        System.Console.Write("{0} ", state==State.Alive? "[#]": "[ ]");
                    }
                    System.Console.WriteLine("");
                    
                }
                Thread.Sleep(500);

            }
        }
    }
}
