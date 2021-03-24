using System;

namespace Homework4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock c = new Clock();
            ClockHandler clockHandler = new ClockHandler(c);
            c.Start();
        }
    }
}
