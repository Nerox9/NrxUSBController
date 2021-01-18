using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController.source.Panels
{
    public partial class TreeViewControl : UserControl
    {
        public TreeViewControl()
        {
            InitializeComponent();
            appTreeView.CreateTree();
        }

        internal void SetProperties(PropertyPanel panel)
        {
            //appTreeView.OBS_SwitchScreen.SetPropertyPanel(panel);
        }
    }
}
