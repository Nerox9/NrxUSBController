using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using NeroxUSBController.Manager;
using NeroxUSBController.Panel.Property;

namespace NeroxUSBController.Controller.Graphic
{
    public class ToggleSwitch : UserController
    {
        public Color PassiveColor { get { return Color.FromArgb(ActiveColor.R / 6, ActiveColor.G / 6, ActiveColor.B / 6); } }
        [Description("Toggle Switch Button Color"), Category("Switch Appearance"), DefaultValue(0), Browsable(true)]
        public Color ButtonColor { get; set; } = Color.Gray;
        [Description("Toggle Switch Label"), Category("Switch Appearance"), DefaultValue("Toggle Switch"), Browsable(true)]
        public String SwitchText { get; set; }
        [Description("Toggle Switch Label Color"), Category("Switch Appearance"), DefaultValue(0), Browsable(true)]
        public Color SwitchLabelColor { get; set; } = Color.Red;
        [Description("Selected Color"), Category("Switch Appearance"), DefaultValue(0), Browsable(true)]
        public Color SelectColor { get; set; } = Color.Blue;

        private Boolean active = false;
        private Boolean selected = false;
        private Point activePoint;
        private Point passivePoint;
        private RectangleF buttonRectangle;
        private Timer timer;
        private PointF buttonPosition;
        private StringFormat stringFormat = new StringFormat();
        private Label SwitchLabel;
        private Pen selectPen;
        private Pen counterPen;

        public ToggleSwitch()
        {
            InitializeComponent();
            Size = new Size(26, 43);
            Margin = new Padding(25);
            Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, (byte)162);
            Text = "On";

            Height = 45;
            Width = 28;

            /*
            SwitchLabel = new Label();
            Controls.Add(this.SwitchLabel);
            SwitchLabel.Text = SwitchText;
            SwitchLabel.ForeColor = SwitchLabelColor;
            SwitchLabel.Size = new Size(25, 25);

            SwitchLabel.Location = new Point(Location.X, Location.Y - 15);
            SwitchLabel.Name = "SwitchLabel";
            SwitchLabel.TabIndex = 9;
            SwitchLabel.Text = "Sw";
            SwitchLabel.TextAlign = ContentAlignment.MiddleCenter;
            */

            SetTimer();

            DoubleBuffered = true;
            Click += OnMouseClick;
            DragDrop += dragDrop;

            passivePoint = new Point(0, 18);
            activePoint = new Point(0, 0);
            buttonPosition = passivePoint;
            selectPen = new Pen(SelectColor, 2);
            counterPen = new Pen(SwitchLabelColor, 1);

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            BackColor = Parent.BackColor;

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            /*
            Color tempPassiveColor = PassiveColor;
            float brightness = PassiveColor.GetBrightness();
            if (brightness <= 0.160f)
            {

                float lighter = 0.160f / brightness;
                tempPassiveColor = Color.FromArgb((int)(tempPassiveColor.R * lighter), (int)(tempPassiveColor.G * lighter), (int)(tempPassiveColor.B * lighter));
            }
            */

            SolidBrush brush = new SolidBrush(active ? ActiveColor : PassiveColor);
            SolidBrush buttonBrush = new SolidBrush(ButtonColor);

            RectangleF slotRect = new RectangleF(0, 0, Width - 1, Height - 1);
            Rectangle buttonTextRectangle = new Rectangle(0, 0, Width - 2, Width - 2);

            buttonRectangle = new RectangleF(0, 1, Width - 2, Width - 2);
            buttonRectangle.Location = new PointF(buttonPosition.X, buttonPosition.Y);
            buttonTextRectangle.Location = new Point((int)buttonPosition.X, (int)buttonPosition.Y);

            GraphicsPath slotPath = MakeRoundedRect(slotRect, Width / 2, Height / 3, true, true, true, true);
            e.Graphics.FillPath(brush, slotPath);
            e.Graphics.FillEllipse(buttonBrush, buttonRectangle);
            e.Graphics.DrawPath(counterPen, slotPath);
            e.Graphics.DrawString(Text, Font, brush, buttonTextRectangle, stringFormat);

            if(selected)
            {
                SmoothingMode mode = e.Graphics.SmoothingMode;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.DrawEllipse(selectPen, buttonRectangle);
                e.Graphics.SmoothingMode = mode;
            }
        }

        /*
        protected override void OnMouseClick(object sender, EventArgs e)
        {
            // isActive gives previous status
            if (this.isActive())
            {
                UserControllerManager.Select(this);
                if (sender is ColorPicker)
                {
                    this.ActiveColor = this.colorPick.Forecolor();
                    this.Refresh();
                }
                else if (sender is ToggleSwitch)
                {
                    this.colorPick.Forecolor(this.ActiveColor);
                    main.pressedAny = false;
                }
            }
        }
        */

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
            if (e.Button.Equals(MouseButtons.Left))
            {
                if (selected)
                {
                    PropertyPanelManager.DeselectPropertyPanel();
                    selected = false;
                }
                else
                {
                    PropertyPanelManager.SetPropertyPanel(property);
                    UserControllerManager.Select(this);
                    PropertyPanelManager.SetPropertyName();
                    selected = true;
                }
                Refresh();
            }

            else if (e.Button.Equals(MouseButtons.Right))
            {
                Switch();
            }
        }

        private void ToggleSwitch_DragEnter(object sender, DragEventArgs e)
        {
            TreeNode node = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            TagProperties tag = (TagProperties)node.Tag;
            Type propertyType = (Type)tag.PropertyType;
            System.Reflection.MethodInfo info = propertyType.GetMethod("SwitchHandler");


            if (info != null && info.DeclaringType != typeof(ControllerProperty))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        protected override void dragDrop(object sender, DragEventArgs e)
        {
            base.dragDrop(sender, e);
        }

        public void Switch()
        {
            Activate(!active);

            /*
            if (!active)
            {
                if (property != null)
                    property.SwitchHandler(active);
                active = true;
                timer.Start();
            }
            else
            {
                if (property != null)
                    property.SwitchHandler(active);
                active = false;
                timer.Start();
            }
            this.Refresh();
            */
        }

        public override void Select()
        {
            base.Select();
            selected = true;
        }

        public override void Deselect()
        {
            selected = false;
            Refresh();
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

        public MouseEventHandler GetOnMouseClick()
        {
            return OnMouseClick;
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

        public override void Activate(bool activate)
        {
            active = activate;
            timer.Start();
            //Refresh();

            if (property != null)
                property.SwitchHandler(active);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ToggleSwitch
            // 
            this.AllowDrop = true;
            this.Name = "ToggleSwitch";
            this.Size = new System.Drawing.Size(33, 43);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.ToggleSwitch_DragEnter);
            this.ResumeLayout(false);

        }
    }
}
