using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace NeroxUSBController
{
    public class Settings : Panel
    {
        public Settings()
        {
        }

        public void setPanel(Panel buttonPanel, Panel propertyPanel)
        {
            this.Location = buttonPanel.Location;
            //this.Size = new Size(buttonPanel.Size.Width, buttonPanel.Size.Height + propertyPanel.Size.Height);
            this.BackColor = buttonPanel.BackColor;
            this.Visible = false;
        }
    }

    public class SettingsSide : Panel
    {
        public SettingsSide()
        {
        }

        public void setPanel(Panel sidePanel)
        {
            this.Location = sidePanel.Location;
            this.Size = sidePanel.Size;
            this.BackColor = sidePanel.BackColor;
            this.Visible = false;
        }
    }
}
