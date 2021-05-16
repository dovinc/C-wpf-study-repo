﻿using System;
using System.Collections.Generic;
using System.IO;
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

namespace codeEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // LoadEditorTextFromFile("D:/test.txt");

        } 

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter("D:/test.txt"))
                {
                    sr.Write(editor.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            editor.Text = "";
            MessageBox.Show("文件保存成功！");
        }

        private void LoadClick(object sender, RoutedEventArgs e)
        {
            LoadEditorTextFromFile("D:/test.txt");
        }

        private void LoadEditorTextFromFile(String path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {

                    // 从文件读取并显示行，直到文件的末尾
                    editor.Text = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            MessageBox.Show("文件加载成功！");
        }
    }
}
