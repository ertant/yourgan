using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Yourgan.Core.Page;
using Yourgan.Core.DOM;

namespace TestApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            browserView1.LoadHtml("<html><body><div>test<span>test2</span></div><div>line2</div></body></html>");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            browserView1.Load("http://www.google.com");
        }
    }
}
