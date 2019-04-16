// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
namespace LangtonAnt
{
    public struct Point
    {
        public static Point Construct(int x, int y)
        {
            return new Point {
                X = x,
                Y = y
            };
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is Point point)
            {
                return point.X == X && point.Y == Y;  
            }
            return false;
        }
    }
}