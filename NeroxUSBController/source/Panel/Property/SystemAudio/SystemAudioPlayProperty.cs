using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using NeroxUSBController.Controller.Graphic;

namespace NeroxUSBController.Panel.Property.SystemAudio
{
    public partial class SystemAudioPlayProperty : SystemAudioProperty
    {
        WaveOutEvent player;
        WaveStream audioFileStream;

        public SystemAudioPlayProperty()
        {
            InitializeComponent();
            player = new WaveOutEvent();
            player.PlaybackStopped += OnPlaybackStopped;
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs e)
        {
            if(audioFileStream.Length == audioFileStream.Position)
                userController.Activate(false);
        }

        public override void ButtonHandler(bool value)
        {
            if(value)
            {
                try
                {
                    player.DeviceNumber = deviceIndex;
                    audioFileStream.Position = 0;
                    player.Play();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                try
                {
                    player.Stop();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private void browserButton_Click(object sender, EventArgs e)
        {
            browserDialog.ShowDialog();
            browserText.Text = browserDialog.FileName;

            userController.Activate(false);
            SetFile(browserText.Text);
        }

        private void devices_DropDown(object sender, EventArgs e)
        {
            deviceList = audio.GetDeviceNamesandIDs();
            devices.DataSource = deviceList;
        }

        private void devices_Selected(object sender, EventArgs e)
        {
            deviceIndex = deviceList.IndexOf((string)devices.SelectedItem);
            audio.SetDevice(deviceIndex);
        }

        private void browserText_Leave(object sender, EventArgs e)
        {
            SetFile(browserText.Text);
        }

        private void SetFile(string file)
        {
            try
            {
                audioFileStream.Dispose();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("There is no disposable file");
            }

            try
            {
                audioFileStream = new AudioFileReader(file);
                player.Init(audioFileStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
