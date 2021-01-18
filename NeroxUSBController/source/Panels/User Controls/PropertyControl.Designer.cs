namespace NeroxUSBController.source.Panels
{
    partial class PropertyControl
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
            this.property_panel = new NeroxUSBController.PropertyPanel();
            this.SuspendLayout();
            // 
            // property_panel
            // 
            this.property_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.property_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.property_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.property_panel.Location = new System.Drawing.Point(0, 0);
            this.property_panel.Name = "property_panel";
            this.property_panel.Size = new System.Drawing.Size(507, 181);
            this.property_panel.TabIndex = 3;
            // 
            // PropertyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.property_panel);
            this.Name = "PropertyControl";
            this.Size = new System.Drawing.Size(507, 181);
            this.ResumeLayout(false);

        }

        #endregion

        private PropertyPanel property_panel;
    }
}
