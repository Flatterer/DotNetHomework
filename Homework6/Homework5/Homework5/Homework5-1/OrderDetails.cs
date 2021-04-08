using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5_1
{
    [Serializable]
    public class OrderDetails: IEquatable<OrderDetails>
    {
        public Good good
        {
            get;set;
        }
        public double unitPrice
        {
            get;set;
        }
        public int count
        {
            get;set;
        }
        public OrderDetails(Good g, double up, int c)
        {
            this.good = g;
            this.unitPrice = up;
            this.count = c;
        }
        public override bool Equals(object obj)
        {
            OrderDetails od = obj as OrderDetails;
            return od != null && od.good == this.good && od.count == this.count && od.unitPrice == this.unitPrice;
        }
        public bool Equals(OrderDetails od)
        {
            return od != null && od.good == this.good && od.count == this.count && od.unitPrice == this.unitPrice;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode() + 2;
        }
        public override string ToString()
        {
            return $"Good's name = {good.goodsName} unitPrice = {unitPrice} count = {count}";
        }

    }
}
