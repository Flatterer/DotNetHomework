using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework1_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("C:\\Users\\24356\\Desktop\\Software Constuction\\SC Homework1 2019302120118 qh\\Homework1\\pic\\background.jpg");
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            double numberA = Convert.ToDouble(textBox1.Text);
            double numberB = Convert.ToDouble(textBox2.Text);
            string s = comboBox1.Text;
            switch(s)
            {
                case "+":
                    textBox3.Text = (numberA + numberB).ToString();
                    break;
                case "-":
                    textBox3.Text = (numberA - numberB).ToString();
                    break;
                case "*":
                    textBox3.Text = (numberA * numberB).ToString();
                    break;
                case "/":
                    if (numberB == 0)
                        MessageBox.Show("The divider cant be 0.", "Error", MessageBoxButtons.OK);
                    else
                        textBox3.Text = (numberA / numberB).ToString();
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.Items.Add("+");
            this.comboBox1.Items.Add("-");
            this.comboBox1.Items.Add("*");
            this.comboBox1.Items.Add("/");
            this.comboBox1.SelectedIndex = 0;
            this.Text = "Calculater";
        }
    }
}
