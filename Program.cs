using System;

namespace FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPools = 7;
            int poolsVisited = 0;
            char[] poolNames = new char[] { 'A','B','C','D','E','F','G'};
            Pool[] pools = new Pool[numPools];
            Location currentPos = new Location(0, 0);
            Random randNum = new Random();

            InitcalizeArray(pools, numPools);
            Console.WriteLine("\nStarting Position: " + currentPos);

            while (poolsVisited != numPools)
            {
                double[] distancesFromCurrent = new double[numPools];

                Console.WriteLine("\n\nThe maintenance crew is moving to the next nearest pool.");
                for (int i = poolsVisited; i < numPools; i++)
                {
                    distancesFromCurrent[i] = FindDistance(currentPos, pools[i]);
                }
                char[] temp = new char[7];
                for(int i = 0; i < 7; i++)
                {
                    temp[i] = poolNames[i];
                }
                Array.Sort(distancesFromCurrent, poolNames);
                Console.WriteLine();
                char key = poolNames[poolsVisited];
                int index = BinarySearch(temp,key);
                if(index == -1)
                {
                    Console.WriteLine("A problem has occured. Exiting Program");
                    break;
                }
                currentPos = pools[index].Location;
                pools[index].Temp.Degree = randNum.Next(98, 105);
                pools[index].Temp.Scale = 'F';
                Console.WriteLine("Current Position: "+currentPos);
                Console.WriteLine("This pool's temperature is set to " + pools[index].Temp);
                poolNames = temp;
                SetArrays(pools, poolNames, index, poolsVisited);
                poolsVisited++;
            }
            Console.WriteLine("\nThe maintenance crew has finished all the pools\n");
            int index2 = 0;
            Console.WriteLine("Route Taken: \n(0, 0)" +
                RepeatingString(pools, poolNames, ref index2) + RepeatingString(pools, poolNames, ref index2) +
                RepeatingString(pools, poolNames, ref index2) + RepeatingString(pools, poolNames, ref index2) +
                RepeatingString(pools, poolNames, ref index2) + RepeatingString(pools, poolNames, ref index2)+
                RepeatingString(pools, poolNames, ref index2));
        }
        static string RepeatingString(Pool[] pools, char[] poolNames, ref int index)
        {
            string str = "\n>> " + poolNames[index] + " with temperature at " + pools[index].Temp;
            index++;
            return str;
        }
        static int BinarySearch(char[] array, char key)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if(key == array[i])
                {
                    return i;
                }
            }
            return -1;
        }
        static void SetArrays(Pool[] pools, char[] poolNames, int index, int poolsVisited)
        {
            char tempChar;
            Location tempLoc = new Location();
            Temperature tempTemp = new Temperature();
            tempLoc = pools[index].Location;
            tempTemp = pools[index].Temp;
            pools[index].Location = pools[poolsVisited].Location;
            pools[index].Temp = pools[poolsVisited].Temp;
            pools[poolsVisited].Location = tempLoc;
            pools[poolsVisited].Temp = tempTemp;
            tempChar = poolNames[index];
            poolNames[index] = poolNames[poolsVisited];
            poolNames[poolsVisited] = tempChar;
            for (int i = 0; i < 7; i++)
            {
                Console.Write(poolNames[i] + ", ");
            }
            Console.WriteLine();
            for (int i = 0; i < 7; i++)
            {
                Console.Write(pools[i].Location + ", ");
            }
        }
        static void InitcalizeArray(Pool[] pools, int numPools)
        {
            pools[0] = new Pool(4, 8);
            pools[1] = new Pool(1, 3);
            pools[2] = new Pool(4, 2);
            pools[3] = new Pool(13, 1);
            pools[4] = new Pool(12, 9);
            pools[5] = new Pool(10, 5);
            pools[6] = new Pool(6, 6);
        }
        static double FindDistance(Location currentLocation, Pool pool)
        {
            double xDistance = Math.Abs(currentLocation.X - pool.Location.X);
            double yDistance = Math.Abs(currentLocation.Y - pool.Location.Y);
            double c = Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
            return c;
        }
    }
}
