using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeTraversal1
{
    class Location
    {
        int x;
        int y;

        public Location()
        {
            SetX(0);
            SetY(0);
        }
        public Location(int x, int y)
        {
            SetX(x);
            SetY(y);
        }

        public void SetX(int x)
        {
            this.x = x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }
        public String toString()
        {
            return "(" + GetX() + " , " + GetY() + ")";
        }
    }
}
