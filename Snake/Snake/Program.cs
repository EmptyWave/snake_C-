using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        const Int32 MaxConsoleX = 80;
        const Int32 MaxConsoleY = 30;

        static void Main(string[] args)
        {
            Console.SetWindowSize(MaxConsoleX, MaxConsoleY);
            Console.SetBufferSize(MaxConsoleX, MaxConsoleY);
            Console.CursorVisible = false;
            Console.SetCursorPosition(MaxConsoleX / 2 - 10, MaxConsoleY / 2 - 1);
            Console.WriteLine("Press Enter to start");
            Console.ReadLine();

        Start:

            int Score = 0;

            Console.Clear();
            Walls walls = new Walls(MaxConsoleX, MaxConsoleY, '#');
            walls.Draw();

            Point p = new Point(MaxConsoleX / 2, MaxConsoleY / 2, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            snake.Move();

            Console.ForegroundColor = ConsoleColor.Yellow;

            FoodCreator foodCreator = new FoodCreator(MaxConsoleX-2, MaxConsoleY-1, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                if(walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    Score++;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    food = foodCreator.CreateFood();
                    food.Draw();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }

            }

            Console.Clear();
            Console.SetCursorPosition(MaxConsoleX / 2 - 5, MaxConsoleY / 2 - 5);
            Console.WriteLine("Game Over!");
            Console.SetCursorPosition(MaxConsoleX / 2 - 4, MaxConsoleY / 2 -3);
            Console.WriteLine("Score: " + Score);
            Console.SetCursorPosition(MaxConsoleX / 2 - 10, MaxConsoleY / 2 + 3);
            Console.WriteLine("Press Y to try again");
            ConsoleKeyInfo repkey = Console.ReadKey();
            if (repkey.Key == ConsoleKey.Y)
                goto Start;
        }
    }
}
