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
            this.side_panel = new System.Windows.Forms.Panel();
            this.property_panel = new System.Windows.Forms.Panel();
            this.property_panel_msg = new System.Windows.Forms.Label();
            this.button_panel = new System.Windows.Forms.Panel();
            this.switch_label2 = new System.Windows.Forms.Label();
            this.switch_label1 = new System.Windows.Forms.Label();
            this.control_panel = new System.Windows.Forms.Panel();
            this.NrxLogo = new System.Windows.Forms.PictureBox();
            this.left_panel = new System.Windows.Forms.Panel();
            this.settings_panel = new NeroxUSBController.Settings();
            this.accounts_panel = new System.Windows.Forms.Panel();
            this.account_Choose = new NeroxUSBController.Account_Choose();
            this.NameTextBox = new NeroxUSBController.PropertyControlText();
            this.colorPick1 = new NeroxUSBController.ColorPick();
            this.pot1 = new NeroxUSBController.Pot();
            this.pot2 = new NeroxUSBController.Pot();
            this.toggleSwitch2 = new NeroxUSBController.ToggleSwitch();
            this.toggleSwitch1 = new NeroxUSBController.ToggleSwitch();
            this.chooseButton5 = new NeroxUSBController.ChooseButton();
            this.chooseButton4 = new NeroxUSBController.ChooseButton();
            this.chooseButton3 = new NeroxUSBController.ChooseButton();
            this.chooseButton2 = new NeroxUSBController.ChooseButton();
            this.chooseButton1 = new NeroxUSBController.ChooseButton();
            this.chooseButton0 = new NeroxUSBController.ChooseButton();
            this.settingTreeView = new NeroxUSBController.SettingTreeView();
            this.treeView = new NeroxUSBController.AppTreeView();
            this.systemAppButton2 = new NeroxUSBController.SystemAppButton();
            this.systemAppButton1 = new NeroxUSBController.SystemAppButton();
            this.side_panel.SuspendLayout();
            this.property_panel.SuspendLayout();
            this.button_panel.SuspendLayout();
            this.control_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NrxLogo)).BeginInit();
            this.left_panel.SuspendLayout();
            this.settings_panel.SuspendLayout();
            this.accounts_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // side_panel
            // 
            this.side_panel.Controls.Add(this.settingTreeView);
            this.side_panel.Controls.Add(this.treeView);
            this.side_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.side_panel.Location = new System.Drawing.Point(507, 34);
            this.side_panel.Name = "side_panel";
            this.side_panel.Size = new System.Drawing.Size(293, 416);
            this.side_panel.TabIndex = 1;
            // 
            // property_panel
            // 
            this.property_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.property_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.property_panel.Controls.Add(this.NameTextBox);
            this.property_panel.Controls.Add(this.colorPick1);
            this.property_panel.Controls.Add(this.property_panel_msg);
            this.property_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.property_panel.Location = new System.Drawing.Point(0, 235);
            this.property_panel.Name = "property_panel";
            this.property_panel.Size = new System.Drawing.Size(507, 181);
            this.property_panel.TabIndex = 2;
            // 
            // property_panel_msg
            // 
            this.property_panel_msg.AutoSize = true;
            this.property_panel_msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.property_panel_msg.ForeColor = System.Drawing.Color.Red;
            this.property_panel_msg.Location = new System.Drawing.Point(50, 80);
            this.property_panel_msg.Name = "property_panel_msg";
            this.property_panel_msg.Size = new System.Drawing.Size(398, 24);
            this.property_panel_msg.TabIndex = 0;
            this.property_panel_msg.Text = "Drag an item or choose a switch, button or pot.";
            // 
            // button_panel
            // 
            this.button_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.button_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.button_panel.Controls.Add(this.pot1);
            this.button_panel.Controls.Add(this.pot2);
            this.button_panel.Controls.Add(this.switch_label2);
            this.button_panel.Controls.Add(this.switch_label1);
            this.button_panel.Controls.Add(this.toggleSwitch2);
            this.button_panel.Controls.Add(this.toggleSwitch1);
            this.button_panel.Controls.Add(this.chooseButton5);
            this.button_panel.Controls.Add(this.chooseButton4);
            this.button_panel.Controls.Add(this.chooseButton3);
            this.button_panel.Controls.Add(this.chooseButton2);
            this.button_panel.Controls.Add(this.chooseButton1);
            this.button_panel.Controls.Add(this.chooseButton0);
            this.button_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_panel.Location = new System.Drawing.Point(0, 0);
            this.button_panel.Name = "button_panel";
            this.button_panel.Size = new System.Drawing.Size(507, 416);
            this.button_panel.TabIndex = 3;
            // 
            // switch_label2
            // 
            this.switch_label2.ForeColor = System.Drawing.Color.Red;
            this.switch_label2.Location = new System.Drawing.Point(412, 25);
            this.switch_label2.Name = "switch_label2";
            this.switch_label2.Size = new System.Drawing.Size(70, 13);
            this.switch_label2.TabIndex = 9;
            this.switch_label2.Text = "switch2";
            this.switch_label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // switch_label1
            // 
            this.switch_label1.ForeColor = System.Drawing.Color.Red;
            this.switch_label1.Location = new System.Drawing.Point(13, 25);
            this.switch_label1.Name = "switch_label1";
            this.switch_label1.Size = new System.Drawing.Size(70, 13);
            this.switch_label1.TabIndex = 8;
            this.switch_label1.Text = "switch1";
            this.switch_label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // control_panel
            // 
            this.control_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.control_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.control_panel.Controls.Add(this.systemAppButton2);
            this.control_panel.Controls.Add(this.systemAppButton1);
            this.control_panel.Controls.Add(this.NrxLogo);
            this.control_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_panel.Location = new System.Drawing.Point(0, 0);
            this.control_panel.Name = "control_panel";
            this.control_panel.Size = new System.Drawing.Size(800, 34);
            this.control_panel.TabIndex = 0;
            this.control_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_panel_MouseDown);
            this.control_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_panel_MouseMove);
            // 
            // NrxLogo
            // 
            this.NrxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.NrxLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NrxLogo.BackgroundImage")));
            this.NrxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NrxLogo.InitialImage = null;
            this.NrxLogo.Location = new System.Drawing.Point(350, 4);
            this.NrxLogo.Name = "NrxLogo";
            this.NrxLogo.Size = new System.Drawing.Size(27, 27);
            this.NrxLogo.TabIndex = 2;
            this.NrxLogo.TabStop = false;
            // 
            // left_panel
            // 
            this.left_panel.Controls.Add(this.settings_panel);
            this.left_panel.Controls.Add(this.property_panel);
            this.left_panel.Controls.Add(this.button_panel);
            this.left_panel.Location = new System.Drawing.Point(0, 34);
            this.left_panel.Name = "left_panel";
            this.left_panel.Size = new System.Drawing.Size(507, 416);
            this.left_panel.TabIndex = 13;
            // 
            // settings_panel
            // 
            this.settings_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settings_panel.Controls.Add(this.accounts_panel);
            this.settings_panel.Location = new System.Drawing.Point(0, 0);
            this.settings_panel.Name = "settings_panel";
            this.settings_panel.Size = new System.Drawing.Size(507, 416);
            this.settings_panel.TabIndex = 10;
            this.settings_panel.Visible = false;
            // 
            // accounts_panel
            // 
            this.accounts_panel.Controls.Add(this.account_Choose);
            this.accounts_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accounts_panel.Location = new System.Drawing.Point(0, 0);
            this.accounts_panel.Name = "accounts_panel";
            this.accounts_panel.Size = new System.Drawing.Size(505, 414);
            this.accounts_panel.TabIndex = 13;
            this.accounts_panel.Visible = false;
            // 
            // account_Choose
            // 
            this.account_Choose.Location = new System.Drawing.Point(65, 43);
            this.account_Choose.Name = "account_Choose";
            this.account_Choose.Size = new System.Drawing.Size(165, 30);
            this.account_Choose.TabIndex = 0;
            this.account_Choose.Text = "account_Choose";
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.NameTextBox.ForeColor = System.Drawing.Color.Maroon;
            this.NameTextBox.Location = new System.Drawing.Point(33, 50);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 1;
            this.NameTextBox.Visible = false;
            // 
            // colorPick1
            // 
            this.colorPick1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.colorPick1.buttonImage = ((System.Drawing.Image)(resources.GetObject("colorPick1.buttonImage")));
            this.colorPick1.Location = new System.Drawing.Point(407, 50);
            this.colorPick1.Name = "colorPick1";
            this.colorPick1.Size = new System.Drawing.Size(75, 75);
            this.colorPick1.TabIndex = 0;
            this.colorPick1.Text = "colorPick1";
            this.colorPick1.Visible = false;
            // 
            // pot1
            // 
            this.pot1.HighLimit = 135;
            this.pot1.Location = new System.Drawing.Point(13, 127);
            this.pot1.LowLimit = -135;
            this.pot1.Name = "pot1";
            this.pot1.Rotor = global::NeroxUSBController.Properties.Resources.pot_head;
            this.pot1.RotorGlow = global::NeroxUSBController.Properties.Resources.pot_head_indicator;
            this.pot1.Size = new System.Drawing.Size(70, 70);
            this.pot1.Stator = global::NeroxUSBController.Properties.Resources.pot_base;
            this.pot1.TabIndex = 12;
            this.pot1.Text = "pot1";
            // 
            // pot2
            // 
            this.pot2.HighLimit = 135;
            this.pot2.Location = new System.Drawing.Point(412, 127);
            this.pot2.LowLimit = -135;
            this.pot2.Name = "pot2";
            this.pot2.Rotor = global::NeroxUSBController.Properties.Resources.pot_head;
            this.pot2.RotorGlow = global::NeroxUSBController.Properties.Resources.pot_head_indicator;
            this.pot2.Size = new System.Drawing.Size(70, 70);
            this.pot2.Stator = global::NeroxUSBController.Properties.Resources.pot_base;
            this.pot2.TabIndex = 11;
            this.pot2.Text = "pot2";
            // 
            // toggleSwitch2
            // 
            this.toggleSwitch2.ActiveColor = System.Drawing.Color.White;
            this.toggleSwitch2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.toggleSwitch2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toggleSwitch2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toggleSwitch2.Location = new System.Drawing.Point(433, 43);
            this.toggleSwitch2.Name = "toggleSwitch2";
            this.toggleSwitch2.PassiveColor = System.Drawing.Color.Gray;
            this.toggleSwitch2.Size = new System.Drawing.Size(26, 43);
            this.toggleSwitch2.SwitchLabel = this.switch_label2;
            this.toggleSwitch2.TabIndex = 7;
            this.toggleSwitch2.Text = "On";
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.ActiveColor = System.Drawing.Color.White;
            this.toggleSwitch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.toggleSwitch1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toggleSwitch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toggleSwitch1.Location = new System.Drawing.Point(33, 43);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.PassiveColor = System.Drawing.Color.Gray;
            this.toggleSwitch1.Size = new System.Drawing.Size(26, 43);
            this.toggleSwitch1.SwitchLabel = this.switch_label1;
            this.toggleSwitch1.TabIndex = 6;
            this.toggleSwitch1.Text = "On";
            // 
            // chooseButton5
            // 
            this.chooseButton5.ActiveColor = System.Drawing.Color.White;
            this.chooseButton5.AllowDrop = true;
            this.chooseButton5.BorderThickness = 2F;
            this.chooseButton5.Location = new System.Drawing.Point(299, 116);
            this.chooseButton5.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton5.Name = "chooseButton5";
            this.chooseButton5.Size = new System.Drawing.Size(94, 81);
            this.chooseButton5.TabIndex = 5;
            this.chooseButton5.Text = "Button5";
            // 
            // chooseButton4
            // 
            this.chooseButton4.ActiveColor = System.Drawing.Color.White;
            this.chooseButton4.AllowDrop = true;
            this.chooseButton4.BorderThickness = 2F;
            this.chooseButton4.Location = new System.Drawing.Point(195, 116);
            this.chooseButton4.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton4.Name = "chooseButton4";
            this.chooseButton4.Size = new System.Drawing.Size(94, 81);
            this.chooseButton4.TabIndex = 4;
            this.chooseButton4.Text = "Button4";
            // 
            // chooseButton3
            // 
            this.chooseButton3.ActiveColor = System.Drawing.Color.White;
            this.chooseButton3.AllowDrop = true;
            this.chooseButton3.BorderThickness = 2F;
            this.chooseButton3.Location = new System.Drawing.Point(91, 116);
            this.chooseButton3.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton3.Name = "chooseButton3";
            this.chooseButton3.Size = new System.Drawing.Size(94, 81);
            this.chooseButton3.TabIndex = 3;
            this.chooseButton3.Text = "Button3";
            // 
            // chooseButton2
            // 
            this.chooseButton2.ActiveColor = System.Drawing.Color.White;
            this.chooseButton2.AllowDrop = true;
            this.chooseButton2.BorderThickness = 2F;
            this.chooseButton2.Location = new System.Drawing.Point(299, 25);
            this.chooseButton2.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton2.Name = "chooseButton2";
            this.chooseButton2.Size = new System.Drawing.Size(94, 81);
            this.chooseButton2.TabIndex = 2;
            this.chooseButton2.Text = "Button2";
            // 
            // chooseButton1
            // 
            this.chooseButton1.ActiveColor = System.Drawing.Color.White;
            this.chooseButton1.AllowDrop = true;
            this.chooseButton1.BorderThickness = 2F;
            this.chooseButton1.Location = new System.Drawing.Point(195, 25);
            this.chooseButton1.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton1.Name = "chooseButton1";
            this.chooseButton1.Size = new System.Drawing.Size(94, 81);
            this.chooseButton1.TabIndex = 1;
            this.chooseButton1.Text = "Button1";
            // 
            // chooseButton0
            // 
            this.chooseButton0.ActiveColor = System.Drawing.Color.White;
            this.chooseButton0.AllowDrop = true;
            this.chooseButton0.BorderThickness = 2F;
            this.chooseButton0.Location = new System.Drawing.Point(91, 25);
            this.chooseButton0.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton0.Name = "chooseButton0";
            this.chooseButton0.Size = new System.Drawing.Size(94, 81);
            this.chooseButton0.TabIndex = 0;
            this.chooseButton0.Text = "Button0";
            // 
            // settingTreeView
            // 
            this.settingTreeView.ActiveNodeColor = System.Drawing.Color.Firebrick;
            this.settingTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.settingTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settingTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingTreeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.settingTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.settingTreeView.ForeColor = System.Drawing.SystemColors.Window;
            this.settingTreeView.FullRowSelect = true;
            this.settingTreeView.HotTracking = true;
            this.settingTreeView.Indent = 20;
            this.settingTreeView.ItemHeight = 35;
            this.settingTreeView.Location = new System.Drawing.Point(0, 0);
            this.settingTreeView.Name = "settingTreeView";
            this.settingTreeView.ParentForeColor = System.Drawing.Color.DarkGray;
            this.settingTreeView.ShowLines = false;
            this.settingTreeView.ShowNodeToolTips = true;
            this.settingTreeView.Size = new System.Drawing.Size(293, 416);
            this.settingTreeView.TabIndex = 1;
            this.settingTreeView.Visible = false;
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView.ButtonImageHide = ((System.Drawing.Image)(resources.GetObject("treeView.ButtonImageHide")));
            this.treeView.ButtonImageShow = ((System.Drawing.Image)(resources.GetObject("treeView.ButtonImageShow")));
            this.treeView.ChildBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.treeView.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.treeView.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.ParentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.treeView.ShowLines = false;
            this.treeView.ShowPlusMinus = false;
            this.treeView.ShowRootLines = false;
            this.treeView.Size = new System.Drawing.Size(293, 416);
            this.treeView.TabIndex = 0;
            this.treeView.TabStop = false;
            this.treeView.Tag = "";
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.left_panel);
            this.Controls.Add(this.side_panel);
            this.Controls.Add(this.control_panel);
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
            ((System.ComponentModel.ISupportInitialize)(this.NrxLogo)).EndInit();
            this.left_panel.ResumeLayout(false);
            this.settings_panel.ResumeLayout(false);
            this.accounts_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel side_panel;
        private System.Windows.Forms.Panel property_panel;
        private System.Windows.Forms.Panel button_panel;
        private ChooseButton chooseButton0;
        private ChooseButton chooseButton5;
        private ChooseButton chooseButton4;
        private ChooseButton chooseButton3;
        private ChooseButton chooseButton2;
        private ChooseButton chooseButton1;
        private PropertyControlText NameTextBox;
        private ToggleSwitch toggleSwitch1;
        private ToggleSwitch toggleSwitch2;
        private System.Windows.Forms.Label switch_label2;
        private System.Windows.Forms.Label switch_label1;
        private System.Windows.Forms.PictureBox NrxLogo;
        private System.Windows.Forms.Panel control_panel;
        private SystemAppButton systemAppButton1;
        private SystemAppButton systemAppButton2;
        private Settings settings_panel;
        private Pot pot2;
        private Pot pot1;
        private ColorPick colorPick1;
        private System.Windows.Forms.Label property_panel_msg;
        internal AppTreeView treeView;
        private System.Windows.Forms.Panel left_panel;
        private SettingTreeView settingTreeView;
        private System.Windows.Forms.Panel accounts_panel;
        private Account_Choose account_Choose;
    }
}

