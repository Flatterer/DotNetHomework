using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H8
{
    public partial class FormDetail : Form
    {
        Order order;
        public FormDetail()
        {
            InitializeComponent();
            order = new Order();
        }
        public FormDetail(Order order)
        {
            InitializeComponent();
            this.order = order;
        }
        public FormDetail(Order order, OrderDetail orderDetail)
        {
            InitializeComponent();
            this.order = order;
            textBoxIndex.Text = orderDetail.Index.ToString();
            textBoxGoodsID.Text = orderDetail.GoodsItem.ID;
            textBoxGoodsName.Text = orderDetail.GoodsName;
            textBoxPrice.Text = orderDetail.UnitPrice.ToString();
            textBoxQuantity.Text = orderDetail.Quantity.ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            OrderDetail orderDetail = new OrderDetail(uint.Parse(textBoxIndex.Text), new Goods(textBoxGoodsID.Text, textBoxGoodsName.Text, double.Parse(textBoxPrice.Text)), uint.Parse(textBoxQuantity.Text));
            order.AddItem(orderDetail);
            //TODO  Exception
            this.Close();
        }

        private void FormDetail_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
