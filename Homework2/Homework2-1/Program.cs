using System;

namespace Homework2_1
{
    class Program
    {
        public static bool def(int n)//if it's prime number output true else false
        {
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                     return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            try
            {//For correct     "12S" error.
                string s = Console.ReadLine();
                int.TryParse(s, out int num);
                int i = 2;
                while (num != 1)
                {
                    while (num % i == 0)
                    {
                        num /= i;
                    }
                    Console.WriteLine(i);
                    i++;
                    while (!def(i)) { i++; }
                }
            }catch(Exception e)
            {
                Console.WriteLine("Error:" + e.Message);
            }
            
        }
    }
}
