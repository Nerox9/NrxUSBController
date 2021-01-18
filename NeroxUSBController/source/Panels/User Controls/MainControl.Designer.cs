namespace NeroxUSBController.source.Panels
{
    partial class MainControl
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
            this.propertyControl = new NeroxUSBController.source.Panels.PropertyControl();
            this.buttonControl = new NeroxUSBController.source.Panels.ButtonControl();
            this.SuspendLayout();
            // 
            // propertyControl
            // 
            this.propertyControl.Location = new System.Drawing.Point(0, 232);
            this.propertyControl.Name = "propertyControl";
            this.propertyControl.Size = new System.Drawing.Size(507, 184);
            this.propertyControl.TabIndex = 0;
            // 
            // buttonControl
            // 
            this.buttonControl.Location = new System.Drawing.Point(0, 0);
            this.buttonControl.Name = "buttonControl";
            this.buttonControl.Size = new System.Drawing.Size(507, 235);
            this.buttonControl.TabIndex = 4;
            this.buttonControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.control_panel_MouseDown);
            this.buttonControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.control_panel_MouseMove);

            // 
            // MainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonControl);
            this.Controls.Add(this.propertyControl);
            this.Name = "MainControl";
            this.Size = new System.Drawing.Size(507, 416);
            this.ResumeLayout(false);
            
        }

        #endregion

        private PropertyControl propertyControl;
        private ButtonControl buttonControl;
    }
}
