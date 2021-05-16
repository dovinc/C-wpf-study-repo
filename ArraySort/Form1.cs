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
    public partial class Form1 : Form
    {
        private int size;
        public static int[] num;
        public static int i;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("请输入与数字个数");
                return;
            }
            size = Int32.Parse(textBox1.Text);
            num = new int[size];
            Form2 form2 = new Form2();
            for(i = 0; i < num.Length;)
            {
                if (DialogResult.OK == form2.ShowDialog())
                    i++;
            }
            label1.Text = "您输入的数字序列为:\n";
            for (i = 0; i < num.Length; i++)
            {
                label1.Text += num[i] + " ";
            }
            int temp = num[0];
            label1.Text += "\n\n排序后的数字序列为：\n";
            for(i = 0; i <= num.Length-1; i++)
            {
                for(int j = i + 1; j <= num.Length - 1; j++)
                {
                    if(num[i] > num[j])
                    {
                        temp = num[i];
                        num[i] = num[j];
                        num[j] = temp;
                    }
                }
            }
            for(i = 0; i < num.Length; i++)
            {
                label1.Text += num[i] + "  ";
            }
        }
    }
}
