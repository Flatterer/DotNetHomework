using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homework5_1;

namespace Homework8
{
    public partial class Form1 : Form
    {
        OrderService orderService;
        BindingSource bds = new BindingSource();

        public Form1()
        {
            Good EGG = new Good()
            InitializeComponent();
            orderService = new OrderService();
            Order order = new Order(1, new Customer("Xiao Ming"), "Wuhan", new List<OrderDetails>());
            order.orderDetails.Add(new OrderDetails())
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            new FormAdd().ShowDialog();
        }
    }
}
