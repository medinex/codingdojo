using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PacManKata
{
    public class Game
    {
        Level _level = new Level();
        Board _board;
        ConsoleKeyInfo _key;

        public Game()
        {
            Init();

            var run = true;
            while(run)
            {
                //run = ReadInput();

                CollisionDetection();

                MoveGameObjects();

                Statistic();

                UpdateBoard();

                

                Thread.Sleep(500);
            }


        }

        private void Init()
        {
            _board = new Board(_level);

            var middleX = _board.Level.GetMiddleX();
            var middleY = _board.Level.GetMiddleY();

            _board.Level.SetContent(new Actor('p')
            {
                CanMove = true,
                Direction = 'w'
            },
            middleX,
            middleY);
        }

        private bool ReadInput()
        {
            var run = true;

            if (Console.KeyAvailable)
            {
                _key = Console.ReadKey(true);
                switch (_key.Key)
                {
                    case ConsoleKey.Q:
                        run = false;
                        break;
                    default:
                        break;
                }
            }

            return run;
        }

        private void UpdateBoard()
        {
            Show();
        }

        private void Statistic()
        {
        }

        private void MoveGameObjects()
        {

        }

        private void CollisionDetection()
        {
        }

        public string Show()
        {
            Console.Clear();
            return _board.Level.Show();
        }
    }
}
