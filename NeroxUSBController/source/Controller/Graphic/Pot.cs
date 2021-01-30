using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using NeroxUSBController.Manager;
using NeroxUSBController.Panel.Property;

namespace NeroxUSBController.Controller.Graphic
{
    class Pot : UserController
    {
        [Description("Stator Image"), Category("Pot Appearance"), DefaultValue(0), Browsable(true)]
        public Image Stator { get; set; } = Properties.Resources.pot_base;
        [Description("Rotor Image"), Category("Pot Appearance"), DefaultValue(0), Browsable(true)]
        public Image Rotor { get; set; } = Properties.Resources.pot_head;
        [Description("Rotor Glowing Image"), Category("Pot Appearance"), DefaultValue(0), Browsable(true)]
        public Image RotorGlow { get; set; } = Properties.Resources.pot_head_indicator;
        [Description("Rotor Low Angle Limit"), Category("Pot Appearance"), DefaultValue(-135), Browsable(true)]
        public int LowLimit { get; set; } = -135;
        [Description("Rotor High Angle Limit"), Category("Pot Appearance"), DefaultValue(135), Browsable(true)]
        public int HighLimit { get; set; } = 135;
        [Description("Selected Color"), Category("Pot Appearance"), DefaultValue(0), Browsable(true)]
        public Color SelectColor { get; set; } = Color.Blue;

        private Boolean active = false;
        private Boolean selected = false;
        private int RotAngle = 0;
        private Pen selectPen;

        public Pot()
        {
            InitializeComponent();
            this.Size = new Size(75,75);
            this.Margin = new Padding(25);
            this.DoubleBuffered = true;
            selectPen = new Pen(SelectColor, 2);
        }

        private void paint(object sender, PaintEventArgs e)
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

            if (selected)
            {
                SmoothingMode mode = e.Graphics.SmoothingMode;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.DrawEllipse(selectPen, 9, 9, Width - 18, Height - 18);
                e.Graphics.SmoothingMode = mode;
            }
        }

        private void Switch()
        {
            active = !active;
        }

        private void Rotate(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                int temp_angle = -e.Y;
                if ((HighLimit >= temp_angle) && (temp_angle >= LowLimit))
                {
                    RotAngle = temp_angle;
                    this.Refresh();
                }

                // TODO: check low value does not exceed to 0 sometimes
                float normal = AngleNormalized(RotAngle);
                
                if(property != null)
                    property.PotHandler(normal);
            }
        }

        private void LeftClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                if(selected)
                {
                    PropertyPanelManager.DeselectPropertyPanel();
                    selected = false;
                    Refresh();
                }
                else
                {
                    PropertyPanelManager.SetPropertyPanel(property);
                    UserControllerManager.Select(this);
                    PropertyPanelManager.SetPropertyName();
                    selected = true;
                    Refresh();
                }
                
            }
        }

        private float AngleNormalized(int angle)
        {
            float normalAngle = ((float)angle - (float)LowLimit) / ((float)HighLimit - (float)LowLimit);
            return normalAngle;
        }

        protected override void dragDrop(object sender, DragEventArgs e)
        {
            active = true;
            selected = true;
            base.dragDrop(sender, e);
        }

        private void Pot_DragEnter(object sender, DragEventArgs e)
        {
            TreeNode node = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            TagProperties tag = (TagProperties)node.Tag;
            Type propertyType = (Type)tag.PropertyType;
            System.Reflection.MethodInfo info = propertyType.GetMethod("PotHandler");


            if (info != null && info.DeclaringType != typeof(ControllerProperty))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        public override void Select()
        {
            selected = true;
            Refresh();
        }

        public override void Deselect()
        {
            selected = false;
            Refresh();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Pot
            // 
            this.AllowDrop = true;
            this.Name = "Pot";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Pot_DragEnter);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LeftClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Rotate);
            this.ResumeLayout(false);

        }
    }
}