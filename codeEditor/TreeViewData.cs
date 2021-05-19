using System.Collections.Generic;

namespace TreeView
{
    public class TreeViewData
    {
        private static TreeViewData _Data = null;

        public static TreeViewData Data
        {
            get
            {
                if (_Data == null)
                {
                    _Data = new TreeViewData();

                    var rn1 = new TreeNode() { Label = "Root A", Level = 1 };
                    rn1.ChildNodes.Add(new TreeNode() { Label = "Root A - Child 1", Level = 2 });
                    rn1.ChildNodes.Add(new TreeNode() { Label = "Root A - Child 2", Level = 2 });
                    rn1.ChildNodes.Add(new TreeNode() { Label = "Root A - Child 3", Level = 2 });
                    rn1.ChildNodes.Add(new TreeNode() { Label = "Root A - Child 4", Level = 2 });
                    rn1.ChildNodes.Add(new TreeNode() { Label = "Root A - Child 5", Level = 2 });

                    var rn2 = new TreeNode() { Label = "Root B", Level = 1 };
                    rn2.ChildNodes.Add(new TreeNode() { Label = "Root B - Child 1", Level = 2 });

                    var rn21 = new TreeNode() { Label = "Root B - Child 2", Level = 2 };
                    rn21.ChildNodes.Add(new TreeNode() { Label = "Root B - Child 2 - Child 1", Level = 3 });
                    rn21.ChildNodes.Add(new TreeNode() { Label = "Root B - Child 2 - Child 2", Level = 3 });
                    rn2.ChildNodes.Add(rn21);
                    rn2.ChildNodes.Add(new TreeNode() { Label = "Root B - Child 3", Level = 2 });
                    rn2.ChildNodes.Add(new TreeNode() { Label = "Root B - Child 4", Level = 2 });
                    rn2.ChildNodes.Add(new TreeNode() { Label = "Root B - Child 5", Level = 2 });



                    var rn3 = new TreeNode() { Label = "Root C", Level = 1 };
                    rn3.ChildNodes.Add(new TreeNode() { Label = "Root C - Child 1", Level = 2 });
                    rn3.ChildNodes.Add(new TreeNode() { Label = "Root C - Child 2", Level = 2 });
                    rn3.ChildNodes.Add(new TreeNode() { Label = "Root C - Child 3", Level = 2 });
                    rn3.ChildNodes.Add(new TreeNode() { Label = "Root C - Child 4", Level = 2 });
                    rn3.ChildNodes.Add(new TreeNode() { Label = "Root C - Child 5", Level = 2 });

                    _Data.RootNodes.Add(rn1);
                    _Data.RootNodes.Add(rn2);
                    _Data.RootNodes.Add(rn3);
                }
                return _Data;
            }
        }

        private System.Collections.ObjectModel.ObservableCollection<TreeNode> _RootNodes = null;

        public IList<TreeNode> RootNodes { get { return _RootNodes ?? (_RootNodes = new System.Collections.ObjectModel.ObservableCollection<TreeNode>()); } }

        public class TreeNode
        {
            public string Label { get; set; }

            public int Level { get; set; }

            private System.Collections.ObjectModel.ObservableCollection<TreeNode> _ChildNodes = null;

            public IList<TreeNode> ChildNodes { get { return _ChildNodes ?? (_ChildNodes = new System.Collections.ObjectModel.ObservableCollection<TreeNode>()); } }
        }
    }
}
