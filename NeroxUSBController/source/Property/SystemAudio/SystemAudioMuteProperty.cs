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
    }
}
