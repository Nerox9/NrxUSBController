namespace NeroxUSBController.Panel.Property.SystemAudio
{
    partial class SystemAudioPlayProperty
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemAudioPlayProperty));
            this.browserText = new System.Windows.Forms.TextBox();
            this.browserButton = new System.Windows.Forms.Button();
            this.browserDialog = new System.Windows.Forms.OpenFileDialog();
            this.devices = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // browserText
            // 
            this.browserText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.browserText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.browserText.Location = new System.Drawing.Point(8, 80);
            this.browserText.Name = "browserText";
            this.browserText.Size = new System.Drawing.Size(144, 20);
            this.browserText.TabIndex = 6;
            this.browserText.Leave += new System.EventHandler(this.browserText_Leave);
            // 
            // browserButton
            // 
            this.browserButton.Location = new System.Drawing.Point(158, 80);
            this.browserButton.Name = "browserButton";
            this.browserButton.Size = new System.Drawing.Size(25, 20);
            this.browserButton.TabIndex = 7;
            this.browserButton.Text = "button1";
            this.browserButton.UseVisualStyleBackColor = true;
            this.browserButton.Click += new System.EventHandler(this.browserButton_Click);
            // 
            // browserDialog
            // 
            this.browserDialog.Filter = resources.GetString("browserDialog.Filter");
            this.browserDialog.SupportMultiDottedExtensions = true;
            // 
            // devices
            // 
            this.devices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.devices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.devices.FormattingEnabled = true;
            this.devices.Location = new System.Drawing.Point(189, 81);
            this.devices.Name = "devices";
            this.devices.Size = new System.Drawing.Size(218, 21);
            this.devices.TabIndex = 9;
            this.devices.DropDown += new System.EventHandler(this.devices_DropDown);
            this.devices.SelectedIndexChanged += new System.EventHandler(this.devices_Selected);
            // 
            // SystemAudioPlayProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.devices);
            this.Controls.Add(this.browserButton);
            this.Controls.Add(this.browserText);
            this.Name = "SystemAudioPlayProperty";
            this.Controls.SetChildIndex(this.colorPicker, 0);
            this.Controls.SetChildIndex(this.PropertyName, 0);
            this.Controls.SetChildIndex(this.browserText, 0);
            this.Controls.SetChildIndex(this.browserButton, 0);
            this.Controls.SetChildIndex(this.devices, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox browserText;
        private System.Windows.Forms.Button browserButton;
        private System.Windows.Forms.OpenFileDialog browserDialog;
        protected System.Windows.Forms.ComboBox devices;
    }
}
