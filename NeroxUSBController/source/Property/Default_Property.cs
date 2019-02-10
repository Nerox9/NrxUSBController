using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace NeroxUSBController
{
    class Default_Property : ControllerProperty
    {
        public ColorPick ColorPicker;
        public PropertyControlText NameTextBox;
        private Panel propertyPanel;

        public bool isActive = false;

        private System.Drawing.Point colorPickerPos = new System.Drawing.Point(370, 50);
        private System.Drawing.Size colorPickerSize = new System.Drawing.Size(75, 75);


        public Default_Property()
        {
            // 
            // colorPicker
            // 
            this.ColorPicker = new ColorPick();
            this.ColorPicker.buttonImage = global::NeroxUSBController.Properties.Resources.metal_gui_indicator;
            this.ColorPicker.Location = colorPickerPos;
            this.ColorPicker.Name = "colorPicker";
            this.ColorPicker.Size = colorPickerSize;
            this.ColorPicker.TabIndex = 2;
            this.ColorPicker.Text = "colorPicker";
            this.ColorPicker.Visible = false;

            // 
            // NameTextBox
            // 
            NameTextBox = new PropertyControlText();
            this.NameTextBox.BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
            this.NameTextBox.BorderStyle = BorderStyle.FixedSingle;
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.NameTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.NameTextBox.Location = new System.Drawing.Point(33, 50);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 1;
            this.NameTextBox.Visible = false;
        }

        public void SetControllers(Panel property_panel)
        {
            this.propertyPanel = property_panel;

            //
            // Controls
            //
            this.propertyPanel.Controls.Add(this.ColorPicker);
            this.propertyPanel.Controls.Add(this.NameTextBox);
        }

        public void Switch()
        {
            if (this.isActive)
            {
                this.ColorPicker.Visible = false;
                this.NameTextBox.Visible = false;
            }
            else
            {
                this.ColorPicker.Visible = true;
                this.NameTextBox.Visible = true;
            }

            this.isActive = !this.isActive;
        }
    }
}

