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

        public Main()
        {
            InitializeComponent();
            

            propertyPanelController = new PropertyPanelController(this, property_panel);
            treeView.Size = side_panel.Size;
            treeView.CreateTree();
            this.chooseButton0.setChooseButton();
            this.chooseButton1.setChooseButton();
            this.chooseButton2.setChooseButton();
            this.chooseButton3.setChooseButton();
            this.chooseButton4.setChooseButton();
            this.chooseButton5.setChooseButton();
            this.toggleSwitch1.setToggleSwitch();
            this.toggleSwitch2.setToggleSwitch();
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

        public Color ColorPickForeColor() { return colorPick1.ForeColor; }
        public void ColorPickForeColor(Color color) { colorPick1.ForeColor = color; }
        public void resetColorPickForeColor() { colorPick1.ForeColor = colorPick1.Parent.BackColor; }
        public void ColorPickMouseDown(MouseEventHandler mouseEventHandler) { this.colorPick1.MouseDown += mouseEventHandler; }

        public void deactivateAll()
        {
            chooseButton0.deactivateButton();
            chooseButton1.deactivateButton();
            chooseButton2.deactivateButton();
            chooseButton3.deactivateButton();
            chooseButton4.deactivateButton();
            chooseButton5.deactivateButton();
            toggleSwitch1.deactivateSwitch();
            toggleSwitch2.deactivateSwitch();
        }

        public void colorPickReset()
        {
            colorPick1.ForeColor = colorPick1.Parent.BackColor;
            colorPick1.Refresh();
        }

        public Panel GetButtonPanel() { return this.button_panel; }
        public Panel GetPropertyPanel() { return this.property_panel; }
        internal AppTreeView GettreeView() { return this.treeView; }
        public Panel GetSettingsPanel() { return this.settings_panel; }
        public Panel GetSettingsSidePanel() { return this.settingsSide_panel; }
        //public Panel SetSendMessagePanel() { this.obs_panel.Visible = true; this.colorPick1.Visible = true; this.NameTextBox.Visible = true; this.property_panel_msg.Visible = false; return this.obs_panel; }
        public void SetPropertyPanelController(object sender) { this.propertyPanelController.SetPropertyPanel(sender); }

    }    
}
