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

    class chooseButton : Control
    {
        private SolidBrush borderBrush, textBrush;
        private Rectangle borderRectangle;
        private bool active = false;
        private bool pressed = false;
        private StringFormat stringFormat = new StringFormat();
        private Color pushColor;
        private Color backColor;

        public override Cursor Cursor { get; set; } = Cursors.Hand;
        [Description("Sets the Border Thickness"), Category("Appearance"), DefaultValue(3), Browsable(true)]
        public float BorderThickness { get; set; }
        [Description("Activated Color"), Category("Appearance"), DefaultValue(0), Browsable(true)]
        public Color ActiveColor { get; set; }

        public chooseButton()
        {
            borderBrush = new SolidBrush(Color.Red);
            textBrush = new SolidBrush(Color.White);

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            this.Paint += chooseButton_Paint;
        }

        public void chooseButton_Paint(object sender, PaintEventArgs e)
        {
            pushColor = Color.FromArgb(ActiveColor.R / 2, ActiveColor.G / 2, ActiveColor.B / 2);
            borderRectangle = new Rectangle(0, 0, Width, Height);
            e.Graphics.DrawRectangle(new Pen(borderBrush, BorderThickness), borderRectangle);
            e.Graphics.DrawString(this.Text, this.Font, (active && pressed) ? textBrush : borderBrush, borderRectangle, stringFormat);
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
            Main main = (Main)Parent.Parent;
            if (!pressed && !main.pressedAny)
            {
                base.OnMouseUp(e);
                base.BackColor = ActiveColor;
                active = false;
                pressed = true;
                main.pressedAny = true;
                main.ActiveButton = this;
            }

            else
            {
                base.OnMouseUp(e);
                base.BackColor = backColor;
                active = true;
                pressed = false;
            }
        }

        public Boolean isActive() { return pressed; }
        public Boolean isClicked() { return active; }
        public void setActive(Boolean state) { pressed = state; }
        public void activateButton() { if (!pressed) { OnMouseUp(new MouseEventArgs(Control.MouseButtons, 0, 0, 0, 0)); } }
        public void deactivateButton() { if (pressed) { OnMouseUp(new MouseEventArgs(Control.MouseButtons, 0, 0, 0, 0)); } }
    }
}
