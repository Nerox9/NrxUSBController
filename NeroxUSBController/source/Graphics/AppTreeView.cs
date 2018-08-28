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


        public AppTreeView()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
            this.ItemDrag += new ItemDragEventHandler(this.treeView_ItemDrag);
            this.MouseDown += new MouseEventHandler(this.treeView_MouseSingleClick);
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
                Image icon = GetIcon(e.Node.IsExpanded);
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

        private void treeView_MouseSingleClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                // Toggle the TreeNode under the mouse cursor 
                // if the left mouse button was clicked. 
                case MouseButtons.Left:
                    this.GetNodeAt(e.X, e.Y).Toggle();
                    break;
            }
        }

        public void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode item = (TreeNode)e.Item;
            Boolean isParent = item.Parent == null;
           // Console.WriteLine(item.Name);

            if (!isParent)
                DoDragDrop(e.Item, DragDropEffects.Move);
            //Todo complete
        }

        public void CreateTree()
        {
            Main main = (Main)Parent.Parent;

            Obs_Screen obs_Screen_Switch = new Obs_Screen();

            Twitch twitch = main.twitch;
            Twitch_Chat_Message twitch_Chat_Message = new Twitch_Chat_Message();
            Twitch_Play_Ad twitch_Play_Ad = new Twitch_Play_Ad();
            Twitch_Slow_Chat twitch_Slow_Chat = new Twitch_Slow_Chat();

            twitch_Chat_Message.twitch = twitch;
            twitch_Play_Ad.twitch = twitch;

            TreeNode OBS_Node = parentNode("OBS", "obs");
            childNode("Screen Switch", "screenSwitch", obs_Screen_Switch, OBS_Node);
            childNode("Node1", "node1", "", OBS_Node);

            TreeNode Twitter_Node = parentNode("Twitter", "twitter");
            childNode("Send Tweet", "sendTweet", "", Twitter_Node);

            TreeNode Twitch_Node = parentNode("Twitch", "twitch");
            childNode("Chat Message", "chatMessage", twitch_Chat_Message, Twitch_Node);
            childNode("Play Ad", "playAd", twitch_Play_Ad, Twitch_Node);
            childNode("Slow Chat", "slowChat", twitch_Slow_Chat, Twitch_Node);
            childNode("Sub Chat", "subChat", twitch_Slow_Chat, Twitch_Node);


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
