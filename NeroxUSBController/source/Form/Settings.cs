using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using NeroxUSBController.Controller.Graphic;

namespace NeroxUSBController.Form
{
    public class Settings : System.Windows.Forms.Panel
    {
        public Settings()
        {
        }
    }

    public class SettingsSide : System.Windows.Forms.Panel
    {
        private AppTreeView treeView;

        public SettingsSide()
        {
        }

        public void setPanel(System.Windows.Forms.Panel sidePanel)
        {
            this.Location = sidePanel.Location;
            this.Size = sidePanel.Size;
            this.BackColor = sidePanel.BackColor;
            this.Visible = false;
        }
    }

    internal class Account
    {
        private string username;
        private string password;
        private string accessToken;
        private string token;
        public Account()
        {

        }
    }
}
