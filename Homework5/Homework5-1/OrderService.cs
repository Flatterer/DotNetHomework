using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Homework5_1
{
    class OrderService
    {
        private List<Order> orders = new List<Order>();
        private bool Empty()
        {
            return orders.Count == 0;
        }
        private bool Exist(Order o)
        {
            return orders.IndexOf(o) != -1;
        }
        public void Add(Order o)
        {
            if (Empty())
                orders.Add(o);
            else
            {
                foreach(var order in orders)
                {
                    try
                    {
                        if (order.orderID == o.orderID)
                            throw new MyException("Order REPETITION");
                    }catch( MyException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                orders.Add(o);
                orders.Sort((x, y) => x.orderID.CompareTo(y.orderID));
                Console.WriteLine(o.ToString() + "Added");
            }
        }
        public void Delete(Order o)
        {
            try
            {
                if (!Exist(o))
                    throw new MyException("Order not exist");
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }
                orders.Remove(o);
                orders.Sort((x, y) => x.orderID.CompareTo(y.orderID));
                Console.WriteLine(o.ToString() + "Deleted");
        }
        public void ModifyTime(Order o, Time t)
        {
            try
            {
                if (!Exist(o))
                    throw new MyException("Order not exist");
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }
                o.time = t;
                Console.WriteLine(o.ToString() + " Time changed");
        }
        public void ModifyAddress(Order o, string s)
        {
            try
            {
                if (!Exist(o))
                    throw new MyException("Order not exist");
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }
                o.address = s;
                Console.WriteLine(o.ToString() + " Address changed");
        }
        public void Search(Order o)
        {
            if (Exist(o))
                Console.WriteLine(o.ToString() + " Exist");
            else
                Console.WriteLine(o.ToString() + " Not Exist");
        }
        public List<Order> OrderByPrice()
        {
            return orders.OrderBy(i => i.price).ToList();
        }
        public void ShowAll()
        {
            Console.WriteLine("Show OrderList");
            foreach(var o in orders)
            {
                Console.WriteLine(o.ToString());
            }
        }
    }
}
