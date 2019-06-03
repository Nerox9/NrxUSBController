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
            this.control_panel = new System.Windows.Forms.Panel();
            this.systemAppButton2 = new NeroxUSBController.SystemAppButton();
            this.systemAppButton1 = new NeroxUSBController.SystemAppButton();
            this.logo = new System.Windows.Forms.PictureBox();
            this.mainControl = new NeroxUSBController.source.Panels.MainControl();
            this.treeViewControl = new NeroxUSBController.source.Panels.TreeViewControl();
            this.control_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // control_panel
            // 
            this.control_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.control_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.control_panel.Controls.Add(this.systemAppButton2);
            this.control_panel.Controls.Add(this.systemAppButton1);
            this.control_panel.Controls.Add(this.logo);
            this.control_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_panel.Location = new System.Drawing.Point(0, 0);
            this.control_panel.Name = "control_panel";
            this.control_panel.Size = new System.Drawing.Size(800, 34);
            this.control_panel.TabIndex = 0;
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
            // logo
            // 
            this.logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logo.BackgroundImage")));
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logo.InitialImage = null;
            this.logo.Location = new System.Drawing.Point(497, 4);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(27, 27);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 2;
            this.logo.TabStop = false;
            // 
            // mainControl
            // 
            this.mainControl.Location = new System.Drawing.Point(0, 34);
            this.mainControl.Name = "mainControl";
            this.mainControl.Size = new System.Drawing.Size(508, 416);
            this.mainControl.TabIndex = 0;
            // 
            // treeViewControl
            // 
            this.treeViewControl.Location = new System.Drawing.Point(507, 34);
            this.treeViewControl.Name = "treeViewControl";
            this.treeViewControl.Size = new System.Drawing.Size(293, 416);
            this.treeViewControl.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.treeViewControl);
            this.Controls.Add(this.mainControl);
            this.Controls.Add(this.control_panel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Main";
            this.control_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel control_panel;
        private SystemAppButton systemAppButton1;
        private SystemAppButton systemAppButton2;
        private source.Panels.MainControl mainControl;
        private System.Windows.Forms.PictureBox logo;
        private source.Panels.TreeViewControl treeViewControl;
    }
}

