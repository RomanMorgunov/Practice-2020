﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class VerticalLine : Figure
    {
        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            _pList = new List<Point>();
            for (int y = yUp; y <= yDown; y++)
            {
                _pList.Add(new Point(x, y, sym));
            }
        }
    }
}
