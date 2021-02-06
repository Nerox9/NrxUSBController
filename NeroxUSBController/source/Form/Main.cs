using System;
using System.Windows.Forms;
using System.Drawing;
using NeroxUSBController.Wrapper.OSAudio;
using NeroxUSBController.Manager;
using NeroxUSBController.Controller.Graphic;
using NeroxUSBController.Wrapper;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace NeroxUSBController
{
    public partial class Main : System.Windows.Forms.Form
    {
        public Boolean pressedAny = false;
        public object ActiveSelection;
        private Point lastPoint;
        internal Twitch twitch = new Twitch();
        internal Twitter twitter = new Twitter();
        //private SerialCom serialCom = new SerialCom();

        public ColorPicker colorPick;

        public Main()
        {
            InitializeComponent();

            AudioDeviceManager.RefreshDevices();
            PropertyPanelManager.SetPropertyPanel(propertyPanel);
            PanelManager.CorePanel = corePanel;
            PanelManager.MainPanel = mainPanel;
            PanelManager.ButtonPanel = buttonPanel;
            PanelManager.PropertyPanel = propertyPanel;
            PanelManager.SidePanel = sidePanel;
            PanelManager.TreeView = treeView;

            DoubleBuffered = true;
        }

        private void control_panel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void control_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        const int WM_NCHITTEST = 0x0084;
        const int grip = 24;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    // Resize Control
                    Point point = new Point(m.LParam.ToInt32());
                    point = PointToClient(point);

                    if(point.X >= ClientSize.Width - grip && point.Y >= ClientSize.Height - grip)
                    {
                        // Bottom Right
                        m.Result = (IntPtr)17;
                        return;
                    }
                    else if (point.X <= grip && point.Y >= ClientSize.Height - grip)
                    {
                        // Bottom Left
                        m.Result = (IntPtr)16;
                        return;
                    }
                    else if (point.Y >= ClientSize.Height - grip)
                    {
                        // Bottom
                        m.Result = (IntPtr)15;
                        return;
                    }
                    else if (point.X >= ClientSize.Width - grip)
                    {
                        // Right
                        m.Result = (IntPtr)11;
                        return;
                    }
                    else if (point.X <= grip)
                    {
                        // Left
                        m.Result = (IntPtr)10;
                        return;
                    }
                    break;
            }

            base.WndProc(ref m);
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Red), 0, 0, 100, 100);
        }
    }    
}
