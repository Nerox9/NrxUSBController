using NeroxUSBController.Controller.Graphic;
using NeroxUSBController.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController.Controller
{
    class PropertyControlText : TextBox
    {
        public PropertyControlText()
        {
            this.KeyPress += NameTextBox_KeyPress;
            this.TextChanged += NameTextBox_TextChanged;
        }

        public void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            UserController activeController = UserControllerManager.GetActive();

            if (!(activeController is null))
            {
                activeController.text = this.Text;
                activeController.Refresh();
            }
            
        }

        public void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                UserController activeController = UserControllerManager.GetActive();
                if (activeController is ChooseButton)
                {
                    ChooseButton button = (ChooseButton)activeController;
                    if (!(button is null))
                        button.Text = this.Text;
                    e.Handled = true;
                    button.Refresh();   // Refresh print of button
                }
                else if (activeController is ToggleSwitch)
                {
                    ToggleSwitch toggleSwitch = (ToggleSwitch)activeController;
                    if (!(toggleSwitch is null))
                        toggleSwitch.SwitchText = Text;
                    e.Handled = true;
                    toggleSwitch.Refresh();   // Refresh print of button
                }
            }
        }
    }
}
