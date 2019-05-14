// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System;

namespace LangtonAnt
{
    public class Map
    {
        public Ant Ant { get; private set; }
        private Colors[,] _matrix;

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            _matrix = new Colors[Width, Height];
            Ant = new Ant();
            Ant.Coordinate = Point.Construct(Width / 2, Height / 2);

            var random = new Random();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    _matrix[i, j] = random.Next(2) == 0 ? Colors.Black : Colors.White;
                    
                }
            }

        }

        public int Height { get; set; }

        public int Width { get; set; }

        public Colors GetColor(Ant ant)
        {
            return _matrix[ant.Coordinate.X, ant.Coordinate.Y];
        }

        public Colors GetColor(int x, int y)
        {
            return _matrix[x, y];
        }

        public void SetColor(int x, int y, Colors newColor)
        {
            _matrix[x, y] = newColor;
        }

        public Colors GetCurrentColor(Point point)
        {
            return _matrix[point.X, point.Y];
        }

        
        public void Tick()
        {
            var oldCoordinate = Ant.Coordinate;

            Colors color = Ant.Move(this);
            _matrix[oldCoordinate.X, oldCoordinate.Y] = color;

        }
        public void SetColor(Point coordinate, Colors color)
        {
            SetColor(coordinate.X, coordinate.Y, color);
        }
    }
}