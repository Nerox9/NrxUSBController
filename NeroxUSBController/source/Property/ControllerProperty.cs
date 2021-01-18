using NeroxUSBController.source.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController
{
    public class ControllerProperty : UserControl
    {
        public bool isSelected = false;
        protected Panel propertyPanel;
        protected ColorPicker ColorPicker;

        public ControllerProperty()
        {
            InitializeComponent();
        }

        public void Hide()
        {
            Visible = false;
            Refresh();
        }

        public void Show()
        {
            Visible = true;
            Dock = DockStyle.Fill;
            Refresh();
        }

        public virtual void PotHandler(float value)
        {

        }

        public virtual void SwitchHandler(bool value)
        {

        }

        public virtual void ButtonHandler(bool value)
        {

        }

        public void SetParents(Panel property_panel)
        {
            this.propertyPanel = property_panel;
            this.Parent = propertyPanel;
            UserControllerManager.SetColorPicker(ColorPicker);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ControllerProperty
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Name = "ControllerProperty";
            this.Size = new System.Drawing.Size(800, 330);
            this.ResumeLayout(false);

        }
    }
}
