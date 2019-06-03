namespace NeroxUSBController.source.Panels
{
    partial class ButtonControl
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
            this.button_panel = new NeroxUSBController.ButtonPanel();
            this.SuspendLayout();
            // 
            // button_panel
            // 
            this.button_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.button_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.button_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_panel.Location = new System.Drawing.Point(0, 0);
            this.button_panel.Name = "button_panel";
            this.button_panel.Size = new System.Drawing.Size(507, 235);
            this.button_panel.TabIndex = 4;
            // 
            // ButtonControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_panel);
            this.Name = "ButtonControl";
            this.Size = new System.Drawing.Size(507, 235);
            this.ResumeLayout(false);

        }

        #endregion

        private ButtonPanel button_panel;
    }
}
