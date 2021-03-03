using System;

namespace Homework1_1
{
    class Program
    {
        public static double Trans()//turns string to double
        {
            Console.Write("Enter number:");
            string s = Console.ReadLine();
            return Convert.ToDouble(s);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an arithmatic expression '+' '-' '*' '/'");
            Console.WriteLine("Enter 2 Numbers");
            double a, b;
            a = Trans();
            b = Trans();
            loop:
            Console.WriteLine("Enter the Operation:");
            int c = Console.Read();
            if (c == '+')
            {
                Console.WriteLine("{0} {1} {2} = {3}", a, Convert.ToChar(c), b, a + b);
            }else if (c == '-')
            {
                Console.WriteLine("{0} {1} {2} = {3}", a, Convert.ToChar(c), b, a - b);
            }else if (c == '*')
            {
                Console.WriteLine("{0} {1} {2} = {3}", a, Convert.ToChar(c), b, a * b);
            }else if (c == '/')
            {
                Console.WriteLine("{0} {1} {2} = {3}", a, Convert.ToChar(c), b, a / b);
            }
            else
            {
                Console.WriteLine("Operation error input again!");
                int e=Console.Read();
                int f=Console.Read();
                int g=Console.Read();//get console left char
                goto loop;
            }
        }
    }
}
