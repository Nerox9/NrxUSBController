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
    public partial class ButtonControl : UserControl
    {
        public ButtonControl()
        {
            InitializeComponent();
        }

        internal void setButtons(ColorPick colorPicker)
        {
            button_panel.chooseButton0.setChooseButton(colorPicker);
            button_panel.chooseButton1.setChooseButton(colorPicker);
            button_panel.chooseButton2.setChooseButton(colorPicker);
            button_panel.chooseButton3.setChooseButton(colorPicker);
            button_panel.chooseButton4.setChooseButton(colorPicker);
            button_panel.chooseButton5.setChooseButton(colorPicker);
            button_panel.toggleSwitch1.setToggleSwitch(colorPicker);
            button_panel.toggleSwitch2.setToggleSwitch(colorPicker);
        }


        public void deactivateAll()
        {
            button_panel.chooseButton0.deactivateButton();
            button_panel.chooseButton1.deactivateButton();
            button_panel.chooseButton2.deactivateButton();
            button_panel.chooseButton3.deactivateButton();
            button_panel.chooseButton4.deactivateButton();
            button_panel.chooseButton5.deactivateButton();
            button_panel.toggleSwitch1.deactivateSwitch();
            button_panel.toggleSwitch2.deactivateSwitch();
        }
    }
}
