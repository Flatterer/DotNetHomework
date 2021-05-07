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
    public partial class Form1 : Form
    {
        OrderService orderService;
        BindingSource bds = new BindingSource();
        private string Keyword { get; set; }
        public Form1()
        {
            InitializeComponent();
            orderService = new OrderService();
            Order o1 = new Order(1, new Customer("1", "Q"), new List<OrderDetail>());
            o1.AddItem(new OrderDetail(1, new Goods("1", "egg", 1), 10));
            o1.AddItem(new OrderDetail(2, new Goods("2", "milk", 2), 20));
            orderService.AddOrder(o1);
            Order o2 = new Order(2, new Customer("2", "H"), new List<OrderDetail>());
            o2.AddItem(new OrderDetail(1, new Goods("2", "milk", 2), 20));
            orderService.AddOrder(o2);
            bdsOrder.DataSource = orderService.Orders;
            /*Order bdsOrderDetailOrder = bdsOrder.Current as Order;
            if (bdsOrderDetailOrder != null)
            {

            }*/
            cbxSelect.SelectedIndex = 0;
        }

        private void GetText()//== DataBindings                       Normal DataBingdings Error
        {
            Keyword = tbxEnter.Text;
        }

        private void SelectOrder()
        {
            Order order = bdsOrder.Current as Order;
            if (order == null)
            {
                MessageBox.Show("Plz Select an order");
                return;
            }
            bdsOrderDetail.DataSource = order.DetailList();
        }

        private void QueryAll()
        {
            bdsOrder.DataSource = orderService.Orders;
            bdsOrderDetail.ResetBindings(true);
            bdsOrder.ResetBindings(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectOrder();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            switch (cbxSelect.SelectedIndex)
            {
                case 0://all
                    bdsOrder.DataSource = orderService.Orders;

                    break;

                case 1://id
                    GetText();
                    int.TryParse(Keyword, out int resultid);
                    Order o = orderService.GetOrder(resultid);
                    List<Order> orderList = new List<Order>();
                    if (o != null)
                        orderList.Add(o);
                    bdsOrder.DataSource = orderList;

                    break;

                case 2://Customer
                    GetText();
                    bdsOrder.DataSource = orderService.QueryOrdersByCustomerName(Keyword);

                    break;

                case 3://Goods
                    GetText();
                    bdsOrder.DataSource = orderService.QueryOrdersByGoodsName(Keyword);

                    break;

                default:
                    bds.DataSource = orderService.Orders;

                    break;

            }
            bdsOrder.ResetBindings(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormEdit formEdit = new FormEdit(orderService);
            formEdit.ShowDialog();
            QueryAll();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Order order = bdsOrder.Current as Order;
            if (order == null)
            {
                MessageBox.Show("Plz Select an order");
                return;
            }
            orderService.RemoveOrder(order.OrderID);
            QueryAll();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            Order order = bdsOrder.Current as Order;
            if (order == null)
            {
                MessageBox.Show("Plz Select an order");
                return;
            }
            FormEdit formEdit = new FormEdit(order.OrderID, order.Customer, orderService);
            formEdit.ShowDialog();
            QueryAll();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = saveFileDialog1.FileName;
                orderService.Export(fileName);
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = openFileDialog1.FileName;
                orderService.Import(fileName);
                QueryAll();
            }
        }

        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {
            Order order = bdsOrder.Current as Order;
            OrderDetail orderDetail = bdsOrderDetail.Current as OrderDetail;
            if (order == null )
            {
                MessageBox.Show("Plz Select an order");
                return;
            }
            order.RemoveItem(orderDetail);
            QueryAll();
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            Order order = bdsOrder.Current as Order;
            
            if(order == null)
            {
                MessageBox.Show("Plz Select an order");
                return;
            }
            FormDetail formDetail = new FormDetail(order);
            formDetail.ShowDialog();
            QueryAll();
        }

        private void btnChangeDetail_Click(object sender, EventArgs e)
        {
            Order order = bdsOrder.Current as Order;
            OrderDetail orderDetail = bdsOrderDetail.Current as OrderDetail;
            if (orderDetail == null)
            {
                MessageBox.Show("Plz Select an order");
                return;
            }
            FormDetail formDetail = new FormDetail(order, orderDetail);
            formDetail.ShowDialog();
            QueryAll();
        }
    }
}
