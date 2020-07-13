using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Sym { get; set; }

        public Point() { }

        public Point(int x, int y, char sym)
        {
            X = x;
            Y = y;
            Sym = sym;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
            Sym = point.Sym;
        }

        public void Move(int offset, Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    X -= offset;
                    break;
                case Direction.Right:
                    X += offset;
                    break;
                case Direction.Up:
                    Y -= offset;
                    break;
                case Direction.Down:
                    Y += offset;
                    break;

            }
        }

        public void Clear()
        {
            Sym = ' ';
            Draw();
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Sym);
        }

        public bool IsHit(Point point)
        {
            return X == point.X && Y == point.Y;
        }

        public override string ToString()
        {
            return $"{X}, {Y}, {Sym}";
        }
    }
}
