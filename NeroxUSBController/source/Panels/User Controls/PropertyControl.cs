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
    public partial class PropertyControl : UserControl
    {
        internal PropertyPanelController propertyPanelController;
        internal ColorPick colorPicker;

        public PropertyControl()
        {
            InitializeComponent();
            propertyPanelController = new PropertyPanelController(this.property_panel);
            colorPicker = propertyPanelController.colorPicker;
        }

    }
}
