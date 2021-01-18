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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeViewControl));
            this.appTreeView1 = new NeroxUSBController.AppTreeView();
            this.SuspendLayout();
            // 
            // appTreeView1
            // 
            this.appTreeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.appTreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.appTreeView1.ButtonImageHide = ((System.Drawing.Image)(resources.GetObject("appTreeView1.ButtonImageHide")));
            this.appTreeView1.ButtonImageShow = ((System.Drawing.Image)(resources.GetObject("appTreeView1.ButtonImageShow")));
            this.appTreeView1.ChildBackColor = System.Drawing.Color.Empty;
            this.appTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.appTreeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.appTreeView1.Location = new System.Drawing.Point(0, 0);
            this.appTreeView1.Name = "appTreeView1";
            this.appTreeView1.ParentBackColor = System.Drawing.Color.Empty;
            this.appTreeView1.Size = new System.Drawing.Size(150, 150);
            this.appTreeView1.TabIndex = 0;
            // 
            // TreeViewControl
            // 
            this.Controls.Add(this.appTreeView1);
            this.Name = "TreeViewControl";
            this.ResumeLayout(false);

        }

        #endregion

        private AppTreeView appTreeView;
        private AppTreeView appTreeView1;
    }
}
