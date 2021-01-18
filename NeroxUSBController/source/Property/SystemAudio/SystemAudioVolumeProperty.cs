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
    }
}
