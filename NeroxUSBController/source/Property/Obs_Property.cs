using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace NeroxUSBController
{
    
    class Obs_Property : Property
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
    

    class obs_SwitchScreen : Obs_Property
    {
        public obs_SwitchScreen()
        {
            
        }

        public void Activate()
        {
            
        }
    }
    
}
