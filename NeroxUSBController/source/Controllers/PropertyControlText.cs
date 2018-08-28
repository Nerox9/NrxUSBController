using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController
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
            Main main = (Main)Parent.Parent;

            if (main.ActiveSelection is ChooseButton)
            {
                ChooseButton button = (ChooseButton)main.ActiveSelection;
                if (!(button is null))
                {
                    button.Text = this.Text;
                    button.Refresh();
                }
            }
            else if (main.ActiveSelection is ToggleSwitch)
            {
                ToggleSwitch toggleSwitch = (ToggleSwitch)main.ActiveSelection;
                if (!(toggleSwitch is null))
                {
                    toggleSwitch.ToggleSwitchText(this.Text);
                    toggleSwitch.RefreshLabel();
                }
            }
        }

        public void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Main main = (Main)Parent.Parent;
                if (main.ActiveSelection is ChooseButton)
                {
                    ChooseButton button = (ChooseButton)main.ActiveSelection;
                    if (!(button is null))
                        button.Text = this.Text;
                    main.ActiveControl = Parent;
                    e.Handled = true;
                    button.Refresh();   // Refresh print of button
                }
                else if (main.ActiveSelection is ToggleSwitch)
                {
                    ToggleSwitch toggleSwitch = (ToggleSwitch)main.ActiveSelection;
                    if (!(toggleSwitch is null))
                        toggleSwitch.ToggleSwitchText(this.Text);
                    main.ActiveControl = Parent;
                    e.Handled = true;
                    toggleSwitch.RefreshLabel();   // Refresh print of button
                }
            }
        }
    }
}
