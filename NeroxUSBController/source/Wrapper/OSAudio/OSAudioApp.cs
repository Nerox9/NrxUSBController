using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeroxUSBController.Wrapper.OSAudio
{
    public class OSAudioApp
    {
        AudioSessionControl asc;
        AudioEndpointVolume aev;

        public AudioSessionState State;

        internal OSAudioApp(MMDevice device)
        {
            try
            {
                aev = device.AudioEndpointVolume;
            }
            catch(InvalidCastException)
            {
                Console.WriteLine("AudioEndpointVolume Error");
            }
            State = AudioSessionState.AudioSessionStateActive;
        }

        internal OSAudioApp(AudioSessionControl audioSessionControl)
        {
            asc = audioSessionControl;
            State = asc.State;
        }

        internal void SetVolume(float volume)
        {
            if (aev != null && asc == null)
                aev.MasterVolumeLevelScalar = volume;
            else if (aev == null && asc != null)
                asc.SimpleAudioVolume.Volume = volume;
        }

        internal void Mute(bool mute)
        {
            if (aev != null && asc == null)
                aev.Mute = mute;
            else if (aev == null && asc != null)
                asc.SimpleAudioVolume.Mute = mute;
        }

        public int GetProcessID()
        {
            if (asc != null)
                return (int)asc.GetProcessID;
            return -1;
        }

        internal string GetName()
        {
            if (aev != null)
                return "Master";

            if (asc.DisplayName.Contains("AudioSrv.Dll"))
            {
                return "System Sounds";
            }
            else if (asc.DisplayName.Contains("Master"))
            {
                return "Master";
            }
            else
            {
                Process process = Process.GetProcessById((int)asc.GetProcessID);
                return process.MainModule.FileVersionInfo.FileDescription;
            }
        }
    }
}
