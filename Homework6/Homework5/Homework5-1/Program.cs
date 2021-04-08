using System;
using System.Collections.Generic;

namespace Homework5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer1 = new Customer("John");
            Customer customer2 = new Customer("Amy");

            Good good1 = new Good("Rice");
            Good good2 = new Good("Good");
            Good good3 = new Good("Shit");

            Time time1 = new Time(1, 1, 1);
            Time time2 = new Time(2, 2, 2);

            OrderDetails o1 = new OrderDetails(good1, 1, 10);
            OrderDetails o2 = new OrderDetails(good2, 2, 20);
            OrderDetails o3 = new OrderDetails(good3, 3, 1);

            List<OrderDetails> oList1 = new List<OrderDetails>();
            List<OrderDetails> oList2 = new List<OrderDetails>();
            oList1.Add(o1);
            oList2.Add(o2);
            List<OrderDetails> oList3 = new List<OrderDetails>();
            oList1.Add(o3);

            Order order1 = new Order(111, customer1, time1, "Wuhan", oList1);
            Order order2 = new Order(222, customer2, time2, "Hongshan", oList2);
            Order order3 = new Order(333, customer2, time2, "nine", oList3);

            OrderService service = new OrderService();

            service.Add(order1);
            service.Add(order1);
            service.Add(order2);
            service.Add(order3);

            service.Delete(order3);
            service.ModifyTime(order2, new Time(3, 3, 3));
            service.ModifyAddress(order1, "Hubei");

            service.Search(order3);
            service.Search(order1);

            service.OrderByPrice();
            service.ShowAll();


            Console.WriteLine("-----------------------------------");




            service.Method();

        }
    }
    
}
