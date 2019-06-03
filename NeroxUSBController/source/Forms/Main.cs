using System;
using System.Windows.Forms;
using System.Drawing;

namespace NeroxUSBController
{
    public partial class Main : Form
    {
        private Point lastPoint;
        internal Twitch twitch = new Twitch();
        internal Twitter twitter = new Twitter();
        //private SerialCom serialCom = new SerialCom();

        public Main()
        {
            InitializeComponent();
        }


        /* Get Panels */
        //public Panel GetButtonPanel() { return this.button_panel; }
        //public Panel GetPropertyPanel() { return this.property_panel; }
        //internal AppTreeView GettreeView() { return this.side_panel.treeView; }
        //public Panel GetSettingsPanel() { return this.settings_panel; }
        //public Panel GetSettingsSidePanel() { return this.settingsSide_panel; }
        //public Panel SetSendMessagePanel() { this.obs_panel.Visible = true; this.colorPick1.Visible = true; this.NameTextBox.Visible = true; this.property_panel_msg.Visible = false; return this.obs_panel; }
        //public void SetPropertyPanelController(object sender) { this.propertyPanelController.SetPropertyPanel(sender); }

    }    
}
