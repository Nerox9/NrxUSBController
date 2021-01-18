using System;
using System.Windows.Forms;
using System.Drawing;
using NeroxUSBController.Wrappers.OSAudio;

namespace NeroxUSBController
{
    public partial class Main : Form
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

            PropertyPanelManager.SetPropertyPanel(property_panel);


            treeView.Size = side_panel.Size;
            treeView.CreateTree();
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

        /* Get Panels */
        public Panel GetButtonPanel() { return this.button_panel; }
        public Panel GetPropertyPanel() { return this.property_panel; }
        internal AppTreeView GettreeView() { return this.treeView; }
        public Panel GetSettingsPanel() { return this.settings_panel; }
        public Panel GetSettingsSidePanel() { return this.settingsSide_panel; }
        //public Panel SetSendMessagePanel() { this.obs_panel.Visible = true; this.colorPick1.Visible = true; this.NameTextBox.Visible = true; this.property_panel_msg.Visible = false; return this.obs_panel; }

    }    
}
