using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace NeroxUSBController
{
    class Pot : Control
    {
        [Description("Stator Image"), Category("Pot Appearance"), DefaultValue(0), Browsable(true)]
        public Image Stator { get; set; }
        [Description("Rotor Image"), Category("Pot Appearance"), DefaultValue(0), Browsable(true)]
        public Image Rotor { get; set; }
        [Description("Rotor Glowing Image"), Category("Pot Appearance"), DefaultValue(0), Browsable(true)]
        public Image RotorGlow { get; set; }
        [Description("Rotor Low Angle Limit"), Category("Pot Appearance"), DefaultValue(90), Browsable(true)]
        public int LowLimit { get; set; }
        [Description("Rotor High Angle Limit"), Category("Pot Appearance"), DefaultValue(-90), Browsable(true)]
        public int HighLimit { get; set; }

        private Boolean active = false;
        private int RotAngle = 0;

        public Pot()
        {
            this.DoubleBuffered = true;
            this.Paint += ToggleSwitch_Paint;
            this.MouseMove += Rotate;
        }

        private void ToggleSwitch_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImage(Stator, 0, 0, this.Width, this.Height);

            e.Graphics.TranslateTransform((float)this.Width / 2, (float)this.Height / 2);
            e.Graphics.RotateTransform(RotAngle);
            e.Graphics.TranslateTransform(-(float)this.Width / 2, -(float)this.Height / 2);

            if (active)
                e.Graphics.DrawImage(RotorGlow, 0, 0, this.Width, this.Height);
            else
                e.Graphics.DrawImage(Rotor, 0, 0, this.Width, this.Height);
        }

        private void Switch()
        {
            active = !active;
        }

        private void Rotate(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                int temp_angle = -e.Y;
                if ((HighLimit >= temp_angle) && (temp_angle >= LowLimit))
                {
                    RotAngle = temp_angle;
                    this.Refresh();
                }
            }
        }
    }
}