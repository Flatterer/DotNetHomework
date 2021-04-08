using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5_1
{
    [Serializable]
    class Good: IEquatable<Good>
    {
        public string goodsName
        {
            get;set;
        }
        public Good(string gn)
        {
            this.goodsName = gn;
        }
        public override bool Equals(object obj)
        {
            Good good = obj as Good;
            return good != null && good.goodsName == this.goodsName;
        }
        public bool Equals(Good g)
        {
            return g.goodsName == this.goodsName;
        }
        public override int GetHashCode()
        {
            //return EqualityComparer<String>.Default.GetHashCode(goodsName) + 1;
            return base.GetHashCode() + 1;
        }
        public override string ToString()
        {
            return $"Good's name = {goodsName}";
        }
    }
}
