using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeroxUSBController
{
    class ButtonPanel : Panel
    {
        private Pot pot2;
        private Pot pot1;
        public ChooseButton chooseButton0;
        public ChooseButton chooseButton5;
        public ChooseButton chooseButton4;
        public ChooseButton chooseButton3;
        public ChooseButton chooseButton2;
        public ChooseButton chooseButton1;
        public ToggleSwitch toggleSwitch1;
        public ToggleSwitch toggleSwitch2;
        private Label switch_label2;
        private Label switch_label1;

        public ButtonPanel()
        {
            this.pot1 = new Pot();
            this.pot2 = new Pot();
            this.toggleSwitch2 = new ToggleSwitch();
            this.toggleSwitch1 = new ToggleSwitch();
            this.chooseButton5 = new ChooseButton();
            this.chooseButton4 = new ChooseButton();
            this.chooseButton3 = new ChooseButton();
            this.chooseButton2 = new ChooseButton();
            this.chooseButton1 = new ChooseButton();
            this.chooseButton0 = new ChooseButton();
            this.switch_label2 = new Label();
            this.switch_label1 = new Label();

            // 
            // pot1
            // 
            this.pot1.HighLimit = 135;
            this.pot1.Location = new System.Drawing.Point(13, 127);
            this.pot1.LowLimit = -135;
            this.pot1.Name = "pot1";
            this.pot1.Rotor = global::NeroxUSBController.Properties.Resources.pot_head;
            this.pot1.RotorGlow = global::NeroxUSBController.Properties.Resources.pot_head_indicator;
            this.pot1.Size = new System.Drawing.Size(70, 70);
            this.pot1.Stator = global::NeroxUSBController.Properties.Resources.pot_base;
            this.pot1.TabIndex = 12;
            this.pot1.Text = "pot1";
            // 
            // pot2
            // 
            this.pot2.HighLimit = 135;
            this.pot2.Location = new System.Drawing.Point(412, 127);
            this.pot2.LowLimit = -135;
            this.pot2.Name = "pot2";
            this.pot2.Rotor = global::NeroxUSBController.Properties.Resources.pot_head;
            this.pot2.RotorGlow = global::NeroxUSBController.Properties.Resources.pot_head_indicator;
            this.pot2.Size = new System.Drawing.Size(70, 70);
            this.pot2.Stator = global::NeroxUSBController.Properties.Resources.pot_base;
            this.pot2.TabIndex = 11;
            this.pot2.Text = "pot2";
            // 
            // toggleSwitch2
            // 
            this.toggleSwitch2.ActiveColor = System.Drawing.Color.White;
            this.toggleSwitch2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.toggleSwitch2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toggleSwitch2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toggleSwitch2.Location = new System.Drawing.Point(433, 43);
            this.toggleSwitch2.Name = "toggleSwitch2";
            this.toggleSwitch2.PassiveColor = System.Drawing.Color.Gray;
            this.toggleSwitch2.Size = new System.Drawing.Size(26, 43);
            this.toggleSwitch2.SwitchLabel = this.switch_label2;
            this.toggleSwitch2.TabIndex = 7;
            this.toggleSwitch2.Text = "On";
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.ActiveColor = System.Drawing.Color.White;
            this.toggleSwitch1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.toggleSwitch1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.toggleSwitch1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.toggleSwitch1.Location = new System.Drawing.Point(33, 43);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.PassiveColor = System.Drawing.Color.Gray;
            this.toggleSwitch1.Size = new System.Drawing.Size(26, 43);
            this.toggleSwitch1.SwitchLabel = this.switch_label1;
            this.toggleSwitch1.TabIndex = 6;
            this.toggleSwitch1.Text = "On";
            // 
            // chooseButton5
            // 
            this.chooseButton5.ActiveColor = System.Drawing.Color.White;
            this.chooseButton5.AllowDrop = true;
            this.chooseButton5.BorderThickness = 2F;
            this.chooseButton5.Location = new System.Drawing.Point(299, 116);
            this.chooseButton5.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton5.Name = "chooseButton5";
            this.chooseButton5.Size = new System.Drawing.Size(94, 81);
            this.chooseButton5.TabIndex = 5;
            this.chooseButton5.Text = "Button5";
            // 
            // chooseButton4
            // 
            this.chooseButton4.ActiveColor = System.Drawing.Color.White;
            this.chooseButton4.AllowDrop = true;
            this.chooseButton4.BorderThickness = 2F;
            this.chooseButton4.Location = new System.Drawing.Point(195, 116);
            this.chooseButton4.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton4.Name = "chooseButton4";
            this.chooseButton4.Size = new System.Drawing.Size(94, 81);
            this.chooseButton4.TabIndex = 4;
            this.chooseButton4.Text = "Button4";
            // 
            // chooseButton3
            // 
            this.chooseButton3.ActiveColor = System.Drawing.Color.White;
            this.chooseButton3.AllowDrop = true;
            this.chooseButton3.BorderThickness = 2F;
            this.chooseButton3.Location = new System.Drawing.Point(91, 116);
            this.chooseButton3.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton3.Name = "chooseButton3";
            this.chooseButton3.Size = new System.Drawing.Size(94, 81);
            this.chooseButton3.TabIndex = 3;
            this.chooseButton3.Text = "Button3";
            // 
            // chooseButton2
            // 
            this.chooseButton2.ActiveColor = System.Drawing.Color.White;
            this.chooseButton2.AllowDrop = true;
            this.chooseButton2.BorderThickness = 2F;
            this.chooseButton2.Location = new System.Drawing.Point(299, 25);
            this.chooseButton2.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton2.Name = "chooseButton2";
            this.chooseButton2.Size = new System.Drawing.Size(94, 81);
            this.chooseButton2.TabIndex = 2;
            this.chooseButton2.Text = "Button2";
            // 
            // chooseButton1
            // 
            this.chooseButton1.ActiveColor = System.Drawing.Color.White;
            this.chooseButton1.AllowDrop = true;
            this.chooseButton1.BorderThickness = 2F;
            this.chooseButton1.Location = new System.Drawing.Point(195, 25);
            this.chooseButton1.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton1.Name = "chooseButton1";
            this.chooseButton1.Size = new System.Drawing.Size(94, 81);
            this.chooseButton1.TabIndex = 1;
            this.chooseButton1.Text = "Button1";
            // 
            // chooseButton0
            // 
            this.chooseButton0.ActiveColor = System.Drawing.Color.White;
            this.chooseButton0.AllowDrop = true;
            this.chooseButton0.BorderThickness = 2F;
            this.chooseButton0.Location = new System.Drawing.Point(91, 25);
            this.chooseButton0.Margin = new System.Windows.Forms.Padding(5);
            this.chooseButton0.Name = "chooseButton0";
            this.chooseButton0.Size = new System.Drawing.Size(94, 81);
            this.chooseButton0.TabIndex = 0;
            this.chooseButton0.Text = "Button0";
            // 
            // button_panel
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pot1);
            this.Controls.Add(this.pot2);
            this.Controls.Add(this.switch_label2);
            this.Controls.Add(this.switch_label1);
            this.Controls.Add(this.toggleSwitch2);
            this.Controls.Add(this.toggleSwitch1);
            this.Controls.Add(this.chooseButton5);
            this.Controls.Add(this.chooseButton4);
            this.Controls.Add(this.chooseButton3);
            this.Controls.Add(this.chooseButton2);
            this.Controls.Add(this.chooseButton1);
            this.Controls.Add(this.chooseButton0);
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Location = new System.Drawing.Point(0, 34);
            this.Name = "button_panel";
            this.Size = new System.Drawing.Size(507, 235);
            this.TabIndex = 3;
            // 
            // switch_label2
            // 
            this.switch_label2.ForeColor = System.Drawing.Color.Red;
            this.switch_label2.Location = new System.Drawing.Point(412, 25);
            this.switch_label2.Name = "switch_label2";
            this.switch_label2.Size = new System.Drawing.Size(70, 13);
            this.switch_label2.TabIndex = 9;
            this.switch_label2.Text = "switch2";
            this.switch_label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // switch_label1
            // 
            this.switch_label1.ForeColor = System.Drawing.Color.Red;
            this.switch_label1.Location = new System.Drawing.Point(13, 25);
            this.switch_label1.Name = "switch_label1";
            this.switch_label1.Size = new System.Drawing.Size(70, 13);
            this.switch_label1.TabIndex = 8;
            this.switch_label1.Text = "switch1";
            this.switch_label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }
    }
}
