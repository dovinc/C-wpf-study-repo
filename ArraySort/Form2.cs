using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArraySort
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
            label1.Text = "请输入第" + (Form1.i + 1) + "个数：";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.num[Form1.i] = int.Parse(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
