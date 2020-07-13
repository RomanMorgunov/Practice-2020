using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class FoodCreator
    {
        int _mapWidth;
        int _mapHeight;
        char _sym;
        Random _random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            _mapHeight = mapHeight;
            _mapWidth = mapWidth;
            _sym = sym;
        }

        public Point CreateFood()
        {
            int x = _random.Next(2, _mapWidth - 2);
            int y = _random.Next(2, _mapHeight - 2);
            return new Point(x, y, _sym);
        }
    }
}
