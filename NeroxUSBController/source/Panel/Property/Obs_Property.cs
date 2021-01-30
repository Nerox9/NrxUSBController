using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using NeroxUSBController.Wrapper;

namespace NeroxUSBController.Panel.Property
{
    class Obs_Property : ControllerProperty
    {
        internal Obs obs;
        
        public Obs_Property()
        {
            //this.Visible = false;
        }

        public void setProperty(object sender)
        {
            Console.WriteLine(sender);

        }
    }

    class Obs_Screen : Obs_Property
    {
        public Obs_Screen()
        {
            
        }

        public void Activate()
        {
            
        }
    }
}
