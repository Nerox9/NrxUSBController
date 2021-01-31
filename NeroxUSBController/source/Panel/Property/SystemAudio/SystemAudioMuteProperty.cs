using NeroxUSBController.Wrapper.OSAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeroxUSBController.Panel.Property.SystemAudio
{
    class SystemAudioMuteProperty : SystemAudioProperty
    {
        protected System.Windows.Forms.ComboBox applications;
        protected System.Windows.Forms.ComboBox devices;

        public SystemAudioMuteProperty()
        {
            InitializeComponent();
        }

        protected void devices_DropDown(object sender, EventArgs e)
        {
            deviceList = audio.GetDeviceNamesandIDs();
            devices.DataSource = deviceList;
        }

        protected void devices_Selected(object sender, EventArgs e)
        {
            deviceIndex = deviceList.IndexOf((string)devices.SelectedItem);
            audio.SetDevice(deviceIndex);
        }

        protected void apps_DropDown(object sender, EventArgs e)
        {
            if (deviceIndex >= 0)
            {
                apps = audio.GetAppDictionary();
                applications.DataSource = apps.Keys.ToList();
            }
        }

        protected void apps_Selected(object sender, EventArgs e)
        {
            if (deviceIndex >= 0)
            {
                selectedApp = apps[applications.SelectedItem.ToString()];
            }
        }

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
            this.applications = new System.Windows.Forms.ComboBox();
            this.devices = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // applications
            // 
            this.applications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.applications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applications.FormattingEnabled = true;
            this.applications.Location = new System.Drawing.Point(232, 80);
            this.applications.Name = "applications";
            this.applications.Size = new System.Drawing.Size(218, 21);
            this.applications.TabIndex = 9;
            this.applications.DropDown += new System.EventHandler(this.apps_DropDown);
            this.applications.SelectedIndexChanged += new System.EventHandler(this.apps_Selected);
            // 
            // devices
            // 
            this.devices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.devices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.devices.FormattingEnabled = true;
            this.devices.Location = new System.Drawing.Point(8, 80);
            this.devices.Name = "devices";
            this.devices.Size = new System.Drawing.Size(218, 21);
            this.devices.TabIndex = 8;
            this.devices.DropDown += new System.EventHandler(this.devices_DropDown);
            this.devices.SelectedIndexChanged += new System.EventHandler(this.devices_Selected);
            // 
            // SystemAudioMuteProperty
            // 
            this.Controls.Add(this.applications);
            this.Controls.Add(this.devices);
            this.Name = "SystemAudioMuteProperty";
            this.Size = new System.Drawing.Size(600, 272);
            this.Controls.SetChildIndex(this.colorPicker, 0);
            this.Controls.SetChildIndex(this.PropertyName, 0);
            this.Controls.SetChildIndex(this.devices, 0);
            this.Controls.SetChildIndex(this.applications, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
