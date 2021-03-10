using System;
using Homework3_1;

namespace Homework3_2
{
    /*enum ShapeType
    {
        Rectangle = 0,
        Square = 1,
        Triangle = 2
    }*/
    class ShapeFactory
    {
        public Shape GetShape(int shapeType)
        {
            if (shapeType == 0)
            {
                Console.WriteLine("Rectangle: 5*3");
                return new Rectangle();
            }
            else if (shapeType == 1)
            {
                Console.WriteLine("Square: 5*5");
                return new Square();
            }
            else if (shapeType == 2)
            {
                Console.WriteLine("Triangle: 1 1 1");
                return new Triangle();
            }
            else
            {
                throw new Exception("Error");
            }

        }
    }
    class Program
    {
        public static int GetRandomNumber()
        {
            Random r = new Random();
            int i = r.Next(0, 3);
            return i;
        }
        static void Main(string[] args)
        {
            double area = 0;
            ShapeFactory sf = new ShapeFactory();
            for(int i = 0; i < 10; i++)
            {
                Shape s = sf.GetShape(GetRandomNumber());
                area += s.area();
            }
            Console.WriteLine("Total Area = {0}", area);
        }
    }
}
