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

namespace controlArray
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<Line> data = new List<Line>();

            Random ran = new Random();

            for (int i = 0; i < 5; i++)
            {
                data.Add(new Line(ran.Next(100), ran.Next(100), ran.Next(100), ran.Next(100), ran.Next(100)));
            }

            dataGrid.DataContext = data;
        }

        private void Desend(int[] arr)
        {
            Array.Sort(arr, (x, y) => -x.CompareTo(y)); 
        }

        private int SumArr(params int[] arr)
        {
            int total = 0;
            foreach (int d in arr)
            {
                total += d;
            }
            return total;
        }

        private int[] data2Arr(List<Line> data)
        {
            int[] rtnIntArr = new int[data.Count * 5];
            for (int i = 0; i < data.Count; i++)
            {
                var line = data[i];
                rtnIntArr[i * 5 + 0] = line.C1;
                rtnIntArr[i * 5 + 1] = line.C2;
                rtnIntArr[i * 5 + 2] = line.C3;
                rtnIntArr[i * 5 + 3] = line.C4;
                rtnIntArr[i * 5 + 4] = line.C5;
            }
            return rtnIntArr;
        }

        private void TotalClick(object sender, RoutedEventArgs e)
        {
            int total = SumArr(data2Arr((List<Line>)dataGrid.DataContext));
            textBlock1.Text = "所有文本框数字之和为：\n" + total;
        }

        private void SortClick(object sender, RoutedEventArgs e)
        {
            int[] sortArr = data2Arr((List<Line>)dataGrid.DataContext);
            Desend(sortArr);
            textBlock1.Text = "降序排列如下：\n";
            foreach (int d in sortArr)
            {
                textBlock1.Text += d + "    ";
            }

        }

        private void DiagonalClick(object sender, RoutedEventArgs e)
        {
            List<Line> data = (List<Line>)dataGrid.DataContext;
            int total = SumArr(data[0].C1, data[1].C2, data[2].C3, data[3].C4, data[4].C5);
            textBlock1.Text = "左上右下对角线之和：\n" + total;
        }
    }

    class Line
    {
        public Line(int c1, int c2, int c3, int c4, int c5)
        {
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
            C5 = c5;
        }
        public int C1 { get; set; }
        public int C2 { get; set; }
        public int C3 { get; set; }
        public int C4 { get; set; }
        public int C5 { get; set; }
    }

}
