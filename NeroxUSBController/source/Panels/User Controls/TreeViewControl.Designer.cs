namespace NeroxUSBController.source.Panels
{
    partial class TreeViewControl
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
            this.appTreeView = new NeroxUSBController.AppTreeView();
            this.SuspendLayout();
            // 
            // appTreeView
            // 
            this.appTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.appTreeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.appTreeView.ButtonImageHide = global::NeroxUSBController.Properties.Resources.ButtonImageHide;
            this.appTreeView.ButtonImageShow = global::NeroxUSBController.Properties.Resources.ButtonImageShow;
            this.appTreeView.ChildBackColor = System.Drawing.Color.Empty;
            this.appTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appTreeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.appTreeView.ForeColor = System.Drawing.Color.Maroon;
            this.appTreeView.LineColor = System.Drawing.Color.DarkRed;
            this.appTreeView.Location = new System.Drawing.Point(0, 0);
            this.appTreeView.Name = "appTreeView";
            this.appTreeView.ParentBackColor = System.Drawing.Color.Empty;
            this.appTreeView.Size = new System.Drawing.Size(293, 416);
            this.appTreeView.TabIndex = 1;
            // 
            // TreeViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.appTreeView);
            this.Name = "TreeViewControl";
            this.Size = new System.Drawing.Size(293, 416);
            this.ResumeLayout(false);

        }

        #endregion

        private AppTreeView appTreeView;
    }
}
