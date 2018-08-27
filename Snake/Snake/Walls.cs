using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            HorizontalLine UpLine = new HorizontalLine(0, mapWidth-1, 1, '+');
            HorizontalLine DowntLine = new HorizontalLine(0, mapWidth-1, mapHeight-1, '+');
            VerticalLine LeftLine = new VerticalLine(0, 0, mapHeight - 2, '+');
            VerticalLine RightLine = new VerticalLine(mapWidth - 1, 0, mapHeight - 2, '+');

            wallList.Add(UpLine);
            wallList.Add(DowntLine);
            wallList.Add(LeftLine);
            wallList.Add(RightLine);
        }

        internal bool IsHit(Figure figure)
        {
            foreach(var wall in wallList)
            {
                if(wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
