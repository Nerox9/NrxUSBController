using NeroxUSBController.Controller.Graphic;
using NeroxUSBController.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController.Panel.Property
{
    public class ControllerProperty : UserControl
    {
        public bool isSelected = false;
        protected System.Windows.Forms.Panel propertyPanel;
        protected Label PropertyName;
        private Controller.PropertyControlText propertyControlText;
        protected ColorPicker ColorPicker;

        public ControllerProperty()
        {
            InitializeComponent();
            Size = new System.Drawing.Size(600, 180);
        }

        public void SetPropertyName(string name)
        {
            PropertyName.Text = name;
        }

        public void SetName(string name)
        {
            propertyControlText.Text = name;
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

        public virtual void SetParents(System.Windows.Forms.Panel property_panel)
        {
            this.propertyPanel = property_panel;
            this.Parent = propertyPanel;
            UserControllerManager.SetColorPicker(ColorPicker);
        }

        private void InitializeComponent()
        {
            this.PropertyName = new System.Windows.Forms.Label();
            this.propertyControlText = new NeroxUSBController.Controller.PropertyControlText();
            this.SuspendLayout();
            // 
            // PropertyName
            // 
            this.PropertyName.AutoSize = true;
            this.PropertyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.PropertyName.ForeColor = System.Drawing.Color.Maroon;
            this.PropertyName.Location = new System.Drawing.Point(5, 5);
            this.PropertyName.Margin = new System.Windows.Forms.Padding(5);
            this.PropertyName.Name = "PropertyName";
            this.PropertyName.Size = new System.Drawing.Size(112, 16);
            this.PropertyName.TabIndex = 4;
            this.PropertyName.Text = "Property Name";
            // 
            // propertyControlText
            // 
            this.propertyControlText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.propertyControlText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propertyControlText.Location = new System.Drawing.Point(8, 29);
            this.propertyControlText.Name = "propertyControlText";
            this.propertyControlText.Size = new System.Drawing.Size(175, 20);
            this.propertyControlText.TabIndex = 5;
            // 
            // ControllerProperty
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.propertyControlText);
            this.Controls.Add(this.PropertyName);
            this.Name = "ControllerProperty";
            this.Size = new System.Drawing.Size(600, 181);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
