using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace NeroxUSBController
{
    public class Default_Property : Property
    {
        private Label property_panel_msg;

        public Default_Property(PropertyPanel propertyPanel) : base(propertyPanel)
        {
            this.SetPropertyPanel(propertyPanel);
            // 
            // property_panel_msg
            // 
            this.property_panel_msg = new Label();
            this.property_panel_msg.AutoSize = true;
            this.property_panel_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.property_panel_msg.ForeColor = System.Drawing.Color.DimGray;
            this.property_panel_msg.Location = new System.Drawing.Point(88, 81);
            this.property_panel_msg.Name = "property_panel_msg";
            this.property_panel_msg.Size = new System.Drawing.Size(303, 17);
            this.property_panel_msg.TabIndex = 0;
            this.property_panel_msg.Text = "Drag an item or choose a switch, button or pot.";
            this.property_panel_msg.Visible = true;
        }

        /* Add all interfaces to property panel control */
        public void SetControllers(Panel property_panel)
        {
            property_panel.Controls.Add(property_panel_msg);
            //this.default_Property.SetControllers(property_panel);
        }

        public void Switch()
        {
            if (this.isActive)
            {
                this.ColorPicker.Visible = false;
                //this.NameTextBox.Visible = false;
            }
            else
            {
                this.ColorPicker.Visible = true;
                //this.NameTextBox.Visible = true;
            }

            this.isActive = !this.isActive;
        }
    }
}

