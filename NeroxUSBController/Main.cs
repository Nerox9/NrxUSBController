using System;
using System.Windows.Forms;
using System.Drawing;

namespace NeroxUSBController
{
    public partial class Main : Form
    {
        public Boolean pressedAny = false;
        public object ActiveButton;
        private Point lastPoint;

        public Main()
        {
            InitializeComponent();
            treeView.Size = side_panel.Size;
            this.colorPick1.MouseDown += new MouseEventHandler(this.chooseButton0_Click);
            this.colorPick1.MouseDown += new MouseEventHandler(this.chooseButton1_Click);
            this.colorPick1.MouseDown += new MouseEventHandler(this.chooseButton2_Click);
            this.colorPick1.MouseDown += new MouseEventHandler(this.chooseButton3_Click);
            this.colorPick1.MouseDown += new MouseEventHandler(this.chooseButton4_Click);
            this.colorPick1.MouseDown += new MouseEventHandler(this.chooseButton5_Click);
            this.colorPick1.MouseDown += new MouseEventHandler(this.toggleSwitch1_Click);
            this.colorPick1.MouseDown += new MouseEventHandler(this.toggleSwitch2_Click);
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

        private void chooseButton0_Click(object sender, EventArgs e)
        {
            // isActive gives previous status
            if (chooseButton0.isActive())
            {
                if (sender is ColorPick)
                {
                    chooseButton0.BackColor = colorPick1.ForeColor;
                    chooseButton0.ActiveColor = colorPick1.ForeColor;
                }
                else
                {
                    colorPick1.ForeColor = colorPick1.Parent.BackColor;
                    pressedAny = false;
                }
            }
            if (chooseButton0.isClicked())
            {
                if (sender is ChooseButton)
                {
                    ChooseButton button = (ChooseButton)sender;
                    this.deactivateAll();
                    pressedAny = false;
                    colorPick1.ForeColor = chooseButton0.ActiveColor;
                }
            }
        }

        private void chooseButton1_Click(object sender, EventArgs e)
        {
            // isActive gives previous status
            if (chooseButton1.isActive())
            {
                if (sender is ColorPick)
                {
                    chooseButton1.BackColor = colorPick1.ForeColor;
                    chooseButton1.ActiveColor = colorPick1.ForeColor;
                }
                else
                {
                    colorPick1.ForeColor = colorPick1.Parent.BackColor;
                    pressedAny = false;
                }
            }
            else if (chooseButton1.isClicked())
            {
                if (sender is ChooseButton)
                {
                    ChooseButton button = (ChooseButton)sender;
                    this.deactivateAll();
                    pressedAny = false;
                    colorPick1.ForeColor = chooseButton1.ActiveColor;
                }
            }
        }

        private void chooseButton2_Click(object sender, EventArgs e)
        {
            // isActive gives previous status
            if (chooseButton2.isActive())
            {
                if (sender is ColorPick)
                {
                    chooseButton2.BackColor = colorPick1.ForeColor;
                    chooseButton2.ActiveColor = colorPick1.ForeColor;
                }
                else
                {
                    colorPick1.ForeColor = colorPick1.Parent.BackColor;
                    pressedAny = false;
                }
            }
            else if (chooseButton2.isClicked())
            {
                if (sender is ChooseButton)
                {
                    ChooseButton button = (ChooseButton)sender;
                    this.deactivateAll();
                    pressedAny = false;
                    colorPick1.ForeColor = chooseButton2.ActiveColor;
                }
            }
        }

        private void chooseButton3_Click(object sender, EventArgs e)
        {
            // isActive gives previous status
            if (chooseButton3.isActive())
            {
                if (sender is ColorPick)
                {
                    chooseButton3.BackColor = colorPick1.ForeColor;
                    chooseButton3.ActiveColor = colorPick1.ForeColor;
                }
                else
                {
                    colorPick1.ForeColor = colorPick1.Parent.BackColor;
                    pressedAny = false;
                }
            }
            else if (chooseButton3.isClicked())
            {
                if (sender is ChooseButton)
                {
                    ChooseButton button = (ChooseButton)sender;
                    this.deactivateAll();
                    pressedAny = false;
                    colorPick1.ForeColor = chooseButton3.ActiveColor;
                }
            }
        }

        private void chooseButton4_Click(object sender, EventArgs e)
        {
            // isActive gives previous status
            if (chooseButton4.isActive())
            {
                if (sender is ColorPick)
                {
                    chooseButton4.BackColor = colorPick1.ForeColor;
                    chooseButton4.ActiveColor = colorPick1.ForeColor;
                }
                else
                {
                    colorPick1.ForeColor = colorPick1.Parent.BackColor;
                    pressedAny = false;
                }
            }
            else if (chooseButton4.isClicked())
            {
                if (sender is ChooseButton)
                {
                    ChooseButton button = (ChooseButton)sender;
                    this.deactivateAll();
                    pressedAny = false;
                    colorPick1.ForeColor = chooseButton4.ActiveColor;
                }
            }
        }

        private void chooseButton5_Click(object sender, EventArgs e)
        {
            // isActive gives previous status
            if (chooseButton5.isActive())
            {
                if (sender is ColorPick)
                {
                    chooseButton5.BackColor = colorPick1.ForeColor;
                    chooseButton5.ActiveColor = colorPick1.ForeColor;
                }
                else
                {
                    colorPick1.ForeColor = colorPick1.Parent.BackColor;
                    pressedAny = false;
                }
            }
            else if (chooseButton5.isClicked())
            {
                if (sender is ChooseButton)
                {
                    ChooseButton button = (ChooseButton)sender;
                    this.deactivateAll();
                    pressedAny = false;
                    colorPick1.ForeColor = chooseButton5.ActiveColor;
                }
            }
        }

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

        private void toggleSwitch1_Click(object sender, EventArgs e)
        {
            // isActive gives previous status
            if (toggleSwitch1.isActive())
            {
                if (sender is ColorPick)
                {
                    toggleSwitch1.ActiveColor = colorPick1.ForeColor;
                    toggleSwitch1.Refresh();
                }
                else if (sender is ToggleSwitch)
                {
                    colorPick1.ForeColor = toggleSwitch1.ActiveColor;
                    //this.deactivateAll();
                    pressedAny = false;
                }
            }
            else if (sender is ToggleSwitch)
            {
                colorPick1.ForeColor = colorPick1.Parent.BackColor;
                pressedAny = false;
            }
        }

        private void toggleSwitch2_Click(object sender, EventArgs e)
        {
            // isActive gives previous status
            if (toggleSwitch2.isActive())
            {
                if (sender is ColorPick)
                {
                    toggleSwitch2.ActiveColor = colorPick1.ForeColor;
                    toggleSwitch2.Refresh();
                }
                else if (sender is ToggleSwitch)
                {
                    colorPick1.ForeColor = toggleSwitch2.ActiveColor;
                    //this.deactivateAll();
                    pressedAny = false;
                }
            }
            else if (sender is ToggleSwitch)
            {
                colorPick1.ForeColor = colorPick1.Parent.BackColor;
                pressedAny = false;
            }
        }

        public void colorPickReset()
        {
            colorPick1.ForeColor = colorPick1.Parent.BackColor;
            colorPick1.Refresh();
        }

        public Panel GetButtonPanel() { return this.button_panel; }
        public Panel GetPropertyPanel() { return this.property_panel; }
        public Panel GetSettingsPanel() { return this.settings_panel; }
        public Panel GetSettingsSidePanel() { return this.settingsSide_panel; }
    }
}
