using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H8
{
    public class OrderDetail
    {
        public uint Index { get; set; }
        public Goods GoodsItem { get; set; }
        public uint Quantity { get; set; }
        public double UnitPrice { get => GoodsItem != null ? GoodsItem.Price : 0; }
        public string GoodsName { get => GoodsItem != null ? GoodsItem.Name : ""; }

        public OrderDetail() { }
        public OrderDetail(uint index, Goods goods, uint quantity)
        {
            Index = index;
            GoodsItem = goods;
            Quantity = quantity;
        }

        public double TotalPrice { get => GoodsItem != null ? GoodsItem.Price * Quantity : 0; }

        public override bool Equals(object obj)
        {
            var item = obj as OrderDetail;
            return item != null && GoodsName == item.GoodsName;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
