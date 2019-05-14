// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;

namespace LangtonAnt
{
    public class Ant
    {
        public Ant()
        {
        }

        public int Angle { get; set; }
        public Colors CurrentColor { get; set; }
        public Point Coordinate { get; set; }

        public Colors Move(Map map)
        {
            int dy = 0;
            int dx = 0;
            Colors retColor = Colors.Black;
            var color = map.GetCurrentColor(Coordinate);

            if(color == Colors.Black)
            {
                Angle -= 90;
                retColor = Colors.White;
            } 
            else {
                Angle += 90;
                retColor = Colors.Black;
            }

            if(Angle < 0)
            {
                Angle += 360;
            }

            switch (Angle%360)
            {
                case 0:
                    dy = -1;
                    dx = 0;
                    break;
                case 90:
                    dy = 0;
                    dx = 1;
                    break;
                case 180:
                    dy = 1;
                    dx = 0;
                    break;
                case 270:
                    dy = 0;
                    dx = -1;
                    break;
            }
            var newX = Coordinate.X + dx;
            var newY = Coordinate.Y + dy;

            if(newX < 0)
            {
                newX = map.Width - 1;
            }//if

            if (newY < 0)
            {
                newY = map.Height - 1;
            }//if

            if (newX >= map.Width)
                newX = 0;
            if (newY >= map.Height)
                newY = 0;

            Coordinate = Point.Construct(newX, newY);
            
            return retColor;
        }
    }
}