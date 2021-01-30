using NeroxUSBController.Controller.Graphic;
using NeroxUSBController.Panel.Property;
using NeroxUSBController.Wrapper.OSAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeroxUSBController.Property.SystemAudio
{
    public class SystemAudioProperty: ControllerProperty
    {
        protected System.Windows.Forms.ComboBox applications;
        protected ColorPicker colorPicker;
        protected System.Windows.Forms.ComboBox devices;

        protected int deviceIndex = -1;
        protected int appIndex = -1;

        protected OSAudioApp selectedApp;

        List<string> deviceList = new List<string>();
        Dictionary<string, OSAudioApp> apps = new Dictionary<string, OSAudioApp>();
        OSAudio audio;

        public SystemAudioProperty()
        {
            InitializeComponent();
            base.ColorPicker = colorPicker;
            colorPicker.Size = new System.Drawing.Size(75, 75);
            colorPicker.Location = new System.Drawing.Point(Width - colorPicker.Size.Width - 25, Height - colorPicker.Size.Height - 25);

            audio = new OSAudio();
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
            if(deviceIndex >= 0)
            {
                apps = audio.GetAppDictionary();
                applications.DataSource = apps.Keys.ToList();
            }
        }

        protected void apps_Selected(object sender, EventArgs e)
        {
            if(deviceIndex >= 0)
            {
                selectedApp = apps[applications.SelectedItem.ToString()];
            } 
        }

        protected void InitializeComponent()
        {
            this.devices = new System.Windows.Forms.ComboBox();
            this.applications = new System.Windows.Forms.ComboBox();
            this.colorPicker = new NeroxUSBController.Controller.Graphic.ColorPicker();
            this.SuspendLayout();
            // 
            // devices
            // 
            this.devices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.devices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.devices.FormattingEnabled = true;
            this.devices.Location = new System.Drawing.Point(8, 80);
            this.devices.Name = "devices";
            this.devices.Size = new System.Drawing.Size(218, 21);
            this.devices.TabIndex = 0;
            this.devices.DropDown += new System.EventHandler(this.devices_DropDown);
            this.devices.SelectedIndexChanged += new System.EventHandler(this.devices_Selected);
            // 
            // applications
            // 
            this.applications.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.applications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.applications.FormattingEnabled = true;
            this.applications.Location = new System.Drawing.Point(232, 80);
            this.applications.Name = "applications";
            this.applications.Size = new System.Drawing.Size(218, 21);
            this.applications.TabIndex = 1;
            this.applications.DropDown += new System.EventHandler(this.apps_DropDown);
            this.applications.SelectedIndexChanged += new System.EventHandler(this.apps_Selected);
            // 
            // colorPicker
            // 
            this.colorPicker.Location = new System.Drawing.Point(500, 80);
            this.colorPicker.Margin = new System.Windows.Forms.Padding(25);
            this.colorPicker.Name = "colorPicker";
            this.colorPicker.Size = new System.Drawing.Size(75, 75);
            this.colorPicker.TabIndex = 2;
            // 
            // SystemAudioProperty
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.colorPicker);
            this.Controls.Add(this.applications);
            this.Controls.Add(this.devices);
            this.Name = "SystemAudioProperty";
            this.Controls.SetChildIndex(this.devices, 0);
            this.Controls.SetChildIndex(this.applications, 0);
            this.Controls.SetChildIndex(this.colorPicker, 0);
            this.Controls.SetChildIndex(this.PropertyName, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
