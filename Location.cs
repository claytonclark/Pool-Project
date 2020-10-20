using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    class Location
    {
        int x;
        int y;

        public Location(){}
        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y);
        }
        ~Location() { }
    }
}
