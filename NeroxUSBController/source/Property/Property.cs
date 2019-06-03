using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController
{
    public class Property : Control
    {
        public ColorPick ColorPicker;
        internal PropertyControlText NameTextBox;
        public PropertyPanel property_panel { set; get; }

        public bool isActive = false;

        private System.Drawing.Point colorPickerPos = new System.Drawing.Point(370, 50);
        private System.Drawing.Size colorPickerSize = new System.Drawing.Size(75, 75);

        internal Property(PropertyPanel panel)
        {
            SetPropertyPanel(panel);
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

            //
            // Controls
            //
            this.property_panel.Controls.Add(this.ColorPicker);
            this.property_panel.Controls.Add(this.NameTextBox);
        }

        internal Property()
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

        internal void SetControls(PropertyPanel panel)
        {
            SetPropertyPanel(panel);
            //
            // Controls
            //
            this.property_panel.Controls.Add(this.ColorPicker);
            this.property_panel.Controls.Add(this.NameTextBox);
        }


        public void Activate()
        {
            this.ColorPicker.Visible = true;
            this.NameTextBox.Visible = true;
        }

        public void SetPropertyPanel(PropertyPanel propertyPanel)
        {
            this.property_panel = propertyPanel;
        }
    }
}
