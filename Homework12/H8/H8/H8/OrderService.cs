using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace H8
{
    public class OrderService
    {
        private List<Order> orders;
        public OrderService()
        {
            orders = new List<Order>();
        }
        public List<Order> Orders
        {
            get
            {
                return orders;
            }
        }
        public Order GetOrder(int id)
        {
            return orders.Where(o => o.OrderID == id).FirstOrDefault();
        }
        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
                throw new ApplicationException("Order Exsit");
            orders.Add(order);
        }
        public void RemoveOrder(int id)
        {
            Order order = GetOrder(id);
            if(order != null)
            {
                orders.Remove(order);
            }
        }
        public List<Order> QueryOrdersByGoodsName(string goodsname)
        {
            var query = orders.Where(order => order.OrderDetails.Exists(item => item.GoodsName == goodsname)).OrderBy(o => o.TotalPrice);
            return query.ToList();
        }
        public List<Order> QueryOrdersByCustomerName(string customerName)
        {
            var query = orders.Where(order => order.CustomerName == customerName).OrderBy(o => o.TotalPrice);
            return query.ToList();
        }
        public object QueryByTotalAmount(float amout)
        {
            return orders
               .Where(order => order.TotalPrice >= amout)
               .OrderByDescending(o => o.TotalPrice)
               .ToList();
        }
        void UpdateOrder(Order o)
        {
            Order oldOrder = GetOrder(o.OrderID);
            if(oldOrder == null)
            {
                throw new ApplicationException("Order Exist");
            }
            orders.Remove(oldOrder);
            orders.Add(o);
        }
        public void Sort()
        {
            orders.Sort();
        }
        void Sort(Func<Order, Order, int> func)
        {
            Orders.Sort((o1, o2) => func(o1, o2));
        }
        public void Export(String fileName)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                xs.Serialize(fs, Orders);
            }
        }

        public void Import(string path)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order> temp = (List<Order>)xs.Deserialize(fs);
                temp.ForEach(order => {
                    if (!orders.Contains(order))
                    {
                        orders.Add(order);
                    }
                });
            }
        }
    }
}
