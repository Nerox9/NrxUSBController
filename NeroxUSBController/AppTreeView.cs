using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace NeroxUSBController
{
    class AppTreeView : TreeView
    {
        [Description("Sets the Top Node Color"), Category("Appearance"), DefaultValue(0), Browsable(true)]
        public Color ParentBackColor { get; set; }
        [Description("Sets the Child Node Color"), Category("Appearance"), DefaultValue(0), Browsable(true)]
        public Color ChildBackColor { get; set; }
        [Description("Button Hide Node Image"), Category("Appearance"), DefaultValue(0), Browsable(true)]
        public Image ButtonImageHide { get; set; }
        [Description("Button Show Node Image"), Category("Appearance"), DefaultValue(0), Browsable(true)]
        public Image ButtonImageShow { get; set; }

        private ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));

        public AppTreeView()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawAll;         
            this.ItemDrag += new ItemDragEventHandler(this.treeView_ItemDrag);
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            Boolean isParent = e.Node.Parent == null;
            Color backColor = isParent ? ParentBackColor : ChildBackColor;
            using (Brush b = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(b, new Rectangle(0, e.Bounds.Top, ClientSize.Width, e.Bounds.Height));
            }

            if (e.Node.Nodes.Count > 0)
            {
                Image icon = GetIcon(e.Node.IsExpanded); // TODO: true=down;false:right
                e.Graphics.InterpolationMode = InterpolationMode.High;
                e.Graphics.DrawImage(icon, e.Bounds.Left - icon.Width+20, e.Bounds.Top + 3, 10, 10);
            }

            TextRenderer.DrawText(e.Graphics, e.Node.Text, Font, new Rectangle(0, e.Bounds.Top, e.Bounds.Width + 25, e.Bounds.Height), ForeColor);

            if ((e.State & TreeNodeStates.Selected) != 0)
                ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(0, e.Bounds.Top, ClientSize.Width, e.Bounds.Height));
        }

        private Image GetIcon(Boolean isExpanded)
        {
            if (isExpanded)
                return ButtonImageShow;
            else
                return ButtonImageHide;
        }

        private int GetTopNodeIndex(TreeNode node)
        {
            while (node.Parent != null)
                node = node.Parent;

            return Nodes.IndexOf(node);
        }

        public void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            Console.WriteLine(e.Item);
            DoDragDrop(e.Item, DragDropEffects.Move);
            //Todo complete
        }
    }
}
