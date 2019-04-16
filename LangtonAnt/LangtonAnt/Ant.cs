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

        public Colors Move(Colors color)
        {
            int i = 0;
            Colors retColor = Colors.Black;
            if(color == Colors.Black)
            {
                i = 1;
                Angle -= 90;
                retColor = Colors.White;
            } 
            else {
                i = -1;
                Angle += 90;
                retColor = Colors.Black;
            }

            Coordinate = Point.Construct(Coordinate.X, Coordinate.Y + i);
            
            return retColor;
        }
    }
}