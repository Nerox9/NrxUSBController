using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections.Concurrent;
using NAudio.CoreAudioApi;
using NAudio.Mixer;
using NAudio.Wave;
using System.Diagnostics;
using NAudio.CoreAudioApi.Interfaces;

namespace NeroxUSBController.Wrapper.OSAudio
{
    class OSAudio
    {
        MMDevice device;
        OSAudioApp application;
        OSAudioApp master;

        public void SetMasterVolume(float volume)
        {
            try
            {
                device.AudioEndpointVolume.MasterVolumeLevelScalar = volume;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Could not set the volume of this device. Select an available device.");
            }
        }

        public void MasterMute(bool mute)
        {
            try
            {
                device.AudioEndpointVolume.Mute = mute;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Could not mute this device. Select an available device.");
            }
        }

        public List<string> GetAppNames()
        {
            return GetApps().Select(app => app.GetName()).ToList();
        }

        public Dictionary<string, OSAudioApp> GetAppDictionary()
        {
            return GetApps().ToDictionary(a => a.GetName());
        }

        public List<OSAudioApp> GetApps()
        {
            List<OSAudioApp> apps = new List<OSAudioApp>();
            List<int> pids = new List<int>();

            apps.Add(master);

            for (int i = 0; i < device.AudioSessionManager.Sessions.Count; i++)
            {
                OSAudioApp app = new OSAudioApp(device.AudioSessionManager.Sessions[i]);
                int pid = app.GetProcessID();
                if (!pids.Contains(pid) && app.State != AudioSessionState.AudioSessionStateExpired)
                { 
                    apps.Add(app);
                    pids.Add(pid);
                }
            }

            return apps;
        }

        public void SetApp(int app)
        {
            application = GetApps()[app];
        }

        public void SetDevice(MMDevice dev)
        {
            device = dev;
            SetMasterApp();
        }

        public void SetDevice(int dev)
        {
            device = GetDevices()[dev];
            SetMasterApp();
        }

        public Dictionary<string, MMDevice> GetDeviceNames()
        {
            return GetDevices().ToDictionary(d => d.FriendlyName, d => d);
        }

        public List<string> GetDeviceNamesandIDs()
        {
            return GetDevices().Select(d => d.FriendlyName).ToList();
        }

        MMDevice[] GetDevices()
        {
            return GetDeviceCollection().ToArray();
        }

        MMDeviceCollection GetDeviceCollection()
        {
            MMDeviceEnumerator MMDE = new MMDeviceEnumerator();
            MMDeviceCollection deviceCollection = MMDE.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            return deviceCollection;
        }

        OSAudioApp SetMasterApp()
        {
            master = new OSAudioApp(device);
            return master;
        }
    }
}