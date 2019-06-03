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

        private Default_Property default_Property;

        
        internal ColorPick colorPicker;

        public PropertyPanelController(PropertyPanel property_panel)
        {
            default_Property = new Default_Property(property_panel);
            colorPicker = default_Property.ColorPicker;
            Console.WriteLine(property_panel);
        }

        /* Allows to change the property panel of which button active */
        public void SetPropertyPanel(object sender)
        {
            UserController button = (UserController)sender;

            /* Default Property */
            if (button.controlType is null)
                default_Property.Activate(); //TODO: fix the fast button activity bug

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
    }
}
