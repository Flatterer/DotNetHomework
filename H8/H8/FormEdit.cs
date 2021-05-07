using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using H8;


namespace H8
{
    public partial class FormEdit : Form
    {
        private OrderService orderService;
        public FormEdit()
        {
            InitializeComponent();
            orderService = new OrderService();
        }
        public FormEdit(OrderService orderService)
        {
            InitializeComponent();
           
            this.orderService = orderService;
        }
        public FormEdit(int id, Customer customer, OrderService orderService)
        {
            InitializeComponent();
            textBoxCustomerName.Text = customer.Name;
            textBoxCustomer.Text = customer.ID;
            textBoxID.Text = id.ToString();
            this.orderService = orderService;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Order order;
            int.TryParse(textBoxID.Text,out int id);
            string customerID = textBoxCustomer.Text;
            string customerName = textBoxCustomerName.Text;
            Customer customer = new Customer(customerID, customerName);
            order = new Order(id, customer, new List<OrderDetail>());
            orderService.AddOrder(order);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
