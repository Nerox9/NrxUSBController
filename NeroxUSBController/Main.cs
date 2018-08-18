using System;
using System.Windows.Forms;
using System.Drawing;

namespace NeroxUSBController
{
    public partial class Main : Form
    {
        public Boolean pressedAny = false;
        public object ActiveButton;

        public Main()
        {
            InitializeComponent();
            treeView.Size = side_panel.Size;
            this.colorPick1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chooseButton0_Click);
            this.colorPick1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chooseButton1_Click);
            this.colorPick1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chooseButton2_Click);
            this.colorPick1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chooseButton3_Click);
            this.colorPick1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chooseButton4_Click);
            this.colorPick1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chooseButton5_Click);
        }

        private void control_panel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        Point lastPoint;

        private void control_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
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
                if (sender is chooseButton)
                {
                    chooseButton button = (chooseButton)sender;
                    this.deactivateAll();
                    pressedAny = false;
                    colorPick1.ForeColor = chooseButton0.BackColor;
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
                if (sender is chooseButton)
                {
                    chooseButton button = (chooseButton)sender;
                    this.deactivateAll();
                    pressedAny = false;
                    colorPick1.ForeColor = chooseButton1.BackColor;

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
                if (sender is chooseButton)
                {
                    chooseButton button = (chooseButton)sender;
                    this.deactivateAll();
                    pressedAny = false;
                    colorPick1.ForeColor = chooseButton2.BackColor;
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
                if (sender is chooseButton)
                {
                    chooseButton button = (chooseButton)sender;
                    this.deactivateAll();
                    pressedAny = false;
                    colorPick1.ForeColor = chooseButton3.BackColor;
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
                if (sender is chooseButton)
                {
                    chooseButton button = (chooseButton)sender;
                    this.deactivateAll();
                    pressedAny = false;
                    colorPick1.ForeColor = chooseButton4.BackColor;
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
                if (sender is chooseButton)
                {
                    chooseButton button = (chooseButton)sender;
                    this.deactivateAll();
                    pressedAny = false;
                    colorPick1.ForeColor = chooseButton5.BackColor;
                }
            }
        }

        private void deactivateAll()
        {
            chooseButton0.deactivateButton();
            chooseButton1.deactivateButton();
            chooseButton2.deactivateButton();
            chooseButton3.deactivateButton();
            chooseButton4.deactivateButton();
            chooseButton5.deactivateButton();
        }
    }
}
