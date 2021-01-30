using NeroxUSBController.Controller.Graphic;
using NeroxUSBController.Manager;
using NeroxUSBController.Panel.Property;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController.Controller
{
    public class UserController : UserControl
    {
        [Description("Activated Color"), Category("Color Appearance"), DefaultValue(0), Browsable(true)]
        public Color ActiveColor { get; set; }
        public Color PassiveColor { get { return Color.FromArgb(ActiveColor.R / 2, ActiveColor.G / 2, ActiveColor.B / 2); } }
        [Description("Sets the Button Text"), Category("Misc"), DefaultValue("Controller"), Browsable(true)]
        public string text { get; set; }

        protected ControllerProperty property;

        public UserController()
        {

        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        protected virtual void OnMouseClick(object sender, EventArgs e)
        {
            
        }

        public virtual void Select()
        {

        }

        public virtual void Deselect()
        {

        }

        public virtual void Activate(bool active)
        {

        }

        protected virtual void dragDrop(object sender, DragEventArgs e)
        {
            TreeNode node = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            TagProperties properties = (TagProperties)node.Tag;
            property = (ControllerProperty)Activator.CreateInstance(properties.PropertyType);

            property.SetPropertyName(node.FullPath.Replace("\\", " - "));
            PropertyPanelManager.SetPropertyPanel(property);
            UserControllerManager.Select(this);
            PropertyPanelManager.SetPropertyName();
            Refresh();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UserController
            // 
            this.Name = "UserController";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.dragDrop);
            this.ResumeLayout(false);

        }
    }
}
