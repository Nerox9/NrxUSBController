using NeroxUSBController.Controller.Graphic;
using NeroxUSBController.Form;

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
            this.sidePanel = new System.Windows.Forms.Panel();
            this.propertyPanel = new System.Windows.Forms.Panel();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.logo = new System.Windows.Forms.PictureBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.buttonControl = new NeroxUSBController.Panel.ButtonControl();
            this.treeView = new NeroxUSBController.Controller.Graphic.AppTreeView();
            this.escButton = new NeroxUSBController.Form.SystemAppButton();
            this.settingsButton = new NeroxUSBController.Form.SystemAppButton();
            this.corePanel = new System.Windows.Forms.Panel();
            this.dragImage = new NeroxUSBController.Controller.Graphic.DragImage();
            this.sidePanel.SuspendLayout();
            this.buttonPanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.corePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dragImage)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.AutoScroll = true;
            this.sidePanel.Controls.Add(this.treeView);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.sidePanel.Location = new System.Drawing.Point(599, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(231, 436);
            this.sidePanel.TabIndex = 1;
            // 
            // propertyPanel
            // 
            this.propertyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.propertyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.propertyPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.propertyPanel.Location = new System.Drawing.Point(0, 256);
            this.propertyPanel.Margin = new System.Windows.Forms.Padding(0);
            this.propertyPanel.MinimumSize = new System.Drawing.Size(599, 180);
            this.propertyPanel.Name = "propertyPanel";
            this.propertyPanel.Size = new System.Drawing.Size(599, 180);
            this.propertyPanel.TabIndex = 2;
            // 
            // buttonPanel
            // 
            this.buttonPanel.AutoSize = true;
            this.buttonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.buttonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonPanel.Controls.Add(this.buttonControl);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPanel.MinimumSize = new System.Drawing.Size(599, 256);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(599, 256);
            this.buttonPanel.TabIndex = 3;
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.controlPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.controlPanel.Controls.Add(this.escButton);
            this.controlPanel.Controls.Add(this.settingsButton);
            this.controlPanel.Controls.Add(this.logo);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(830, 34);
            this.controlPanel.TabIndex = 0;
            this.controlPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_panel_MouseDown);
            this.controlPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_panel_MouseMove);
            // 
            // logo
            // 
            this.logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.logo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logo.BackgroundImage")));
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logo.InitialImage = null;
            this.logo.Location = new System.Drawing.Point(364, 4);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(27, 27);
            this.logo.TabIndex = 2;
            this.logo.TabStop = false;
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSize = true;
            this.mainPanel.Controls.Add(this.buttonPanel);
            this.mainPanel.Controls.Add(this.propertyPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.MinimumSize = new System.Drawing.Size(599, 436);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(599, 436);
            this.mainPanel.TabIndex = 0;
            // 
            // buttonControl
            // 
            this.buttonControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.buttonControl.Location = new System.Drawing.Point(-3, 1);
            this.buttonControl.Name = "buttonControl";
            this.buttonControl.Size = new System.Drawing.Size(597, 238);
            this.buttonControl.TabIndex = 0;
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.ButtonImageHide = ((System.Drawing.Image)(resources.GetObject("treeView.ButtonImageHide")));
            this.treeView.ButtonImageShow = ((System.Drawing.Image)(resources.GetObject("treeView.ButtonImageShow")));
            this.treeView.ChildBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeView.ForeColor = System.Drawing.Color.Red;
            this.treeView.FullRowSelect = true;
            this.treeView.ItemHeight = 50;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.ParentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.treeView.Scrollable = false;
            this.treeView.ShowLines = false;
            this.treeView.ShowPlusMinus = false;
            this.treeView.ShowRootLines = false;
            this.treeView.Size = new System.Drawing.Size(231, 436);
            this.treeView.TabIndex = 0;
            // 
            // escButton
            // 
            this.escButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.escButton.ButtonImage = global::NeroxUSBController.Properties.Resources.exitbutton;
            this.escButton.isEscButton = true;
            this.escButton.Location = new System.Drawing.Point(802, 6);
            this.escButton.Margin = new System.Windows.Forms.Padding(5);
            this.escButton.Name = "escButton";
            this.escButton.PressedButtonImage = global::NeroxUSBController.Properties.Resources.exitbuttonSelected;
            this.escButton.Size = new System.Drawing.Size(23, 23);
            this.escButton.TabIndex = 4;
            this.escButton.Text = "systemAppButton2";
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.ButtonImage = ((System.Drawing.Image)(resources.GetObject("settingsButton.ButtonImage")));
            this.settingsButton.Location = new System.Drawing.Point(771, 6);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.PressedButtonImage = global::NeroxUSBController.Properties.Resources.metal_setting_indicator;
            this.settingsButton.Size = new System.Drawing.Size(23, 23);
            this.settingsButton.TabIndex = 3;
            this.settingsButton.Text = "systemAppButton1";
            // 
            // corePanel
            // 
            this.corePanel.Controls.Add(this.dragImage);
            this.corePanel.Controls.Add(this.mainPanel);
            this.corePanel.Controls.Add(this.sidePanel);
            this.corePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.corePanel.Location = new System.Drawing.Point(0, 34);
            this.corePanel.Name = "corePanel";
            this.corePanel.Size = new System.Drawing.Size(830, 436);
            this.corePanel.TabIndex = 0;
            // 
            // dragImage
            // 
            this.dragImage.Enabled = false;
            this.dragImage.Location = new System.Drawing.Point(250, 69);
            this.dragImage.Name = "dragImage";
            this.dragImage.Size = new System.Drawing.Size(100, 50);
            this.dragImage.TabIndex = 0;
            this.dragImage.TabStop = false;
            this.dragImage.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(830, 470);
            this.ControlBox = false;
            this.Controls.Add(this.corePanel);
            this.Controls.Add(this.controlPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(830, 470);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Paint);
            this.sidePanel.ResumeLayout(false);
            this.buttonPanel.ResumeLayout(false);
            this.controlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.corePanel.ResumeLayout(false);
            this.corePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dragImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel propertyPanel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Panel controlPanel;
        private Panel.ButtonControl buttonControl;
        private AppTreeView treeView;
        private SystemAppButton settingsButton;
        private SystemAppButton escButton;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel corePanel;
        private NeroxUSBController.Controller.Graphic.DragImage dragImage;
    }
}

