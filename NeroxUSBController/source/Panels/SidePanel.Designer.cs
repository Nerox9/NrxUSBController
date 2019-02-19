using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController
{
    class SidePanel : Panel
    {
        internal AppTreeView treeView;
        internal System.Drawing.Image ButtonImageHide { get; set; }
        internal System.Drawing.Image ButtonImageShow { get; set; }
        internal Panel settingsSide_panel { get; set; }

        public SidePanel()
        {
            // 
            // treeView
            // 
            this.treeView = new NeroxUSBController.AppTreeView();
            this.treeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView.ButtonImageHide = ButtonImageHide;
            this.treeView.ButtonImageShow = ButtonImageShow;
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
            // side_panel
            // 
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.settingsSide_panel);
            this.Dock = System.Windows.Forms.DockStyle.Right;
            this.Location = new System.Drawing.Point(507, 34);
            this.Name = "side_panel";
            this.Size = new System.Drawing.Size(293, 416);
            this.TabIndex = 1;
        }
    }
}
