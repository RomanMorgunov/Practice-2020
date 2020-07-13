using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        List<Figure> _wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            _wallList = new List<Figure>();

            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '+');

            _wallList.Add(upLine);
            _wallList.Add(downLine);
            _wallList.Add(leftLine);
            _wallList.Add(rightLine);
        }

        public bool IsHit(Figure figure)
        {
            foreach (var item in _wallList)
            {
                if (item.IsHit(figure))
                    return true;
            }
            return false;
        }

        public void Draw()
        {
            foreach (var item in _wallList)
            {
                item.Draw();
            }
        }
    }
}
