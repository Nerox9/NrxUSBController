using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeroxUSBController.Property.SystemAudio
{
    class SystemAudioVolumeProperty : SystemAudioProperty
    {

        public override void PotHandler(float value)
        {
            if (base.selectedApp != null)
                base.selectedApp.SetVolume(value);
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
            // SystemAudioVolumeProperty
            // 
            this.Name = "SystemAudioVolumeProperty";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
