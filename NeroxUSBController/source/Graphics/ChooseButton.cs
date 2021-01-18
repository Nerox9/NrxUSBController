using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using NeroxUSBController.source.Manager;

namespace NeroxUSBController
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

        private ControllerProperty property;

        public override Cursor Cursor { get; set; } = Cursors.Hand;
        [Description("Sets the Border Thickness"), Category("Appearance"), DefaultValue(3), Browsable(true)]
        public float BorderThickness { get; set; }
        [Description("Sets the Border Color"), Category("Border Appearance"), DefaultValue(0), Browsable(true)]
        public Color passiveBorderColor = Color.Red;
        [Description("Sets the Active Border Color"), Category("Border Appearance"), DefaultValue(0), Browsable(true)]
        public Color activeBorderColor = Color.Blue;
        [Description("Sets the Active Border Color"), Category("Border Appearance"), DefaultValue(0), Browsable(true)]
        public Color textColor = Color.White;

        public ChooseButton()
        {
            borderBrush = new SolidBrush(passiveBorderColor);
            passiveBorderBrush = new SolidBrush(passiveBorderColor);
            activeBorderBrush = new SolidBrush(activeBorderColor);
            textBrush = new SolidBrush(textColor);

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            this.AllowDrop = true;
            this.DoubleBuffered = true;

            this.Paint += chooseButton_Paint;
            this.DragEnter += chooseButton_DragEnter;
            this.DragDrop += chooseButton_DragDrop;
            this.Click += OnMouseClick;
        }

        private void chooseButton_Paint(object sender, PaintEventArgs e)
        {
            base.BackColor = active ? ActiveColor : PassiveColor;
            borderBrush = selected ? activeBorderBrush : passiveBorderBrush;

            borderRectangle = new Rectangle(0, 0, Width, Height);
            e.Graphics.DrawRectangle(new Pen(borderBrush, BorderThickness), borderRectangle);
            e.Graphics.DrawString(this.Text, this.Font, (active) ? textBrush : borderBrush, borderRectangle, stringFormat);
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
            if (!selected)
            {
                base.OnMouseUp(e);
                base.BackColor = ActiveColor;
                selected = true;
                PropertyPanelManager.SetPropertyPanel(property);
                UserControllerManager.Select(this);
            }

            else
            {
                base.OnMouseUp(e);
                Deselect();
                UserControllerManager.DeactivateAll();
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
            Type propertyType = (Type)node.Tag;
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

        private void chooseButton_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode node = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            
            PropertyPanelManager.SetPropertyPanel(node.Tag);
            property = (ControllerProperty)node.Tag;
            UserControllerManager.Select(this);

            Console.WriteLine(node);
            //Console.WriteLine(sender);
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

        public Boolean isActive() { return pressed; }
        public Boolean isClicked() { return active; }
        public override void Activate() {  }
        public void activateButton() { if (!pressed) { OnMouseUp(new MouseEventArgs(Control.MouseButtons, 0, 0, 0, 0)); } }
        public override void Deactivate() { if (pressed) { OnMouseUp(new MouseEventArgs(Control.MouseButtons, 0, 0, 0, 0)); } }
    }
}
