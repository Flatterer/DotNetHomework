using System;

namespace Homework2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[102];
            for(int i = 0; i < 102; i++)//initialize array
            {
                array[i] = 1;
            }
            for(int i = 2; i < 101; i++)//delete number
            {
                if (array[i] == 0)
                    continue;
                int j = i*2;
                while (j < 101)
                { 
                    array[j] = 0;
                    j += i;
                }
            }
            for (int i = 2; i < 101; i++)//output number
            {
                if (array[i] == 1)
                    Console.Write(i + "\t");
            }
        }
    }
}
