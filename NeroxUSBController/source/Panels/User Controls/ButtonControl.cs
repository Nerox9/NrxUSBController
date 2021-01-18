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
            buttonPanel.chooseButton0.setChooseButton(colorPicker);
            buttonPanel.chooseButton1.setChooseButton(colorPicker);
            buttonPanel.chooseButton2.setChooseButton(colorPicker);
            buttonPanel.chooseButton3.setChooseButton(colorPicker);
            buttonPanel.chooseButton4.setChooseButton(colorPicker);
            buttonPanel.chooseButton5.setChooseButton(colorPicker);
            buttonPanel.toggleSwitch1.setToggleSwitch(colorPicker);
            buttonPanel.toggleSwitch2.setToggleSwitch(colorPicker);
        }


        public void deactivateAll()
        {
            buttonPanel.chooseButton0.deactivateButton();
            buttonPanel.chooseButton1.deactivateButton();
            buttonPanel.chooseButton2.deactivateButton();
            buttonPanel.chooseButton3.deactivateButton();
            buttonPanel.chooseButton4.deactivateButton();
            buttonPanel.chooseButton5.deactivateButton();
            buttonPanel.toggleSwitch1.deactivateSwitch();
            buttonPanel.toggleSwitch2.deactivateSwitch();
        }
    }
}
