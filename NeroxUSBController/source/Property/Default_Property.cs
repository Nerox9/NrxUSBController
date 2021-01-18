using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using NeroxUSBController.source.Manager;

namespace NeroxUSBController
{
    class Default_Property : ControllerProperty
    {
        public Default_Property()
        {
            InitializeComponent();
        }

        public ColorPicker GetColorPicker()
        {
            return ColorPicker;
        }

        private void InitializeComponent()
        {
            this.ColorPicker = new NeroxUSBController.ColorPicker();
            this.SuspendLayout();
            // 
            // ColorPicker
            // 
            this.ColorPicker.AutoSize = true;
            this.ColorPicker.Location = new System.Drawing.Point(21, 100);
            this.ColorPicker.Name = "ColorPicker";
            this.ColorPicker.Size = new System.Drawing.Size(90, 90);
            this.ColorPicker.TabIndex = 0;
            // 
            // Default_Property
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.ColorPicker);
            this.Name = "Default_Property";
            this.Size = new System.Drawing.Size(929, 363);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

