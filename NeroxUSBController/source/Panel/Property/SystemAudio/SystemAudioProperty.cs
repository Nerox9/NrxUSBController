using NeroxUSBController.Controller.Graphic;
using NeroxUSBController.Panel.Property;
using NeroxUSBController.Wrapper.OSAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeroxUSBController.Panel.Property.SystemAudio
{
    public class SystemAudioProperty: ControllerProperty
    {
        protected ColorPicker colorPicker;

        protected int deviceIndex = -1;
        protected int appIndex = -1;

        protected OSAudioApp selectedApp;

        protected List<string> deviceList = new List<string>();
        protected Dictionary<string, OSAudioApp> apps = new Dictionary<string, OSAudioApp>();
        protected OSAudio audio;

        public SystemAudioProperty()
        {
            InitializeComponent();
            base.ColorPicker = colorPicker;
            colorPicker.Size = new System.Drawing.Size(75, 75);
            colorPicker.Location = new System.Drawing.Point(Width - colorPicker.Size.Width - 25, Height - colorPicker.Size.Height - 25);

            audio = new OSAudio();
        }

        protected void InitializeComponent()
        {
            this.colorPicker = new NeroxUSBController.Controller.Graphic.ColorPicker();
            this.SuspendLayout();
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
            this.Name = "SystemAudioProperty";
            this.Controls.SetChildIndex(this.colorPicker, 0);
            this.Controls.SetChildIndex(this.PropertyName, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
