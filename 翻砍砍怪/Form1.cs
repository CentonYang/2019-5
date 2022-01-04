using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 翻砍砍怪
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Label1_Click(object sender, EventArgs e)
        {
            UserControl c1 = new c1();
            Controls.Clear();
            Controls.Add(c1);
            c1.Focus();
        }
    }
}
