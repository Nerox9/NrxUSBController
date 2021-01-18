using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController.source.Manager
{
    static public class UserControllerManager
    {
        static ColorPicker colorPicker;
        static List<ChooseButton> chooseButtons = new List<ChooseButton>();
        static List<ToggleSwitch> toggleSwitches = new List<ToggleSwitch>();
        static UserController selectedUserController;

        static public Color ActiveColor
        {
            get
            {
                return colorPicker.ForeColor;
            }

            set
            {
                colorPicker.ForeColor = value;
            }
        }

        static public Color PassiveColor
        {
            get
            {
                return colorPicker.BackColor;
            }

            set
            {
                colorPicker.BackColor = value;
            }
        }

        static public void SetColorPicker(ColorPicker picker)
        {
            colorPicker = picker;
        }

        static public void ResetColorPicker()
        {
            colorPicker.resetForecolor();
        }

        static public void SetUserControllerColor(Color color)
        {
            selectedUserController.ActiveColor = color;
            selectedUserController.Refresh();
        }

        static public void AddChooseButton(ChooseButton chooseButton)
        {
            chooseButtons.Add(chooseButton);
            colorPicker.pickMouseDown(new MouseEventHandler(chooseButton.GetOnMouseClick()));
        }

        static public void AddToggleSwitch(ToggleSwitch toggleSwitch)
        {
            toggleSwitches.Add(toggleSwitch);
            colorPicker.pickMouseDown(new MouseEventHandler(toggleSwitch.GetOnMouseClick()));
        }

        static public void Select(UserController userController)
        {
            if(selectedUserController != null)
                selectedUserController.Deselect();

            selectedUserController = userController;
            ActiveColor = selectedUserController.ActiveColor;
            selectedUserController.Select();
        }

        static public void SetActive(UserController userController)
        {
            selectedUserController = userController;
            ActiveColor = selectedUserController.ForeColor;
            //activeUserController.OnMouseDown(new MouseEventArgs(Control.MouseButtons, 0, 0, 0, 0)); chooseButton_Click(this, new EventArgs()); OnMouseUp(new MouseEventArgs(Control.MouseButtons, 0, 0, 0, 0));
        }

        static public void DeactivateAll()
        {
            foreach(ChooseButton button in chooseButtons)
            {
                button.Deactivate();
            }
            foreach(ToggleSwitch toggleSwitch in toggleSwitches)
            {
                toggleSwitch.Deactivate();
            }
        }
    }
}
