using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NeroxUSBController
{
    class ToggleSwitch : Control
    {
        [Description("Toggle Switch Active Background Color"), Category("Switch Appearance"), DefaultValue(0), Browsable(true)]
        public Color ActiveColor { get; set; }
        [Description("Toggle Switch Passive Background Color"), Category("Switch Appearance"), DefaultValue(0), Browsable(true)]
        public Color PassiveColor { get; set; }
        [Description("Toggle Switch Button Color"), Category("Switch Appearance"), DefaultValue(0), Browsable(true)]
        public Color ButtonColor { get; set; }
        [Description("Toggle Switch Label"), Category("Switch Appearance"), DefaultValue(0), Browsable(true)]
        public Label SwitchLabel { get; set; }

        private ColorPick colorPick; 
        private Boolean active = false;
        private Point activePoint;
        private Point passivePoint;
        private RectangleF buttonRectangle;
        private Timer timer;
        private PointF buttonPosition;
        private StringFormat stringFormat = new StringFormat();
        Main main;

        public ToggleSwitch()
        {
            SetTimer();

            this.DoubleBuffered = true;

            this.Paint += ToggleSwitch_Paint;
            this.Click += toggleSwitch_Click;

            this.passivePoint = new Point(0, 18);
            this.activePoint = new Point(0, 0);
            this.buttonPosition = passivePoint;

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
        }

        public void ToggleSwitch_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = this.Parent.BackColor;
            this.Height = 43;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            SolidBrush brush = new SolidBrush(active ? ActiveColor : PassiveColor);
            SolidBrush buttonBrush = new SolidBrush(ButtonColor);
            RectangleF rectangle = new RectangleF(0, 0, Width, Height);
            Rectangle buttonTextRectangle = new Rectangle(0, 0, Width, 25);
            buttonRectangle = new RectangleF(0, 0, Width, 25);
            buttonRectangle.Location = buttonPosition;
            buttonTextRectangle.Location = new Point((int)buttonPosition.X, (int)buttonPosition.Y);

            GraphicsPath rRect = MakeRoundedRect(rectangle, Width/2, Height/3, true, true, true, true);
            e.Graphics.FillPath(brush, rRect);
            e.Graphics.FillEllipse(buttonBrush, buttonRectangle);
            e.Graphics.DrawString(this.Text, this.Font, brush, buttonTextRectangle, stringFormat);
        }

        internal void setToggleSwitch()
        {
            main = (Main)Parent.Parent;
            this.colorPick = main.colorPick;
            //this.colorPick.pickMouseDown(new MouseEventHandler(this.toggleSwitch_Click));
        }

        private void toggleSwitch_Click(object sender, EventArgs e)
        {
            // isActive gives previous status
            if (this.isActive())
            {
                main.ActiveSelection = this;
                if (sender is ColorPick)
                {
                    this.ActiveColor = this.colorPick.Forecolor();
                    this.Refresh();
                }
                else if (sender is ToggleSwitch)
                {
                    //this.colorPick.Forecolor(this.ActiveColor);
                    main.pressedAny = false;
                }
            }
        }

        private void ToggleSwitch_ButtonTimer(object sender, EventArgs e)
        {
            PointF button_loc = buttonRectangle.Location;
            int step = 3;

            if (active)
                step *= -1;

            buttonRectangle.Location = buttonPosition;

            if ((active && (button_loc.Y == activePoint.Y)) || (!active && (button_loc.Y == passivePoint.Y)))
            {
                //this.Refresh();
                timer.Stop();
            }
            else if ((button_loc.Y >= activePoint.Y) && (button_loc.Y <= passivePoint.Y))
            {
                buttonPosition = new PointF(0, buttonRectangle.Location.Y + step);
                this.Refresh();
            }
            else
            {
                timer.Stop();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Main main = (Main)Parent.Parent;
            if (!active)
            {
                main.deactivateAll();
                active = true;
                main.pressedAny = true;
                timer.Start();
            }
            else
            {
                if (!main.pressedAny)
                    //this.colorPick.colorPickReset();
                active = false;
                timer.Start();
            }
            this.Refresh();
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            timer = new Timer();
            // Hook up the Elapsed event for the timer. 
            timer.Interval = 10;
            timer.Tick += new EventHandler(ToggleSwitch_ButtonTimer);
            //timer.Start();
        }

        // Draw a rectangle in the indicated Rectangle
        // rounding the indicated corners.
        private GraphicsPath MakeRoundedRect(
            RectangleF rect, float xradius, float yradius,
            bool round_ul, bool round_ur, bool round_lr, bool round_ll)
        {
            // Make a GraphicsPath to draw the rectangle.
            PointF point1, point2;
            GraphicsPath path = new GraphicsPath();

            // Upper left corner.
            if (round_ul)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 180, 90);
                point1 = new PointF(rect.X + xradius, rect.Y);
            }
            else point1 = new PointF(rect.X, rect.Y);

            // Top side.
            if (round_ur)
                point2 = new PointF(rect.Right - xradius, rect.Y);
            else
                point2 = new PointF(rect.Right, rect.Y);
            path.AddLine(point1, point2);

            // Upper right corner.
            if (round_ur)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius, rect.Y,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 270, 90);
                point1 = new PointF(rect.Right, rect.Y + yradius);
            }
            else point1 = new PointF(rect.Right, rect.Y);

            // Right side.
            if (round_lr)
                point2 = new PointF(rect.Right, rect.Bottom - yradius);
            else
                point2 = new PointF(rect.Right, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower right corner.
            if (round_lr)
            {
                RectangleF corner = new RectangleF(
                    rect.Right - 2 * xradius,
                    rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 0, 90);
                point1 = new PointF(rect.Right - xradius, rect.Bottom);
            }
            else point1 = new PointF(rect.Right, rect.Bottom);

            // Bottom side.
            if (round_ll)
                point2 = new PointF(rect.X + xradius, rect.Bottom);
            else
                point2 = new PointF(rect.X, rect.Bottom);
            path.AddLine(point1, point2);

            // Lower left corner.
            if (round_ll)
            {
                RectangleF corner = new RectangleF(
                    rect.X, rect.Bottom - 2 * yradius,
                    2 * xradius, 2 * yradius);
                path.AddArc(corner, 90, 90);
                point1 = new PointF(rect.X, rect.Bottom - yradius);
            }
            else point1 = new PointF(rect.X, rect.Bottom);

            // Left side.
            if (round_ul)
                point2 = new PointF(rect.X, rect.Y + yradius);
            else
                point2 = new PointF(rect.X, rect.Y);
            path.AddLine(point1, point2);

            // Join with the start point.
            path.CloseFigure();

            return path;
        }

        public Boolean isActive() { return active; }
        public void deactivateSwitch() { active = false; timer.Start(); this.Refresh(); }
        public void ToggleSwitchText(String str) { SwitchLabel.Text = str; }
        public String ToggleSwitchText() { return SwitchLabel.Text; }
        public void RefreshLabel() { SwitchLabel.Refresh(); }
    }
}
