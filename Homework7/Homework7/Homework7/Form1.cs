using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(graphics == null)
            {
                graphics = this.splitContainer1.Panel2.CreateGraphics();
            }
            graphics.Clear(this.BackColor);
            int n = Convert.ToInt32(numericUpDown1.Value);
            double th1 = Convert.ToDouble(numericUpDown5.Value) * Math.PI / 180;
            double th2 = Convert.ToDouble(numericUpDown6.Value) * Math.PI / 180;
            double per1 = Convert.ToDouble(numericUpDown3.Value);
            double per2 = Convert.ToDouble(numericUpDown4.Value);
            double len = Convert.ToDouble(numericUpDown2.Value);
            drawCayleyTree(n, 200, 310, len, -Math.PI / 2);
        }

        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if(n == 0)
            {
                return;
            }
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            int alpha = Convert.ToInt32(numericUpDown12.Value);
            byte r = Convert.ToByte(numericUpDown8.Value);
            byte g = Convert.ToByte(numericUpDown10.Value);
            byte b = Convert.ToByte(numericUpDown11.Value);
            graphics.DrawLine(new Pen(Color.FromArgb(alpha, r, g, b)), (int)x0, (int)y0, (int)x1, (int)y1);
        }
    }
}
