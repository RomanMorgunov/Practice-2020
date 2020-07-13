using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Figure
    {
        protected List<Point> _pList;

        public void Draw()
        {
            foreach (var p in _pList)
            {
                p.Draw();
            }
        }

        public bool IsHit(Figure figure)
        {
            foreach (var p in _pList)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }

        private bool IsHit(Point point)
        {
            foreach (var p in _pList)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
}
