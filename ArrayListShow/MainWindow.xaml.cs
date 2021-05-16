using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArrayListShow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int[] GetRandoms(int minVal, int maxVal, int randomNum)
        {
            int[] randoms = new int[randomNum];
            for(int i = 0; i < randomNum; i++)
            {
                Random r = new Random(DateTime.Now.Millisecond + i);
                randoms[i] = r.Next(minVal, maxVal);
            }
            return randoms;
        }

        private void ShowResult(int size)
        {
            Object[] arrList = new Object[size];
            comboBox1.Items.CopyTo(arrList, 0);
            textBlock1.Text = "现在组合框内的数字序列依次为：\n";
            foreach(int val in arrList)
            {
                textBlock1.Text += val.ToString() + "    ";
            }
        }

        private void BtShowClick(object sender, RoutedEventArgs e)
        {
            ShowResult(comboBox1.Items.Count);
        }


        private void BtAddClick(object sender, RoutedEventArgs e)
        {
            comboBox1.Items.Add(Int32.Parse(comboBox1.Text));
            ShowResult(comboBox1.Items.Count);
        }
        private void BtDeleteClick(object sender, RoutedEventArgs e)
        {
            comboBox1.Items.Remove(comboBox1.SelectedItem);
            ShowResult(comboBox1.Items.Count);
        }

        private void BtSortClick(object sender, RoutedEventArgs e)
        {
            ArrayList arrList = new ArrayList(comboBox1.Items);
            arrList.Sort();
            textBlock1.Text = "现在组合框内的数字序列依次为：\n";
            foreach (int val in arrList)
            {
                textBlock1.Text += val.ToString() + "    ";
            }
        }

        private void WindowLoad(object sender, RoutedEventArgs e)
        {
            // 生成10个不相同的范围为1-100的随机数
            int[] rmArr = GetRandoms(1, 100, 10);
            foreach (int val in rmArr)
            {
                comboBox1.Items.Add(val);
            }
        }
    }
}
