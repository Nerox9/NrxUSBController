using NeroxUSBController.Controller.Graphic;
using NeroxUSBController.Form;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController.Manager
{
    static class PanelManager
    {
        public enum PanelSet { Controller, Settings }

        static public System.Windows.Forms.Panel CorePanel { get; set; }
        static public System.Windows.Forms.Panel MainPanel { get; set; }
        static public System.Windows.Forms.Panel ButtonPanel { get; set; }
        static public System.Windows.Forms.Panel PropertyPanel { get; set; }
        static public System.Windows.Forms.Panel SidePanel { get; set; }
        static public AppTreeView TreeView { get; set; }

        static private PanelSet panelSet = PanelSet.Controller;

        static PanelManager()
        {

        }

        static public void SetPanelSet(PanelSet set)
        {
            panelSet = set;

            switch(panelSet)
            {
                case PanelSet.Controller:
                    ButtonPanel.Visible = true;
                    PropertyPanel.Visible = true;
                    TreeView.Visible = true;
                    break;

                case PanelSet.Settings:
                    ButtonPanel.Visible = false;
                    PropertyPanel.Visible = false;
                    TreeView.Visible = false;
                    break;
            }
        }

        static public PanelSet GetPanelSet()
        {
            return panelSet;
        }
    }
}
