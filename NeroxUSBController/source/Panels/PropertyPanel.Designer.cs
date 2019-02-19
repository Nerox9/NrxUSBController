using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController
{
    class PropertyPanel : Panel
    {
        internal object chooseButton0;

        public PropertyPanel()
        {
            // 
            // property_panel
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Location = new System.Drawing.Point(0, 269);
            this.Name = "property_panel";
            this.Size = new System.Drawing.Size(507, 181);
            this.TabIndex = 2;
        }
    }
}
