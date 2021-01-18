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
    public partial class MainControl : UserControl
    {
        private Point lastPoint;
        public Boolean pressedAny = false;
        public object ActiveSelection;

        public MainControl()
        {
            InitializeComponent();
            buttonControl.setButtons(propertyControl.colorPicker);
        }

        private void control_panel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void control_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        public void SetPropertyPanelController(object sender) { propertyControl.propertyPanelController.SetPropertyPanel(sender); }
    }
}
