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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("OBS", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.control_panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.side_panel = new System.Windows.Forms.Panel();
            this.treeView = new System.Windows.Forms.TreeView();
            this.property_panel = new System.Windows.Forms.Panel();
            this.NameTextBox = new NeroxUSBController.Property_Control_Text();
            this.colorPick1 = new NeroxUSBController.ColorPick();
            this.button_panel = new System.Windows.Forms.Panel();
            this.chooseButton5 = new NeroxUSBController.chooseButton();
            this.chooseButton4 = new NeroxUSBController.chooseButton();
            this.chooseButton3 = new NeroxUSBController.chooseButton();
            this.chooseButton2 = new NeroxUSBController.chooseButton();
            this.chooseButton1 = new NeroxUSBController.chooseButton();
            this.chooseButton0 = new NeroxUSBController.chooseButton();
            this.control_panel.SuspendLayout();
            this.side_panel.SuspendLayout();
            this.property_panel.SuspendLayout();
            this.button_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // control_panel
            // 
            this.control_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.control_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.control_panel.Controls.Add(this.panel1);
            this.control_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.control_panel.Location = new System.Drawing.Point(0, 0);
            this.control_panel.Name = "control_panel";
            this.control_panel.Size = new System.Drawing.Size(800, 34);
            this.control_panel.TabIndex = 0;
            this.control_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_panel_MouseDown);
            this.control_panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_panel_MouseMove);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(707, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(92, 38);
            this.panel1.TabIndex = 1;
            // 
            // side_panel
            // 
            this.side_panel.Controls.Add(this.treeView);
            this.side_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.side_panel.Location = new System.Drawing.Point(507, 34);
            this.side_panel.Name = "side_panel";
            this.side_panel.Size = new System.Drawing.Size(293, 416);
            this.side_panel.TabIndex = 1;
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.treeView.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Node1";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Node2";
            treeNode3.Name = "obs";
            treeNode3.Text = "OBS";
            this.treeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.treeView.Size = new System.Drawing.Size(293, 416);
            this.treeView.TabIndex = 0;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // property_panel
            // 
            this.property_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.property_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.property_panel.Controls.Add(this.NameTextBox);
            this.property_panel.Controls.Add(this.colorPick1);
            this.property_panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.property_panel.Location = new System.Drawing.Point(0, 269);
            this.property_panel.Name = "property_panel";
            this.property_panel.Size = new System.Drawing.Size(507, 181);
            this.property_panel.TabIndex = 2;
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColor = this.control_panel.BackColor;
            this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTextBox.Location = new System.Drawing.Point(30, 17);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(100, 20);
            this.NameTextBox.TabIndex = 1;
            this.NameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameTextBox.NameTextBox_KeyPress);
            // 
            // colorPick1
            // 
            this.colorPick1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.colorPick1.buttonImage = global::NeroxUSBController.Properties.Resources.metal_gui_indicator;
            this.colorPick1.Location = new System.Drawing.Point(407, 50);
            this.colorPick1.Name = "colorPick1";
            this.colorPick1.Size = new System.Drawing.Size(75, 75);
            this.colorPick1.TabIndex = 0;
            this.colorPick1.Text = "colorPick1";
            // 
            // button_panel
            // 
            this.button_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.button_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.button_panel.Controls.Add(this.chooseButton5);
            this.button_panel.Controls.Add(this.chooseButton4);
            this.button_panel.Controls.Add(this.chooseButton3);
            this.button_panel.Controls.Add(this.chooseButton2);
            this.button_panel.Controls.Add(this.chooseButton1);
            this.button_panel.Controls.Add(this.chooseButton0);
            this.button_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_panel.Location = new System.Drawing.Point(0, 34);
            this.button_panel.Name = "button_panel";
            this.button_panel.Size = new System.Drawing.Size(507, 235);
            this.button_panel.TabIndex = 3;
            // 
            // chooseButton5
            // 
            this.chooseButton5.ActiveColor = System.Drawing.Color.White;
            this.chooseButton5.BorderThickness = 2F;
            this.chooseButton5.Location = new System.Drawing.Point(299, 116);
            this.chooseButton5.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton5.Name = "chooseButton5";
            this.chooseButton5.Size = new System.Drawing.Size(94, 81);
            this.chooseButton5.TabIndex = 5;
            this.chooseButton5.Text = "chooseButton5";
            this.chooseButton5.Click += new System.EventHandler(this.chooseButton5_Click);
            // 
            // chooseButton4
            // 
            this.chooseButton4.ActiveColor = System.Drawing.Color.White;
            this.chooseButton4.BorderThickness = 2F;
            this.chooseButton4.Location = new System.Drawing.Point(195, 116);
            this.chooseButton4.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton4.Name = "chooseButton4";
            this.chooseButton4.Size = new System.Drawing.Size(94, 81);
            this.chooseButton4.TabIndex = 4;
            this.chooseButton4.Text = "chooseButton4";
            this.chooseButton4.Click += new System.EventHandler(this.chooseButton4_Click);
            // 
            // chooseButton3
            // 
            this.chooseButton3.ActiveColor = System.Drawing.Color.White;
            this.chooseButton3.BorderThickness = 2F;
            this.chooseButton3.Location = new System.Drawing.Point(91, 116);
            this.chooseButton3.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton3.Name = "chooseButton3";
            this.chooseButton3.Size = new System.Drawing.Size(94, 81);
            this.chooseButton3.TabIndex = 3;
            this.chooseButton3.Text = "chooseButton3";
            this.chooseButton3.Click += new System.EventHandler(this.chooseButton3_Click);
            // 
            // chooseButton2
            // 
            this.chooseButton2.ActiveColor = System.Drawing.Color.White;
            this.chooseButton2.BorderThickness = 2F;
            this.chooseButton2.Location = new System.Drawing.Point(299, 25);
            this.chooseButton2.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton2.Name = "chooseButton2";
            this.chooseButton2.Size = new System.Drawing.Size(94, 81);
            this.chooseButton2.TabIndex = 2;
            this.chooseButton2.Text = "chooseButton2";
            this.chooseButton2.Click += new System.EventHandler(this.chooseButton2_Click);
            // 
            // chooseButton1
            // 
            this.chooseButton1.ActiveColor = System.Drawing.Color.White;
            this.chooseButton1.BorderThickness = 2F;
            this.chooseButton1.Location = new System.Drawing.Point(195, 25);
            this.chooseButton1.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton1.Name = "chooseButton1";
            this.chooseButton1.Size = new System.Drawing.Size(94, 81);
            this.chooseButton1.TabIndex = 1;
            this.chooseButton1.Text = "chooseButton1";
            this.chooseButton1.Click += new System.EventHandler(this.chooseButton1_Click);
            // 
            // chooseButton0
            // 
            this.chooseButton0.ActiveColor = System.Drawing.Color.White;
            this.chooseButton0.BorderThickness = 2F;
            this.chooseButton0.Location = new System.Drawing.Point(91, 25);
            this.chooseButton0.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton0.Name = "chooseButton0";
            this.chooseButton0.Size = new System.Drawing.Size(94, 81);
            this.chooseButton0.TabIndex = 0;
            this.chooseButton0.Text = "chooseButton0";
            this.chooseButton0.Click += new System.EventHandler(this.chooseButton0_Click);
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
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Main";
            this.control_panel.ResumeLayout(false);
            this.side_panel.ResumeLayout(false);
            this.property_panel.ResumeLayout(false);
            this.property_panel.PerformLayout();
            this.button_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel control_panel;
        private System.Windows.Forms.Panel side_panel;
        private System.Windows.Forms.Panel property_panel;
        private System.Windows.Forms.Panel button_panel;
        private System.Windows.Forms.TreeView treeView;
        private chooseButton chooseButton0;
        private chooseButton chooseButton5;
        private chooseButton chooseButton4;
        private chooseButton chooseButton3;
        private chooseButton chooseButton2;
        private chooseButton chooseButton1;
        private ColorPick colorPick1;
        private System.Windows.Forms.Panel panel1;
        private Property_Control_Text NameTextBox;
    }
}

