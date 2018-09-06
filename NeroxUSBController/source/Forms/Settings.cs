using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace NeroxUSBController
{
    public class Settings : Panel
    {
        public Settings()
        {
        }

        public void setPanel(Panel buttonPanel, Panel propertyPanel)
        {
            this.Location = buttonPanel.Location;
            this.BackColor = buttonPanel.BackColor;
            this.Visible = false;
        }
    }

    public class SettingTreeView : TreeView
    {

        [Description("Sets the Top Node ForeColor"), Category("Appearance"), DefaultValue(0), Browsable(true)]
        public Color ParentForeColor { get; set; }
        [Description("Sets the Active Node Color"), Category("Appearance"), DefaultValue(0), Browsable(true)]
        public Color ActiveNodeColor { get; set; }

        //** Taken from: https://stackoverflow.com/a/10364283
        protected override void OnHandleCreated(EventArgs e)
        {
            SendMessage(this.Handle, TVM_SETEXTENDEDSTYLE, (IntPtr)TVS_EX_DOUBLEBUFFER, (IntPtr)TVS_EX_DOUBLEBUFFER);
            base.OnHandleCreated(e);
        }
        // Pinvoke:
        private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
        private const int TVM_GETEXTENDEDSTYLE = 0x1100 + 45;
        private const int TVS_EX_DOUBLEBUFFER = 0x0004;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        //**

        public SettingTreeView()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawAll;

            BeforeCollapse += SettingTreeView_BeforeCollapse;
            AfterSelect += SettingTreeView_AfterSelect;

            this.ExpandAll();
            this.Visible = false;
        }

        private void SettingTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void SettingTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SettingTreeView settingTree = (SettingTreeView)sender;
            Panel selected_node_panel = (Panel)settingTree.SelectedNode.Tag;
            selected_node_panel.Visible = true;
            Console.WriteLine(selected_node_panel);
            
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            Boolean isParent = e.Node.Parent == null;
            Color foreColor = isParent ? ParentForeColor : ForeColor;

            if (!isParent && e.Node.IsSelected)
            {
                e.Graphics.FillRectangle(new SolidBrush(ActiveNodeColor), Rectangle.Inflate(e.Node.Bounds, Width, 0));
            }

            else
            {
                using (Brush b = new SolidBrush(BackColor))
                {
                    e.Graphics.FillRectangle(b, new Rectangle(0, e.Bounds.Top, ClientSize.Width, e.Bounds.Height));
                }
            }
            
            TextRenderer.DrawText(e.Graphics, e.Node.Text, Font, new Rectangle(e.Bounds.Left, e.Bounds.Top, Width, e.Bounds.Height), foreColor);

            if (isParent && e.Node.Index > 0)
            {
                e.Graphics.DrawLine(Pens.DimGray, new Point(e.Bounds.Location.X + 25, e.Bounds.Location.Y), new Point(this.Width - 25, e.Bounds.Location.Y));
            }
        }

        internal void CreateTree()
        {
            Main main = (Main)Parent.Parent;
            Panel account_panel = main.accountsPanel;

            TreeNode userNode = parentNode("User Settings", "userSettings");
            childNode("Accounts", "accounts", account_panel, userNode);
            childNode("Node", "node", "", userNode);

            TreeNode appNode = parentNode("App Settings", "appSettings");
            childNode("Accounts", "accounts", "", appNode);
            childNode("Node", "node", "", appNode);

            ExpandAll();

            TreeNode parentNode(string text, string name)
            {
                TreeNode treeNode = new TreeNode(text);
                treeNode.Name = name;
                treeNode.Tag = "";

                this.Nodes.Add(treeNode);
                return treeNode;
            }

            void childNode(string text, string name, object tag, TreeNode parent)
            {
                TreeNode treeNode = new TreeNode(text);
                treeNode.Name = name;
                treeNode.Tag = tag;
                parent.Nodes.Add(treeNode);
            }
        }
    }
}
