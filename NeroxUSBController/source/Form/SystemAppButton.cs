using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using NeroxUSBController.Manager;

namespace NeroxUSBController.Form
{
    class SystemAppButton : Control
    {
        [Description("Button Image"), Category("Appearance"), DefaultValue(0), Browsable(true)]
        public Image ButtonImage { get; set; }

        [Description("Pressed Button Image"), Category("Appearance"), DefaultValue(0), Browsable(true)]
        public Image PressedButtonImage { get; set; }

        [Description("Escape Button Boolean"), Category("Behavior"), DefaultValue(false), Browsable(true)]
        public Boolean isEscButton { get; set; }

        private Boolean active;

        public SystemAppButton()
        {
            this.Paint += SystemButton_Paint;
            this.MouseDown += SystemButton_MouseDown;
            this.MouseUp += SystemButton_MouseUp;
        }

        private void SystemButton_Paint(object sender, PaintEventArgs e)
        {
            if (active)
                e.Graphics.DrawImage(PressedButtonImage, new RectangleF(0, 0, 20, 20));
            else
                e.Graphics.DrawImage(ButtonImage, new RectangleF(0, 0, 20, 20));
        }

        protected void SystemButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isEscButton && active)
                active = false;
            else
                active = true;
            this.Refresh();
        }

        protected void SystemButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (isEscButton && (this.Width > e.Location.X) && (e.Location.X > 0) && (this.Height > e.Location.Y) && (e.Location.Y > 0))
                Application.Exit();
            else if (isEscButton)
                active = false;
            else if (!isEscButton)
            {
                if (PanelManager.GetPanelSet() == PanelManager.PanelSet.Controller)
                    PanelManager.SetPanelSet(PanelManager.PanelSet.Settings);
                else if (PanelManager.GetPanelSet() == PanelManager.PanelSet.Settings)
                    PanelManager.SetPanelSet(PanelManager.PanelSet.Controller);
            }
            this.Refresh();
        }
    }
}
