using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject
{
    class Pool
    {
        static int count = 0;
        Location location;
        Temperature temp;

        public Pool()
        {
            StartCount();
            count++;
            location = new Location();
            temp = new Temperature();
            PrintCount();
        }
        public Pool(Location location, Temperature temp)
        {
            StartCount();
            count++;
            this.location = location;
            this.temp = temp;
            PrintCount();
        }
        public Pool(int x, int y)
        {
            StartCount();
            count++;
            location = new Location(x, y);
            temp = new Temperature();
            PrintCount();
        }
        public Pool(int x, int y, double degree, char scale)
        {
            StartCount();
            count++;
            location = new Location(x, y);
            temp = new Temperature(degree, scale);
            PrintCount();
        }
        public Location Location
        {
            get { return location; }
            set { location = value; }
        }
        public Temperature Temp
        {
            get { return temp; }
            set { temp = value; }
        }
        public int Count
        {
            get { return count; }
        }
        public void StartCount()
        {
            if (count == 0)
            {
                Console.WriteLine("Starting Pool Count: " + count);
            }
        }
        public void PrintCount()
        {
            Console.WriteLine("*Pool Instantiated*");
            Console.WriteLine("Pool Count: " + count);
        }
        public override string ToString()
        {
            return string.Format("This pool as a location of {0} and a temperature of {1}", location.ToString(), temp.ToString());
        }
    }
}
