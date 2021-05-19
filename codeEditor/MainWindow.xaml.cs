
using ICSharpCode.AvalonEdit.Highlighting;

using JinianNet.JNTemplate;
using System;
using System.Globalization;
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
        public string syntaxHighlighting { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            // LoadEditorTextFromFile("D:/test.txt");
            syntaxHighlighting = "Java";
            DataContext = this;


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

        private void RenderClick(object sender, RoutedEventArgs e)
        {
            var template = Engine.CreateTemplate(editor.Text);
            template.Set("name", "赵东");
            var result = template.Render();
            Utils.ClipboardUtil.CopyText(result);
            MessageBox.Show("已成功将渲染后文件 复制到粘贴板 ！");
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



        private void LangType_Changed(object sender, RoutedEventArgs e)
        {
            if ((ComboBoxItem)LangType.SelectedItem != null && ((ComboBoxItem)LangType.SelectedItem).Content != null)
            {
                // syntaxHighlighting = ((ComboBoxItem)LangType.SelectedItem).Content.ToString();
                editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition(syntaxHighlighting);
                // MessageBox.Show(syntaxHighlighting);
            }
        }

       
    }
}
