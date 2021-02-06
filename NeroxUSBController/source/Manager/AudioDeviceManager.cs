using NAudio.CoreAudioApi;
using NAudio.CoreAudioApi.Interfaces;
using NeroxUSBController.Wrapper.OSAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeroxUSBController.Manager
{
    static class AudioDeviceManager
    {
        static internal MMDevice[] outputDevices;
        static internal MMDevice[] inputDevices;
        static internal List<string> outputDeviceList;
        static internal List<string> inputDeviceList;

        static MMDeviceEnumerator MMDE = new MMDeviceEnumerator();
        static MMDeviceCollection outputDeviceCollection;
        static MMDeviceCollection inputDeviceCollection;

        static NotificationClient Attached = new NotificationClient();

        static AudioDeviceManager()
        {
            MMDE.RegisterEndpointNotificationCallback(Attached);
        }

        static public Dictionary<string, MMDevice> GetOutputDeviceNames()
        {
            return outputDevices.ToDictionary(d => d.FriendlyName, d => d);
        }

        static public Dictionary<string, MMDevice> GetInputDeviceNames()
        {
            return inputDevices.ToDictionary(d => d.FriendlyName, d => d);
        }

        static public List<string> GetOutputDeviceNamesandIDs()
        {
            return outputDevices.Select(d => d.FriendlyName).ToList();
        }

        static public List<string> GetInputDeviceNamesandIDs()
        {
            return inputDevices.Select(d => d.FriendlyName).ToList();
        }

        static MMDevice[] GetOutputDevices()
        {
            return GetOutputDeviceCollection().ToArray();
        }

        static MMDevice[] GetInputDevices()
        {
            return GetInputDeviceCollection().ToArray();
        }

        static MMDeviceCollection GetOutputDeviceCollection()
        {
            outputDeviceCollection = MMDE.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            return outputDeviceCollection;
        }

        static MMDeviceCollection GetInputDeviceCollection()
        {
            inputDeviceCollection = MMDE.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            return inputDeviceCollection;
        }

        static internal void RefreshDevices()
        {
            outputDevices = GetOutputDevices();
            outputDeviceList = GetOutputDeviceNamesandIDs();

            inputDevices = GetInputDevices();
            inputDeviceList = GetInputDeviceNamesandIDs();
        }
    }

    class NotificationClient : IMMNotificationClient
    {
        void IMMNotificationClient.OnDeviceStateChanged(string deviceId, DeviceState newState)
        {
            Console.WriteLine("OnDeviceStateChanged\n Device Id -->{0} : Device State {1}", deviceId, newState);
            AudioDeviceManager.RefreshDevices();
        }

        void IMMNotificationClient.OnDeviceAdded(string pwstrDeviceId) { }
        void IMMNotificationClient.OnDeviceRemoved(string deviceId) { }
        void IMMNotificationClient.OnDefaultDeviceChanged(DataFlow flow, Role role, string defaultDeviceId) { }
        void IMMNotificationClient.OnPropertyValueChanged(string pwstrDeviceId, PropertyKey key) { }
    }
}
