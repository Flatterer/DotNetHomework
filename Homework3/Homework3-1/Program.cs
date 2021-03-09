using System;

namespace Homework3_1
{
    public interface Shape
    {
        double area();
        void determine();
    }

    public class Rectangle: Shape
    {
        double width, height;
        public Rectangle() 
        {
            width = 5;
            height = 3;
        }
        public Rectangle(double w, double h)
        {
            width = w;
            height = h;
        }
        public double area()
        {
            Console.WriteLine("Area = {0}", width * height);
            return width * height;
        }
        public void determine()
        {
            if (width > 0 && height > 0)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
        }
    }

    public class Square: Rectangle
    {
        public Square(double a): base(a, a)
        {
            
        }
        public Square() : this(5)
        {
            
        }
    }

    public class Triangle: Shape
    {
        double a, b, c;
        public Triangle(): this(1)
        {
            
        }
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public Triangle(double a)
        {
            this.a = a;
            b = a;
            c = a;
        }
        public double area()
        {
            double p = (a + b + c) / 2;
            double area = System.Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine("Area = {0}", area);
            return area;
        }
        public void determine()
        {
            if (a > 0 && b > 0 && c > 0 && a + b > c && a + c > b && b + c > a )
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rectangle:");
            Shape a = new Rectangle(2, 2);
            a.area();
            a.determine();
            a = new Rectangle(0, 2);
            a.determine();
            //------------
            Console.WriteLine("Square:");
            Shape b = new Square(2);
            b.area();
            b.determine();
            //------------
            Console.WriteLine("Triangle:");
            Shape c = new Triangle(1, 2, 3);
            c.determine();
            c = new Triangle(2, 2, 3);
            c.area();
            c.determine();
            c = new Triangle(1);
            c.area();
            c.determine();
        }
    }
}
