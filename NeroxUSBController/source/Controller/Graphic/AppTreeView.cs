using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using NeroxUSBController.Property.SystemAudio;
using NeroxUSBController.Manager;
using NeroxUSBController.Panel.Property;
using System.Runtime.InteropServices;

namespace NeroxUSBController.Controller.Graphic
{
    class AppTreeView : TreeView
    {
        [Description("Sets the Top Node Color"), Category("Tree View"), DefaultValue(0), Browsable(true)]
        public Color ParentBackColor { get; set; }
        [Description("Sets the Child Node Color"), Category("Tree View"), DefaultValue(0), Browsable(true)]
        public Color ChildBackColor { get; set; } = Color.Gray;
        [Description("Button Hide Node Image"), Category("Tree View"), DefaultValue(0), Browsable(true)]
        public Image ButtonImageHide { get; set; } = Properties.Resources.hidetree;
        [Description("Button Show Node Image"), Category("Tree View"), DefaultValue(0), Browsable(true)]
        public Image ButtonImageShow { get; set; } = Properties.Resources.showtree;

        public AppScrollBar scrollBar = new AppScrollBar();
        DragImage DragImage;
        int dragOffset = 6;

        private const int WM_ERASEBKGND = 0x0014;
        private const int TVM_SETEXTENDEDSTYLE = 0x1100 + 44;
        private const int TVM_GETEXTENDEDSTYLE = 0x1100 + 45;
        private const int TVS_EX_DOUBLEBUFFER = 0x0004;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        

        public AppTreeView()
        {
            //DrawMode = TreeViewDrawMode.OwnerDrawAll;
            ItemDrag += new ItemDragEventHandler(treeView_ItemDrag);
            MouseDown += new MouseEventHandler(treeView_MouseDown);
            //BeforeExpand += new TreeViewCancelEventHandler(treeView_BeforeExpand);

            BackColor = Color.FromArgb(30, 30, 30);
            ItemHeight = 50;
            ForeColor = Color.Red;
            CreateTree();
            FullRowSelect = true;

            DoubleBuffered = true;
        }

        public void CreateTree()
        {
            if (this.Nodes.Count > 0)
                return;

            //TreeNode OBS_Node = parentNode("OBS", "obs", Properties.Resources.obs);
            //childNode("Screen Switch", "screenSwitch", typeof(Obs_Screen), Properties.Resources.obs, OBS_Node);
            //childNode("Node1", "node1", typeof(Obs_Screen), Properties.Resources.obs, OBS_Node);
            //
            //TreeNode Twitter_Node = parentNode("Twitter", "twitter", Properties.Resources.twitter);
            //childNode("Send Tweet", "sendTweet", typeof(Obs_Screen), Properties.Resources.twitter, Twitter_Node);
            //
            //TreeNode Twitch_Node = parentNode("Twitch", "twitch", Properties.Resources.twitch);
            //childNode("Chat Message", "chatMessage", typeof(Twitch_Chat_Message), Properties.Resources.twitch, Twitch_Node);
            //childNode("Play Ad", "playAd", typeof(Twitch_Play_Ad), Properties.Resources.twitch, Twitch_Node);
            //childNode("Slow Chat", "slowChat", typeof(Twitch_Slow_Chat), Properties.Resources.twitch, Twitch_Node);
            //childNode("Sub Chat", "subChat", typeof(Twitch_Slow_Chat), Properties.Resources.twitch, Twitch_Node);

            TreeNode Audio_Node = parentNode("Audio", "audio", Properties.Resources.sound);
            childNode("Volume", "volume", typeof(SystemAudioVolumeProperty), Properties.Resources.sound, Audio_Node);
            childNode("Mute", "mute", typeof(SystemAudioMuteProperty), Properties.Resources.mute, Audio_Node);


            TreeNode parentNode(string text, string name, Image icon)
            {
                TreeNode treeNode = new TreeNode(text);
                treeNode.Name = name;
                treeNode.Tag = new TagProperties(icon);

                this.Nodes.Add(treeNode);
                return treeNode;
            }

            void childNode(string text, string name, Type propertyType, Image icon, TreeNode parent)
            {
                TreeNode treeNode = new TreeNode(text);
                treeNode.Name = name;
                treeNode.Tag = new TagProperties(propertyType, icon);
                parent.Nodes.Add(treeNode);
            }
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            Boolean isParent = e.Node.Parent == null;
            Color backColor = isParent ? ParentBackColor : ChildBackColor;
            TagProperties tag = (TagProperties)e.Node.Tag;
            Image icon = tag.Icon;

            using (Brush b = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(b, new Rectangle(0, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height));
            }

            // Draw expander icons
            if (e.Node.Nodes.Count > 0)
            {
                Image expIcon = GetExpanderIcon(e.Node.IsExpanded);
                Size size = new Size(e.Bounds.Height / 3, e.Bounds.Height / 3);
                e.Graphics.InterpolationMode = InterpolationMode.High;
                e.Graphics.DrawImage(expIcon, e.Bounds.Left - size.Width + 20, e.Bounds.Top - size.Height / 2 + e.Bounds.Height / 2, size.Width, size.Height);
            }

            // Draw Icon
            if(icon != null)
            { 
                Size iconSize = new Size(e.Bounds.Height / 2, e.Bounds.Height / 2);
                e.Graphics.InterpolationMode = InterpolationMode.High;
                e.Graphics.DrawImage(icon, e.Bounds.Left - iconSize.Width / 2 + 50, e.Bounds.Top - iconSize.Height / 2 + e.Bounds.Height / 2, iconSize.Width, iconSize.Height);
            }

            // Draw Text
            TextRenderer.DrawText(e.Graphics, e.Node.Text, Font, new Rectangle(0, e.Bounds.Top, e.Bounds.Width + 25, e.Bounds.Height), ForeColor);

            // Focus Lines
            /*
            if ((e.State & TreeNodeStates.Selected) != 0)
                ControlPaint.DrawFocusRectangle(e.Graphics, new Rectangle(0, 0, ClientSize.Width, e.Bounds.Height));
            */
        }

        private void ScrollBar_Scroll(object sender, EventArgs e)
        {
            System.Windows.Forms.Panel sidePanel = (System.Windows.Forms.Panel)Parent;
            sidePanel.AutoScrollPosition = new Point(0,
                                scrollBar.Value);
            scrollBar.Invalidate();
            Application.DoEvents();
        }

        private Image GetExpanderIcon(Boolean isExpanded)
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

        private void treeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks > 1)
                return;
            switch (e.Button)
            {
                // Toggle the TreeNode under the mouse cursor 
                // if the left mouse button was clicked. 
                case MouseButtons.Left:
                    TreeNode node = GetNodeAt(e.X, e.Y);

                    if (node != null)
                    {
                        node.Toggle();
                    }

                    break;
            }
        }

        public void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode item = (TreeNode)e.Item;
            TagProperties tag = (TagProperties)item.Tag;
            Boolean isParent = item.Parent == null;

            if (!isParent)
            {
                Control control = PanelManager.CorePanel.Controls["dragImage"];
                DragImage = (DragImage)control;
                QueryContinueDrag += DragImage.queryContinueDrag;
                DragImage.SetImage((Image)tag.Icon.Clone(), ChildBackColor);

                DoDragDrop(item, DragDropEffects.All);
                DragImage.Hide();
            }
        }

        private void scrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            PanelManager.SidePanel.AutoScrollPosition = new Point(0, scrollBar.Value);
            scrollBar.Invalidate();
            Application.DoEvents();
        }

        public void SetScrollBar()
        {
            System.Windows.Forms.Panel sidePanel = PanelManager.SidePanel;

            //sidePanel.AutoScroll = true;

            Scroll += scrollbar_Scroll;

            Point pt = new Point(sidePanel.AutoScrollPosition.X, sidePanel.AutoScrollPosition.Y);
            scrollBar.Minimum = 0;
            scrollBar.Maximum = sidePanel.DisplayRectangle.Height;
            scrollBar.LargeChange = scrollBar.Maximum /
                    scrollBar.Height + sidePanel.Height;
            scrollBar.SmallChange = 15;
            scrollBar.Value = Math.Abs(sidePanel.AutoScrollPosition.Y);
        }


        protected override void OnHandleCreated(EventArgs e)
        {
             SendMessage(this.Handle, TVM_SETEXTENDEDSTYLE, (IntPtr)TVS_EX_DOUBLEBUFFER, (IntPtr)TVS_EX_DOUBLEBUFFER);
             base.OnHandleCreated(e);
        }

        
        public delegate void ScrollEventHandler(object sender, ScrollEventArgs e);
        public event ScrollEventHandler Scroll;
        private TreeNode mLastTop;
        // WM_VSCROLL message constants
        private const int WM_VSCROLL = 0x0115;
        private const int SB_THUMBTRACK = 5;
        private const int SB_ENDSCROLL = 8;

        
        // Flicker killer
        protected override void WndProc(ref Message m)
        {
            /*
            if (m.Msg == WM_ERASEBKGND)
            {
                m.Result = IntPtr.Zero;
                return;
            }
            */

            if (Scroll != null && m.Msg == WM_VSCROLL && this.TopNode != mLastTop)
            {
                int nfy = m.WParam.ToInt32() & 0xFFFF;
                if (nfy == SB_THUMBTRACK || nfy == SB_ENDSCROLL)
                {
                    Scroll.Invoke(this, new ScrollEventArgs(this.TopNode, nfy == SB_THUMBTRACK));
                    mLastTop = this.TopNode;
                }
            }
            base.WndProc(ref m);
        }

        public class ScrollEventArgs
        {
            // Scroll event argument
            private TreeNode mTop;
            private bool mTracking;
            public ScrollEventArgs(TreeNode top, bool tracking)
            {
                mTop = top;
                mTracking = tracking;
            }
            public TreeNode Top
            {
                get { return mTop; }
            }
            public bool Tracking
            {
                get { return mTracking; }
            }
        }
        
    }

    class TagProperties
    {
        public Type PropertyType;
        public Image Icon;

        public TagProperties(Image icon)
        {
            Icon = icon;
        }

        public TagProperties(Type propertyType, Image icon)
        {
            PropertyType = propertyType;
            Icon = icon;
        }
    }
}
