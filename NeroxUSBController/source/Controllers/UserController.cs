using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController
{
    public class UserController : UserControl
    {
        [Description("Activated Color"), Category("Color Appearance"), DefaultValue(0), Browsable(true)]
        public Color ActiveColor { get; set; }
        public Color PassiveColor { get { return Color.FromArgb(ActiveColor.R / 2, ActiveColor.G / 2, ActiveColor.B / 2); } }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        protected virtual void OnMouseClick(object sender, EventArgs e)
        {
            
        }

        public virtual void Select()
        {

        }

        public virtual void Deselect()
        {

        }

        public virtual void Activate()
        {

        }

        public virtual void Deactivate()
        {

        }
    }
}
