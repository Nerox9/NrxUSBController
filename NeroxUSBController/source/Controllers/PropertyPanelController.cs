using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController
{
    class PropertyPanelController
    {
        private Panel property_panel;
        private Panel active_panel;
        private Main main;

        private Default_Property default_Property;

        private Label property_panel_msg;

        public PropertyPanelController(Main main_panel, Panel property_panel)
        {
            main = main_panel;
            //property_panel = panel;
            Console.WriteLine(property_panel);

            // 
            // property_panel_msg
            // 
            this.property_panel_msg = new System.Windows.Forms.Label();
            this.property_panel_msg.AutoSize = true;
            this.property_panel_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.property_panel_msg.ForeColor = System.Drawing.Color.DimGray;
            this.property_panel_msg.Location = new System.Drawing.Point(88, 81);
            this.property_panel_msg.Name = "property_panel_msg";
            this.property_panel_msg.Size = new System.Drawing.Size(303, 17);
            this.property_panel_msg.TabIndex = 0;
            this.property_panel_msg.Text = "Drag an item or choose a switch, button or pot.";
            this.property_panel_msg.Visible = true;

            default_Property = new Default_Property(property_panel);

        }

        /* Allows to change the property panel of which button active */
        public void SetPropertyPanel(object sender)
        {
            UserController button = (UserController)sender;

            /* Default Property */
            if (button.controlType is null)
                //default_Property.Activate(); //TODO: fix the fast button activity bug

            /* Check that it is a controller property */
            if (button.controlType is Property)
            {
                Console.WriteLine("Controller Type: " + button.controlType);
            }
            else
                return;

            /*
            if (button.controlType is Obs_Screen)
            {
                // open obs property
            }

            if(button.controlType is Twitch_Property)
            {
                // open twitch property
            }
            */
        }


        /* Add all interfaces to property panel control */
        public void SetControllers(Panel property_panel)
        {
            property_panel.Controls.Add(property_panel_msg);
            //this.default_Property.SetControllers(property_panel);
        }

        public class Default_Property : Property
        {
            public Default_Property(Panel propertyPanel) : base(propertyPanel)
            {
                
            }
        }
    }
}
