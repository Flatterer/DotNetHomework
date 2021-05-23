using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8
{
    public class Goods
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Goods() { }
        public Goods(string id, string name, double price)
        {
            ID = id;
            Name = name;
            Price = price;
        }
        public override bool Equals(object obj)
        {
            var goods = obj as Goods;
            return goods != null && ID == goods.ID && Name == goods.Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
