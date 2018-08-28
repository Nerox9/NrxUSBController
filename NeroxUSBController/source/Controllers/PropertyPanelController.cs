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
        //internal Obs_Property obs_Property = new Obs_Property();
        //internal Twitch_Property twitch_Property = new Twitch_Property();

        public PropertyPanelController(Main main_panel, Panel panel)
        {
            main = main_panel;
            property_panel = panel;
            Console.WriteLine(property_panel);
        }

        public void SetPropertyPanel(object sender)
        {
            UserController button = (UserController)sender;

            if (button.controlType is null)
                return;


            if (button.controlType is ControllerProperty)
            {
                Console.WriteLine(button.controlType);
                
                //twitch_Chat_Message.Activate();


            }
            else
                ;
        }
    }
}
