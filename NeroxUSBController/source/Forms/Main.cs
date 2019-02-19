using System;
using System.Windows.Forms;
using System.Drawing;

namespace NeroxUSBController
{
    public partial class Main : Form
    {
        public Boolean pressedAny = false;
        public object ActiveSelection;
        private Point lastPoint;
        internal PropertyPanelController propertyPanelController;
        internal Twitch twitch = new Twitch();
        internal Twitter twitter = new Twitter();
        //private SerialCom serialCom = new SerialCom();

        public ColorPick colorPick;

        public Main()
        {
            
            //this.colorPick = propertyPanelController.default_Property.ColorPicker;

            InitializeComponent();
            propertyPanelController = new PropertyPanelController(this, property_panel);
            //propertyPanelController.SetControllers(property_panel);

            /*
            treeView.Size = side_panel.Size;
            treeView.CreateTree();
            */
            button_panel.chooseButton0.setChooseButton();
            button_panel.chooseButton1.setChooseButton();
            button_panel.chooseButton2.setChooseButton();
            button_panel.chooseButton3.setChooseButton();
            button_panel.chooseButton4.setChooseButton();
            button_panel.chooseButton5.setChooseButton();
            button_panel.toggleSwitch1.setToggleSwitch();
            button_panel.toggleSwitch2.setToggleSwitch();
            
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

        public void deactivateAll()
        {
            button_panel.chooseButton0.deactivateButton();
            button_panel.chooseButton1.deactivateButton();
            button_panel.chooseButton2.deactivateButton();
            button_panel.chooseButton3.deactivateButton();
            button_panel.chooseButton4.deactivateButton();
            button_panel.chooseButton5.deactivateButton();
            button_panel.toggleSwitch1.deactivateSwitch();
            button_panel.toggleSwitch2.deactivateSwitch();
        }

        

        /* Get Panels */
        public Panel GetButtonPanel() { return this.button_panel; }
        public Panel GetPropertyPanel() { return this.property_panel; }
        internal AppTreeView GettreeView() { return this.side_panel.treeView; }
        public Panel GetSettingsPanel() { return this.settings_panel; }
        public Panel GetSettingsSidePanel() { return this.settingsSide_panel; }
        //public Panel SetSendMessagePanel() { this.obs_panel.Visible = true; this.colorPick1.Visible = true; this.NameTextBox.Visible = true; this.property_panel_msg.Visible = false; return this.obs_panel; }
        public void SetPropertyPanelController(object sender) { this.propertyPanelController.SetPropertyPanel(sender); }

    }    
}
