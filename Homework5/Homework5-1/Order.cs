using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5_1
{
    class Order: IEquatable<Order>
    {
        public int orderID
        {
            get; set;
        }
        public Customer customer
        {
            get; set;
        }
        public DateTime time
        {
            get; set;
        }
        public double price
        {
            get; set;
        }
        public string address
        {
            get; set;
        }
        public List<OrderDetails> orderDetails;
        public Order(int id, Customer customer, string add, List<OrderDetails> od)
        {
            orderID = id;
            this.customer = customer;
            this.time = DateTime.Now;
            address = add;
            this.orderDetails = od;
            price = 0;
            foreach(OrderDetails o in od)
            {
                price += o.unitPrice * o.count;
            }
        }
        public override bool Equals(object obj)
        {
            Order o = obj as Order;
            return o != null && o.orderID == this.orderID;
        }
        public bool Equals(Order o)
        {
            return o != null && o.orderID == this.orderID;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() + 3;
        }
        public override string ToString()
        {
            return $"orderID = {orderID}, Customer = {customer}, Time = {time.ToString()}, address = {address}, total price = { price }";
        }
    }
}
