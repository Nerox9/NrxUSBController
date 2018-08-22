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
        }

        public void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            Main main = (Main)Parent.Parent;
            ChooseButton button = (ChooseButton)main.ActiveButton;
            if (!(button is null))
            {
                button.Text = this.Text;
            }

        }

        public void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Main main = (Main)Parent.Parent;
                ChooseButton button = (ChooseButton)main.ActiveButton;
                if (!(button is null))
                    button.Text = this.Text;
                main.ActiveControl = Parent;
                e.Handled = true;
                button.Refresh();   // Refresh print of button
            }
        }
    }
}
