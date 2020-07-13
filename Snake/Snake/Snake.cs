using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        Direction _direction;
        public int Score { get; private set; }

        public Snake(Point tail, int length, Direction direction)
        {
            _direction = direction;
            Score = 0;
            _pList = new List<Point>();

            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                _pList.Add(p);
            }
        }

        public void Move()
        {
            Point tail = _pList.First();
            _pList.Remove(tail);
            Point head = GetNextPoint();
            _pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = _pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, _direction);
            return nextPoint;
        }

        public void HandleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    _direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    _direction = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    _direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    _direction = Direction.Down;
                    break;
            }
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.Sym = head.Sym;
                _pList.Add(food);
                Score++;
                return true;
            }
            return false;
        }

        public bool IsHitTail()
        {
            var head = _pList.Last();
            for (int i = 0; i < _pList.Count - 2; i++)
            {
                if (head.IsHit(_pList[i]))
                    return true;
            }
            return false;
        }
    }
}
