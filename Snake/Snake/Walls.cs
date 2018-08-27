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

        public Walls(int mapWidth, int mapHeight, char sym)
        {
            wallList = new List<Figure>();

            HorizontalLine UpLine = new HorizontalLine(0, mapWidth-1, 1, sym);
            HorizontalLine DowntLine = new HorizontalLine(0, mapWidth-1, mapHeight-1, sym);
            VerticalLine LeftLine = new VerticalLine(0, 0, mapHeight - 2, sym);
            VerticalLine RightLine = new VerticalLine(mapWidth - 1, 0, mapHeight - 2, sym);

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

        public void Clear()
        {
            foreach(var wall in wallList)
            {
                wall.Clear();
            }
        }
    }
}
