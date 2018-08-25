using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(80, 25);

            //Отрисовка рамочки
            FrameDraw();

            //drowing points
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            Console.ReadLine();

        }
        
        public static void FrameDraw()
        {
            HorizontalLine HLeftLine = new HorizontalLine(0, 78, 0, '+');
            HorizontalLine HRightLine = new HorizontalLine(0, 78, 24, '+');
            VerticalLine VUpLine = new VerticalLine(0, 0, 24, '+');
            VerticalLine VDownLine = new VerticalLine(78, 0, 24, '+');

            HLeftLine.Draw();
            HRightLine.Draw();
            VUpLine.Draw();
            VDownLine.Draw();
        }
    }
}
