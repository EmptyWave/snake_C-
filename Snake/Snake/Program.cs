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
        static void Main(string[] args)
        {
            const Int32 MaxConsoleX = 120;//80
            const Int32 MaxConsoleY = 30;//25

            int Score = 0;

            Console.SetBufferSize(MaxConsoleX, MaxConsoleY);//(80,25)

            Walls walls = new Walls(MaxConsoleX, MaxConsoleY);
            walls.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            snake.Move();

            Console.ForegroundColor = ConsoleColor.Yellow;

            FoodCreator foodCreator = new FoodCreator(120, 30, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                if(walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if(snake.Eat(food))
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
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            snake.Clear();
            food.Clear();
            Console.SetCursorPosition(MaxConsoleX / 2 - 5, MaxConsoleY / 2);
            Console.WriteLine("Game Over!");
            Console.SetCursorPosition(MaxConsoleX / 2 - 6, MaxConsoleY / 2 + 1);
            Console.WriteLine("Score: " + Score);
            Console.ReadLine();
        }

        /*public static void GameOver()
        {
            snake.Clear();
            food.Clear();
            Console.SetCursorPosition(MaxConsoleX / 2 - 5, MaxConsoleY / 2);
            Console.WriteLine("Game Over!");
            Console.SetCursorPosition(MaxConsoleX / 2 - 6, MaxConsoleY / 2 + 1);
            Console.WriteLine("Score: " + Score);
            Console.ReadLine();
        }*/
    }
}
