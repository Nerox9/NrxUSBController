using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using NeroxUSBController.Manager;
using NeroxUSBController.Panel.Property;
using System.Drawing.Drawing2D;

namespace NeroxUSBController.Controller.Graphic
{

    public class ChooseButton : UserController
    {
        private SolidBrush borderBrush, activeBorderBrush, passiveBorderBrush, textBrush;
        private Rectangle borderRectangle;
        private bool active = false;
        private bool pressed = false;
        private bool selected = false;
        private StringFormat stringFormat = new StringFormat();
        private Color backColor;
        private Image Icon;

        public override Cursor Cursor { get; set; } = Cursors.Hand;
        [Description("Sets the Border Thickness"), Category("Button Appearance"), DefaultValue(2), Browsable(true)]
        public float BorderThickness { get; set; } = 4;
        [Description("Sets the Border Color"), Category("Button Appearance"), DefaultValue(0), Browsable(true)]
        public Color passiveBorderColor { get; set; } = Color.Red;
        [Description("Sets the Active Border Color"), Category("Button Appearance"), DefaultValue(0), Browsable(true)]
        public Color activeBorderColor { get; set; } = Color.Blue;
        [Description("Sets the Active Border Color"), Category("Button Appearance"), DefaultValue(0), Browsable(true)]
        public Color textColor { get; set; } = Color.White;

        SolidBrush foreBrush = new SolidBrush(DefaultForeColor);
        Pen pathPen;

        public ChooseButton()
        {
            borderBrush = new SolidBrush(passiveBorderColor);
            passiveBorderBrush = new SolidBrush(passiveBorderColor);
            activeBorderBrush = new SolidBrush(activeBorderColor);
            textBrush = new SolidBrush(textColor);
            pathPen = new Pen(borderBrush, BorderThickness);

            text = "Button";

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            Size = new Size(95, 80);
            ActiveColor = Color.White;
            Margin = new Padding(5);

            this.AllowDrop = true;
            this.DoubleBuffered = true;

            this.DragEnter += chooseButton_DragEnter;
            this.DragDrop += dragDrop;
            this.Click += OnMouseClick;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            base.BackColor = Color.FromArgb(34,34,34); // active ? ActiveColor : PassiveColor;
            ForeColor = active ? ActiveColor : PassiveColor;
            borderBrush = selected ? activeBorderBrush : passiveBorderBrush;

            foreBrush.Color = ForeColor;
            pathPen.Brush = borderBrush;

            borderRectangle = new Rectangle(0, 0, Width - 1, Height - 1);
            //e.Graphics.DrawRectangle(new Pen(borderBrush, BorderThickness), borderRectangle);
            GraphicsPath slotPath = MakeRoundedRect(borderRectangle, Width / 6, Height / 6, true, true, true, true);
            GraphicsPath buttonPath = MakeRoundedRect(borderRectangle, Width / 6, Height / 6, true, true, true, true);

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            e.Graphics.FillPath(foreBrush, buttonPath);
            e.Graphics.DrawPath(pathPen, slotPath);
            e.Graphics.DrawString(text, this.Font, (active) ? textBrush : borderBrush, borderRectangle, stringFormat);

            if (Icon != null)
                e.Graphics.DrawImage(Icon, 24, 16, 48, 48);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!pressed)
                backColor = base.BackColor;
            base.OnMouseDown(e);
            //base.BackColor = pushColor;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if(e.Button.Equals(MouseButtons.Left))
            {
                if (!selected)
                {
                    //base.BackColor = ActiveColor;
                    PropertyPanelManager.SetPropertyPanel(property);
                    UserControllerManager.Select(this);
                    PropertyPanelManager.SetPropertyName();
                }
                else
                {
                    Deselect();
                    PropertyPanelManager.DeselectPropertyPanel();
                }
            }
            else if(e.Button.Equals(MouseButtons.Right))
            {
                Switch();
            }
            
        }

        public MouseEventHandler GetOnMouseClick()
        {
            return OnMouseClick;
        }

        /*
        protected override void OnMouseClick(object sender, EventArgs e)
        {
            // isActive gives previous status
            if (this.isActive())
            {
                if (sender is ColorPicker)
                {
                    this.BackColor = UserControllerManager.ActiveColor;
                    this.ActiveColor = UserControllerManager.ActiveColor;
                }
            }
            else if (this.isClicked())
            {
                if (sender is ChooseButton)
                {
                    ChooseButton button = (ChooseButton)sender;
                    UserControllerManager.Select(this);
                    //main.pressedAny = false;
                    //UserControllerManager.ActiveColor = ActiveColor;
                }
            }
        }
        */

        private void chooseButton_DragEnter(object sender, DragEventArgs e)
        {
            TreeNode node = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            TagProperties tag = (TagProperties)node.Tag;
            Type propertyType = (Type)tag.PropertyType;
            System.Reflection.MethodInfo info = propertyType.GetMethod("ButtonHandler");


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
            TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
            TagProperties tag = (TagProperties)node.Tag;
            base.dragDrop(sender, e);
            Icon = tag.Icon;
            Refresh();
        }

        public override void Select()
        {
            selected = true;
            Refresh();
        }

        public override void Deselect()
        {
            // TODO: take it to deactivate: base.BackColor = PassiveColor;
            if(selected)
            {
                base.Deselect();
                UserControllerManager.ResetColorPicker();
                selected = false;
            }
            
            Refresh();
        }

        public void Switch()
        {
            Activate(!active);
        }

        public override void Activate(bool activate)
        {
            active = activate;
            Refresh();

            if (property != null)
                property.ButtonHandler(active);
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
    }
}
