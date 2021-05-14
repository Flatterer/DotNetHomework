using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework9
{
    public partial class Form1 : Form
    {
        SimpleCrawler myCrawler = new SimpleCrawler();
        //ListView itemGood = new ListView();
        //ListView itemBad = new ListView();
        Thread thread;
        public Form1()
        {
            InitializeComponent();
        }
        /*private void listener()
        {
            Thread thread = Thread.CurrentThread;
            while (thread.IsAlive) ;
        }*/

        private void btnStart_Click(object sender, EventArgs e)
        {
            myCrawler.goodUrl.Clear();
            myCrawler.badUrl.Clear();
            myCrawler.urls.Clear();
            string startUrl = textBoxUrl.Text.ToString();
            try
            {
                if(!myCrawler.urls.Contains(startUrl))
                    myCrawler.urls.Add(startUrl, false);//加入初始页面
            }catch(ArgumentException exception)
            {
                throw new ArgumentException(exception.ToString());
            }
            thread = new Thread(myCrawler.Crawl);
            //SimpleCrawler simpleCrawler = new SimpleCrawler(myCrawler);
            lblStatus.Text = "Start Crawl";
            //thread.Start();
            //thread = new Thread(simpleCrawler.Crawl);
            thread.Start();

            // listener();
            thread.Join();
            
            foreach(var item in myCrawler.goodUrl)
            {
                listViewGood.Items.Add(item);
            }

            foreach(var item in myCrawler.badUrl)
            {
                listViewBad.Items.Add(item);
            }
            lblStatus.Text = "Crawl Ended";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Abort Crawl";
            thread.Abort();
            
        }

    }
}
