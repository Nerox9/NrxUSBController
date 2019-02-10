using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;


namespace NeroxUSBController
{
    public class ColorPick : Control
    {
        ColorDialog colorDialog = new ColorDialog();
        [Description("Button Edge Image"), Category("Appearance"), DefaultValue(0), Browsable(true)]
        public Image buttonImage { get; set; }
        public delegate void EventHandler(object sender, EventArgs e);
        private Color colorpick_shown_color;
        private int colorLighter = 25;

        public ColorPick()
        {
            this.Paint += ColorPick_Paint;
            this.MouseDown += new MouseEventHandler(this.colorPick_Click);
            colorDialog.AllowFullOpen = true;
        }

        public void ColorPick_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            colorpick_shown_color = lighterColor(base.ForeColor, colorLighter);
            SolidBrush br = new SolidBrush(colorpick_shown_color);
            int xmin = 0, ymin = 0, wid = base.Width - 2, hgt = base.Height - 2;
            Rectangle rect = new Rectangle(xmin+2, ymin+5, wid-4, hgt-10);
            e.Graphics.FillEllipse(br, rect);

            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImage(buttonImage, 0.0f, 0.0f, wid, hgt);
        }

        public void colorPick_Click(object sender, EventArgs e)
        {
            // Show the color dialog.
            DialogResult result = colorDialog.ShowDialog();
            // See if user pressed ok.
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                base.ForeColor = colorDialog.Color;
            }
        }

        private Color lighterColor(Color baseColor, int lightLevel)
        {
            int r, g, b;
            r = baseColor.R + lightLevel;
            g = baseColor.G + lightLevel;
            b = baseColor.B + lightLevel;

            if (r > 255)
                r = 255;
            else if (r < 0)
                r = 0;
            if (g > 255)
                g = 255;
            else if (g < 0)
                g = 0;
            if (b > 255)
                b = 255;
            else if (b < 0)
                b = 0;

            Color lighter_color = Color.FromArgb(r, g, b);
            return lighter_color;
        }

        public void colorPickReset()
        {
            this.ForeColor = this.Parent.BackColor;
            this.Refresh();
        }

        public Color Forecolor() { return this.ForeColor; }
        public void Forecolor(Color color) { this.ForeColor = color; }
        public void resetForecolor() { this.ForeColor = Color.DimGray; }
        public void pickMouseDown(MouseEventHandler mouseEventHandler) { this.MouseDown += mouseEventHandler; }
    }
}
