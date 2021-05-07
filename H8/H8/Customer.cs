using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8
{
    public class Customer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Customer() { }
        public Customer(string id, string name)
        {
            ID = id;
            Name = name;
        }
        public override bool Equals(object obj)
        {
            var cus = obj as Customer;
            return cus != null && ID == cus.ID && Name == cus.Name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
