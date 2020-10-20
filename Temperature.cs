using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    class Temperature
    {
        double degree;
        char scale;

        public Temperature() { }
        public Temperature(double degree, char scale)
        {
            this.degree = degree;
            this.scale = scale;
        }
        public double Degree
        {
            get { return degree; }
            set { degree = value; }
        }
        public char Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        public override string ToString()
        {
            return string.Format("{0} degrees {1}", degree, scale);
        }
        ~Temperature() { }
    }
}
