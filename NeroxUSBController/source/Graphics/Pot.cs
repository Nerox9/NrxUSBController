using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using NeroxUSBController.source.Manager;

namespace NeroxUSBController.Graphics
{
    class Pot : UserController
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

        private ControllerProperty property;
        private Boolean active = true;
        private int RotAngle = 0;

        public Pot()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
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

                // TODO: check low value does not exceed to 0 sometimes
                float normal = AngleNormalized(RotAngle);
                
                if(property != null)
                    property.PotHandler(normal);
            }
        }

        private float AngleNormalized(int angle)
        {
            float normalAngle = ((float)angle - (float)LowLimit) / ((float)HighLimit - (float)LowLimit);
            return normalAngle;
        }

        private void dragDrop(object sender, DragEventArgs e)
        {
            TreeNode node = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            property = (ControllerProperty)Activator.CreateInstance((Type)node.Tag);
            PropertyPanelManager.SetPropertyPanel(property);
            UserControllerManager.Select(this);

            Console.WriteLine(node);
            //Console.WriteLine(sender);
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
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Rotate);
            this.ResumeLayout(false);

        }

        private void Pot_DragEnter(object sender, DragEventArgs e)
        {
            TreeNode node = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            Type propertyType = (Type)node.Tag;
            System.Reflection.MethodInfo info = propertyType.GetMethod("PotHandler");


            if (info != null && info.DeclaringType != typeof(ControllerProperty))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}