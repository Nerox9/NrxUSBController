using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeroxUSBController.Property.SystemAudio
{
    class SystemAudioMuteProperty : SystemAudioProperty
    {
        public override void SwitchHandler(bool value)
        {
            if (selectedApp != null)
                selectedApp.Mute(value);
        }

        public override void ButtonHandler(bool value)
        {
            if (selectedApp != null)
                selectedApp.Mute(value);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // applications
            // 
            this.applications.Location = new System.Drawing.Point(232, 80);
            // 
            // devices
            // 
            this.devices.Location = new System.Drawing.Point(8, 80);
            // 
            // SystemAudioMuteProperty
            // 
            this.Name = "SystemAudioMuteProperty";
            this.Size = new System.Drawing.Size(600, 272);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
