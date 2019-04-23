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
                    _matrix[i, j] = random.Next(1) == 0 ? Colors.Black : Colors.White;
                    
                }
            }

        }

        public int Height { get; set; }

        public int Width { get; set; }

        public Colors GetColor(int x, int y)
        {
            return Colors.Black;
        }

        public object GetCurrentColor(Ant ant)
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {

                }
            }
        }

        public void Tick()
        {
            Ant.Move(GetColor(Ant.Coordinate.X, Ant.Coordinate.Y));

        }
    }
}