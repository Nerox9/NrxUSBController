namespace NeroxUSBController
{
    partial class Main
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.side_panel = new SidePanel();
            this.property_panel = new PropertyPanel();
            this.button_panel = new ButtonPanel();
            this.control_panel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.settingsSide_panel = new NeroxUSBController.SettingsSide();
            this.systemAppButton2 = new NeroxUSBController.SystemAppButton();
            this.systemAppButton1 = new NeroxUSBController.SystemAppButton();
            this.settings_panel = new NeroxUSBController.Settings();
            this.side_panel.SuspendLayout();
            this.property_panel.SuspendLayout();
            this.button_panel.SuspendLayout();
            this.control_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // control_panel
            // 
            this.control_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.control_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.control_panel.Controls.Add(this.systemAppButton2);
            this.control_panel.Controls.Add(this.systemAppButton1);
            this.control_panel.Controls.Add(this.pictureBox1);
            this.control_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_panel.Location = new System.Drawing.Point(0, 0);
            this.control_panel.Name = "control_panel";
            this.control_panel.Size = new System.Drawing.Size(800, 34);
            this.control_panel.TabIndex = 0;
            this.control_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_panel_MouseDown);
            this.control_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_panel_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(350, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 27);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // settingsSide_panel
            // 
            this.settingsSide_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settingsSide_panel.Location = new System.Drawing.Point(0, 0);
            this.settingsSide_panel.Name = "settingsSide_panel";
            this.settingsSide_panel.Size = new System.Drawing.Size(293, 416);
            this.settingsSide_panel.TabIndex = 1;
            this.settingsSide_panel.Visible = false;
            // 
            // systemAppButton2
            // 
            this.systemAppButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.systemAppButton2.ButtonImage = global::NeroxUSBController.Properties.Resources.metal_setting;
            this.systemAppButton2.Location = new System.Drawing.Point(738, 6);
            this.systemAppButton2.Name = "systemAppButton2";
            this.systemAppButton2.PressedButtonImage = global::NeroxUSBController.Properties.Resources.metal_setting_indicator;
            this.systemAppButton2.Size = new System.Drawing.Size(22, 22);
            this.systemAppButton2.TabIndex = 4;
            this.systemAppButton2.Text = "systemAppButton2";
            // 
            // systemAppButton1
            // 
            this.systemAppButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.systemAppButton1.ButtonImage = global::NeroxUSBController.Properties.Resources.metal_esc;
            this.systemAppButton1.isEscButton = true;
            this.systemAppButton1.Location = new System.Drawing.Point(766, 6);
            this.systemAppButton1.Name = "systemAppButton1";
            this.systemAppButton1.PressedButtonImage = global::NeroxUSBController.Properties.Resources.metal_esc_indicator;
            this.systemAppButton1.Size = new System.Drawing.Size(22, 22);
            this.systemAppButton1.TabIndex = 3;
            this.systemAppButton1.Text = "systemAppButton1";
            // 
            // settings_panel
            // 
            this.settings_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settings_panel.Location = new System.Drawing.Point(0, 0);
            this.settings_panel.Name = "settings_panel";
            this.settings_panel.Size = new System.Drawing.Size(507, 416);
            this.settings_panel.TabIndex = 10;
            this.settings_panel.Visible = false;
            //
            // Side Panel
            //
            this.side_panel.ButtonImageHide = ((System.Drawing.Image)resources.GetObject("treeView.ButtonImageHide"));
            this.side_panel.ButtonImageShow = ((System.Drawing.Image)resources.GetObject("treeView.ButtonImageShow"));
            this.side_panel.settingsSide_panel = this.settingsSide_panel;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_panel);
            this.Controls.Add(this.property_panel);
            this.Controls.Add(this.side_panel);
            this.Controls.Add(this.control_panel);
            this.Controls.Add(this.settings_panel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Main";
            this.side_panel.ResumeLayout(false);
            this.property_panel.ResumeLayout(false);
            this.property_panel.PerformLayout();
            this.button_panel.ResumeLayout(false);
            this.control_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private SidePanel side_panel;
        private PropertyPanel property_panel;
        private ButtonPanel button_panel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel control_panel;
        private SystemAppButton systemAppButton1;
        private SystemAppButton systemAppButton2;
        private Settings settings_panel;
        private SettingsSide settingsSide_panel;
    }
}

