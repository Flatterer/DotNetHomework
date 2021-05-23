using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8
{
    public class Order : IComparable<Order>
    {
        private List<OrderDetail> orderDetails;
        public int OrderID { get; set; }
        public Customer Customer { get; set; }
        public string CustomerName { get => Customer != null ? Customer.Name : ""; }
        public DateTime Time { get; set; }
        public Order() { orderDetails = new List<OrderDetail>(); Time = DateTime.Now; }
        public Order(int id, Customer customer, List<OrderDetail> orderDetail)
        {
            OrderID = id;
            Customer = customer;
            orderDetails = orderDetail != null ? orderDetail : new List<OrderDetail>();
            Time = DateTime.Now;
        }
        public List<OrderDetail> OrderDetails
        {
            get { return orderDetails; }
        }
        public double TotalPrice
        {
            get => orderDetails.Sum(item => item.TotalPrice);
        }
        public object DetailList()
        {
            return orderDetails;
        }
        public void AddItem(OrderDetail o)
        {
            if (orderDetails.Contains(o))
                throw new ApplicationException("Order Exist");
            orderDetails.Add(o);
        }
        public void RemoveItem(OrderDetail o)
        {
            orderDetails.Remove(o);
        }
        public override bool Equals(object obj)
        {
            var order = obj as Order;
            return order != null && OrderID == order.OrderID;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public int CompareTo(Order order)
        {
            if (order == null) return 1;
            return this.OrderID.CompareTo(order.OrderID);
        }
    }
}
