using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5_1
{
    [Serializable]
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
        public Time time
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
        public Order(int id, Customer customer, Time time, string add, List<OrderDetails> od)
        {
            orderID = id;
            this.customer = customer;
            this.time = time;
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
           return base.GetHashCode() + 1;
        }
        public override string ToString()
        {
            return $"orderID = {orderID}, Customer = {customer.customerName}, Time = {time.ToString()}, address = {address}, total price = { price }";
        }
    }
}
