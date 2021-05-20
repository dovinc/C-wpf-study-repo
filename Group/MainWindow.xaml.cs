
using Group.ViewModel;
using JinianNet.JNTemplate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Group
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string SyntaxHighlighting { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            // LoadEditorTextFromFile("D:/test.txt");
            DataContext = this;
            SyntaxHighlighting = "Java";
        }


        public List<Node> NodeList { get; set; }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            NodeList = GetNodeList();
            this.TreeView_NodeList.ItemsSource = NodeList;
            ExpandTree();
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
            /*if ((ComboBoxItem)LangType.SelectedItem != null && ((ComboBoxItem)LangType.SelectedItem).Content != null)
            {
                // syntaxHighlighting = ((ComboBoxItem)LangType.SelectedItem).Content.ToString();
                editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition(SyntaxHighlighting);
                // MessageBox.Show(syntaxHighlighting);
            }*/
        }












        // 临时
        private List<Node> GetNodeList()
        {
            Node leafOneNode = new Node();
            leafOneNode.NodeName = "叶子节点一";
            leafOneNode.NodeContent = "我是叶子节点一";
            leafOneNode.NodeType = NodeType.LeafNode;
            leafOneNode.Nodes = new List<Node>();

            Node leafTwoNode = new Node();
            leafTwoNode.NodeName = "叶子节点二";
            leafTwoNode.NodeContent = "我是叶子节点二";
            leafTwoNode.NodeType = NodeType.LeafNode;
            leafTwoNode.Nodes = new List<Node>();

            Node leafThreeNode = new Node();
            leafThreeNode.NodeName = "叶子节点三";
            leafThreeNode.NodeContent = "我是叶子节点三";
            leafThreeNode.NodeType = NodeType.LeafNode;
            leafThreeNode.Nodes = new List<Node>();

            Node secondLevelNode = new Node();
            secondLevelNode.NodeName = "二级节点";
            secondLevelNode.NodeContent = "我是二级节点";
            secondLevelNode.NodeType = NodeType.StructureNode;
            secondLevelNode.Nodes = new List<Node>() { leafOneNode, leafTwoNode, leafThreeNode };

            Node firstLevelNode = new Node();
            firstLevelNode.NodeName = "一级节点";
            firstLevelNode.NodeContent = "我是一级节点";
            firstLevelNode.NodeType = NodeType.StructureNode;
            firstLevelNode.Nodes = new List<Node>() { secondLevelNode };

            return new List<Node>()
            {
                new Node(){NodeName="根节点",NodeContent="我是根节点",NodeType=NodeType.RootNode,Nodes=new List<Node>(){firstLevelNode}}
            };
        }

        private void ExpandTree()
        {
            if (this.TreeView_NodeList.Items != null && this.TreeView_NodeList.Items.Count > 0)
            {
                foreach (var item in this.TreeView_NodeList.Items)
                {
                    DependencyObject dependencyObject = this.TreeView_NodeList.ItemContainerGenerator.ContainerFromItem(item);
                    if (dependencyObject != null)//第一次打开程序，dependencyObject为null，会出错
                    {
                        ((TreeViewItem)dependencyObject).ExpandSubtree();
                    }
                }
            }
        }

        /// <summary>
        /// 新增节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_AddNode_Click(object sender, RoutedEventArgs e)
        {
            var currentNode = FindTheNode(NodeList, selectedNode.NodeId);
            if (currentNode != null)
            {
                if (currentNode.NodeType == NodeType.LeafNode)
                {
                    MessageBox.Show("叶子节点不支持新增节点操作!");
                }
                else
                {
                    MessageBox.Show("开始新增节点操作!");
                }
            }
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_DeleteNode_Click(object sender, RoutedEventArgs e)
        {
            var currentNode = FindTheNode(NodeList, selectedNode.NodeId);
            if (currentNode != null)
            {
                if (currentNode.NodeType != NodeType.LeafNode)
                {
                    MessageBox.Show("非叶子节点不支持删除操作!");
                }
                else
                {
                    MessageBoxResult dr = MessageBox.Show("确定要删除这个节点吗？", "提示", MessageBoxButton.OKCancel);
                    if (dr == MessageBoxResult.OK)
                    {
                        DeleteTheNode(NodeList, currentNode);
                        MessageBox.Show("成功删除节点！");
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        // 其中删除节点需要使用下面的DeleteTheNode()方法，该方法使用递归思想实现删除指定节点的逻辑。

        private void DeleteTheNode(List<Node> NodeList, Node deleteNode)
        {
            foreach (Node node in NodeList)
            {
                if (node.Nodes != null && node.Nodes.Count > 0)
                {
                    DeleteTheNode(node.Nodes, deleteNode);
                }
                if (node == deleteNode)
                {
                    node.IsDeleted = true;
                }
            }
        }
//不管是删除节点还是新增节点，都需要获取当前选中的节点，使用FindTheNode()方法实现。

        private Node FindTheNode(List<Node> NodeList, string nodeId)
        {
            Node findedNode = null;
            foreach (Node node in NodeList)
            {
                if (node.Nodes != null && node.Nodes.Count > 0)
                {
                    if ((findedNode = FindTheNode(node.Nodes, nodeId)) != null)
                    {
                        return findedNode;
                    }
                }
                if (node.NodeId == nodeId)
                {
                    return node;
                }
            }
            return findedNode;
        }
        /*处理PreviewMouseRightButtonDown事件
因为叶子节点不支持增加节点操作，非叶子结点不支持删除节点操作，所以在点击鼠标右键时，需要检测选中节点的类型并进行控制。
为了实现这个功能，可以为TreeView绑定事件PreviewMouseRightButtonDown，在事件处理器中进行相应的控制即可。

     <TreeView.ItemContainerStyle>
                <Style TargetType = "{x:Type TreeViewItem}" >
                    < EventSetter Event="TreeViewItem.PreviewMouseRightButtonDown" Handler="TreeViewItem_PreviewMouseRightButtonDown"/>
                </Style>
     </TreeView.ItemContainerStyle>*/
    // 下面是PreviewMouseRightButtonDown事件的事件处理器代码。

        private void TreeViewItem_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            var treeViewItem = VisualUpwardSearch<TreeViewItem>(e.OriginalSource as DependencyObject) as TreeViewItem;
            if (treeViewItem != null)
            {
                Node currentNode = treeViewItem.Header as Node;
                if (currentNode.NodeType != NodeType.LeafNode)
                {
                    MenuItem_AddNode.IsEnabled = true;
                    MenuItem_DeleteNode.IsEnabled = false;
                }
                else
                {
                    MenuItem_AddNode.IsEnabled = false;
                    MenuItem_DeleteNode.IsEnabled = true;
                }
                treeViewItem.Focus();
                e.Handled = true;
            }
        }
// 代码中使用到VisualUpwardSearch()方法，该方法用于寻找控件的最外层父控件。

        private DependencyObject VisualUpwardSearch<T>(DependencyObject source)
        {
            while (source != null && source.GetType() != typeof(T))
            {
                source = VisualTreeHelper.GetParent(source);
            }
            return source;
        }

/*查找下一个节点
有时候，还需要实现循环“查找下一个”的功能，在画面中增加输入框和按钮。

<TextBox x:Name="TextBox_FindNextNode" Grid.Column="1" HorizontalAlignment="Left" Height="23" Margin="49,20,-160,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="120" LostFocus="TextBox_FindNextNode_LostFocus"/>
<Button x:Name="Button_FindNextNode" Content="查找下一个" Grid.Column="1" HorizontalAlignment="Left" Margin="188,20,-254,0" VerticalAlignment="Top" Width="75" Click="Button_FindNextNode_Click"/>
为了实现循环“查找下一个”，定义了下面两个对象。*/

private int nextSearchedNodeIndex = -1;
        private Node selectedNode;

        public List<Node> searchedNodeList { get; set; }

        /*searchedNodeList 记录根据关键字查找到的所有匹配的节点，nextSearchedNodeIndex 记录当前查看节点的位置。
搜索框失去焦点时，查找匹配的节点并保存至searchedNodeList ，同时将索引置为-1。*/

        private void TextBox_FindNextNode_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.TextBox_FindNextNode.Text.Trim()))
            {
                nextSearchedNodeIndex = -1;
                searchedNodeList = FindMatchedNodes(NodeList, this.TextBox_FindNextNode.Text.Trim());
            }
        }
        //点击“查找下一个”按钮，新增nextSearchedNodeIndex ，再使用nextSearchedNodeIndex 从searchedNodeList拿到当前展示的节点。这里需要注意的是一轮循环结束后，nextSearchedNodeIndex 再次置为-1，循环重新开始。

        private void Button_FindNextNode_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TextBox_FindNextNode.Text.Trim()))
            {
                MessageBox.Show("请输入查找条件!");
                return;
            }
            if (searchedNodeList != null && searchedNodeList.Count > 0)
            {
                //循环查找下一个
                if (nextSearchedNodeIndex >= searchedNodeList.Count - 1)
                {
                    nextSearchedNodeIndex = -1;
                }
                nextSearchedNodeIndex += 1;
                selectedNode = searchedNodeList[nextSearchedNodeIndex];
                SelectTheCurrentNode();
            }
            else
            {
                MessageBox.Show("没有找到满足条件的节点");
            }
        }
        //其中，查找匹配节点的逻辑由FindMatchedNodes()方法完成，该方法同样使用递归思想来实现。

        private List<Node> FindMatchedNodes(List<Node> srcNodeList, string filterString)
        {
            List<Node> destNodeList = new List<Node>();
            foreach (Node node in srcNodeList)
            {
                if (node.NodeName.Contains(filterString))
                {
                    destNodeList.Add(node);
                }
                if (node.Nodes != null && node.Nodes.Count > 0)
                {
                    destNodeList.AddRange(FindMatchedNodes(node.Nodes, filterString));
                }
            }
            return destNodeList;
        }
        //其中，SelectTheCurrentNode()方法实现选中当前节点，并将焦点置于当前选中节点。这里同样离不开递归的功劳。

        private void SelectTheCurrentNode()
        {
            if (this.TreeView_NodeList.Items != null && this.TreeView_NodeList.Items.Count > 0)
            {
                foreach (var item in this.TreeView_NodeList.Items)
                {
                    DependencyObject dependencyObject = this.TreeView_NodeList.ItemContainerGenerator.ContainerFromItem(item);
                    if (dependencyObject != null)//第一次打开程序，dependencyObject为null，会出错
                    {
                        TreeViewItem tvi = (TreeViewItem)dependencyObject;
                        if ((tvi.Header as Node).NodeId == selectedNode.NodeId)
                        {
                            tvi.IsSelected = true;
                            tvi.Focus();
                        }
                        else
                        {
                            SetNodeSelected(tvi);
                        }
                    }
                }
            }
        }
        private void SetNodeSelected(TreeViewItem Item)
        {
            foreach (var item in Item.Items)
            {
                DependencyObject dependencyObject = Item.ItemContainerGenerator.ContainerFromItem(item);
                if (dependencyObject != null)
                {
                    TreeViewItem treeViewItem = (TreeViewItem)dependencyObject;
                    if ((treeViewItem.Header as Node).NodeId == selectedNode.NodeId)
                    {
                        treeViewItem.IsSelected = true;
                        treeViewItem.Focus();
                    }
                    else
                    {
                        treeViewItem.IsSelected = false;
                        if (treeViewItem.HasItems)
                        {
                            SetNodeSelected(treeViewItem);
                        }
                    }
                }
            }
        }
        // 处理SelectedItemChanged事件
        // 操作TreeView，不然会选中节点，触发SelectedItemChanged事件，下面是SelectedItemChanged事件的处理代码。

        private void TreeView_NodeList_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Node node = this.TreeView_NodeList.SelectedItem as Node;
            if (node != null)
            {
                selectedNode = node;
                MessageBox.Show("当前选中的节点是:" + selectedNode.NodeName);
            }
        }

    }
}
