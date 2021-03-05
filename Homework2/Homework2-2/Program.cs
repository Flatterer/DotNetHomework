using System;

namespace Homework2_2
{
    class Program
    {
        public static bool getIntNumber(ref int n)
        {
            try
            {
                string s = Console.ReadLine();
                int.TryParse(s, out int number);
                n = number;
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:" + e.Message + "Enter number again");
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of the int array!");
            int numOfArray = 0;
            while (!getIntNumber(ref numOfArray)) ;//Get the number of array until its the right number
            Console.WriteLine("Enter the Int Array!");
            int[] array = new int[numOfArray];
            for(int i = 0; i < numOfArray; i++)
            {
                while (!getIntNumber(ref array[i])) ;//Get the array right
            }
            //calculate
            int max = array[0], min = array[0], ave, sum = 0;
            foreach(int num in array)
            {
                if (num > max)
                    max = num;
                if (num < min)
                    min = num;
                sum += num;
            }
            ave = sum / numOfArray;
            Console.WriteLine("Max = {0}, Min = {1}, ave = {2}, sum = {3}", max, min, ave, sum);
        }
    }
}
