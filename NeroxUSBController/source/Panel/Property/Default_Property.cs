using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using NeroxUSBController.Controller.Graphic;
using NeroxUSBController.Manager;

namespace NeroxUSBController.Panel.Property
{
    class Default_Property : ControllerProperty
    {
        private new ColorPicker ColorPicker;
        public Default_Property()
        {
            InitializeComponent();
            base.ColorPicker = ColorPicker;

            SetPropertyName("Set Controller Color");
        }

        private void InitializeComponent()
        {
            this.ColorPicker = new NeroxUSBController.Controller.Graphic.ColorPicker();
            this.SuspendLayout();
            // 
            // ColorPicker
            // 
            this.ColorPicker.AutoSize = true;
            this.ColorPicker.Location = new System.Drawing.Point(500, 81);
            this.ColorPicker.Margin = new System.Windows.Forms.Padding(25);
            this.ColorPicker.Name = "ColorPicker";
            this.ColorPicker.Size = new System.Drawing.Size(75, 75);
            this.ColorPicker.TabIndex = 0;
            // 
            // Default_Property
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.ColorPicker);
            this.Name = "Default_Property";
            this.Size = new System.Drawing.Size(600, 181);
            this.Controls.SetChildIndex(this.ColorPicker, 0);
            this.Controls.SetChildIndex(this.PropertyName, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

