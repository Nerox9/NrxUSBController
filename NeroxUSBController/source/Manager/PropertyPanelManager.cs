using NeroxUSBController.Controller;
using NeroxUSBController.Panel.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController.Manager
{
    static class PropertyPanelManager
    {
        static private System.Windows.Forms.Panel propertyPanel;
        static private ControllerProperty activeProperty;
        //internal Obs_Property obs_Property = new Obs_Property();
        //internal Twitch_Property twitch_Property = new Twitch_Property();
        static internal Default_Property defaultProperty;

        //static private Label property_panel_msg;
        
        static PropertyPanelManager()
        {
            defaultProperty = new Default_Property();
        }

        /* Allows to change the property panel of which button active */
        static public void SetPropertyPanel(object sender)
        {
            if (activeProperty != null)
                activeProperty.Hide();

            if(sender == null)
            {
                defaultProperty.SetParents(propertyPanel);
                defaultProperty.Show();
                activeProperty = defaultProperty;
                return;
            }

            ControllerProperty property = (ControllerProperty)sender;
            property.SetParents(propertyPanel);
            property.Show();
            activeProperty = property;
        }
        
        static public void DeselectPropertyPanel()
        {
            if (activeProperty != null)
            {
                activeProperty.Hide();
                activeProperty = null;
            }
        }

        static public void SetPropertyName()
        {
            if(activeProperty is Default_Property)
            {
                Default_Property property = (Default_Property)activeProperty;
                property.SetName(UserControllerManager.GetActive().text);
            }
        }


        /* Add all interfaces to property panel control */
        static public void SetPropertyPanel(System.Windows.Forms.Panel property_panel)
        {
            propertyPanel = property_panel;
        }
    }
}
