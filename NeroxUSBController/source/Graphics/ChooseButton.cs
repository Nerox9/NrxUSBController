using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace NeroxUSBController
{

    class ChooseButton : UserController
    {
        private SolidBrush borderBrush, textBrush;
        private Rectangle borderRectangle;
        private bool active = false;
        private bool pressed = false;
        private StringFormat stringFormat = new StringFormat();
        private Color pushColor;
        private Color backColor;
        Main main;

        public override Cursor Cursor { get; set; } = Cursors.Hand;
        [Description("Sets the Border Thickness"), Category("Appearance"), DefaultValue(3), Browsable(true)]
        public float BorderThickness { get; set; }
        [Description("Activated Color"), Category("Appearance"), DefaultValue(0), Browsable(true)]
        public Color ActiveColor { get; set; }

        public ChooseButton()
        {
            borderBrush = new SolidBrush(Color.Red);
            textBrush = new SolidBrush(Color.White);

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            this.AllowDrop = true;
            this.DoubleBuffered = true;

            this.Paint += chooseButton_Paint;
            this.DragEnter += chooseButton_DragEnter;
            this.DragDrop += chooseButton_DragDrop;
            this.Click += chooseButton_Click;
        }

        internal void setChooseButton()
        {
            main = (Main)Parent.Parent;
            main.ColorPickMouseDown(new MouseEventHandler(this.chooseButton_Click));
        }

        private void chooseButton_Paint(object sender, PaintEventArgs e)
        {
            pushColor = Color.FromArgb(ActiveColor.R / 2, ActiveColor.G / 2, ActiveColor.B / 2);
            borderRectangle = new Rectangle(0, 0, Width, Height);
            e.Graphics.DrawRectangle(new Pen(borderBrush, BorderThickness), borderRectangle);
            e.Graphics.DrawString(this.Text, this.Font, (active) ? textBrush : borderBrush, borderRectangle, stringFormat);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!pressed)
                backColor = base.BackColor;
            base.OnMouseDown(e);
            base.BackColor = pushColor;
            active = true;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!pressed && !main.pressedAny)
            {
                base.OnMouseUp(e);
                base.BackColor = ActiveColor;
                active = false;
                pressed = true;
                main.pressedAny = true;
                main.ActiveSelection = this;
                main.SetPropertyPanelController(this);
            }

            else
            {
                base.OnMouseUp(e);
                base.BackColor = backColor;
                main.resetColorPickForeColor();
                active = false;
                pressed = false;
            }
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            // isActive gives previous status
            if (this.isActive())
            {
                if (sender is ColorPick)
                {
                    this.BackColor = main.ColorPickForeColor();
                    this.ActiveColor = main.ColorPickForeColor();
                }
            }
            else if (this.isClicked())
            {
                if (sender is ChooseButton)
                {
                    ChooseButton button = (ChooseButton)sender;
                    main.deactivateAll();
                    main.pressedAny = false;
                    main.ColorPickForeColor(this.ActiveColor);
                }
            }
        }

        private void chooseButton_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void chooseButton_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode node = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            controlType = (ControllerProperty)node.Tag;
            setActive();

            Console.WriteLine(node);
            //Console.WriteLine(sender);
        }

        public Boolean isActive() { return pressed; }
        public Boolean isClicked() { return active; }
        public void setActive() { main.deactivateAll(); OnMouseDown(new MouseEventArgs(Control.MouseButtons, 0, 0, 0, 0)); chooseButton_Click(this, new EventArgs()); OnMouseUp(new MouseEventArgs(Control.MouseButtons, 0, 0, 0, 0)); }
        public void activateButton() { if (!pressed) { OnMouseUp(new MouseEventArgs(Control.MouseButtons, 0, 0, 0, 0)); } }
        public void deactivateButton() { if (pressed) { OnMouseUp(new MouseEventArgs(Control.MouseButtons, 0, 0, 0, 0)); } }
    }
}
