using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace goodsNumCaculate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[,] goods = { { 100, 200, 300 }, { 200, 140, 230 }, { 40, 10, 50 }, { 200, 3, 37 } };

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            showResult();
        }


        private void showResult()
        {
            int sum1 = 0;
            int sum2 = 0;
            labelColumn.Text = "\n1号仓库  2号仓库  3号仓库  合计";
            labelRow.Text = "A货品\nB货品\nC货品\nD货品\n合计";
            for (int i = 0; i <= goods.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= goods.GetUpperBound(1); j++)
                {
                    if (goods[i, j] < 10)
                    {
                        labelResult.Text += "  ";
                    }
                    else if (goods[i, j] >= 10 && goods[i, j] < 100)
                    {
                        labelResult.Text += " ";
                    }
                    labelResult.Text += goods[i, j] + "   ";
                    sum1 += goods[i, j];
                }
                labelResult.Text += sum1;
                labelResult.Text += "\n";
                sum1 = 0;
            }
            for (int j = 0; j <= goods.GetUpperBound(1); j++)
            {
                for (int i = 0; i <= goods.GetUpperBound(0); i++)
                {
                    sum2 += goods[i, j];
                }
                if (sum2 < 10)
                {
                    labelResult.Text += "  ";
                }
                else if (sum2 >= 10 && sum2 < 100)
                {
                    labelResult.Text += " ";
                }
                labelResult.Text += sum2;
                labelResult.Text += "  ";
                sum2 = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] newArray = goods;
            for(int i = 0; i<= newArray.GetUpperBound(0); i++)
            {
                newArray[i, 0] = 0;
                labelResult.Text = "";
                showResult();
            }
        }
    }
}
