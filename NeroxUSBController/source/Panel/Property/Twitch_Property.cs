using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using NeroxUSBController.Wrapper;
using NeroxUSBController.Form;

namespace NeroxUSBController.Panel.Property
{
    public class Twitch_Property : ControllerProperty
    {
        internal Twitch twitch;
        internal Account account;
        internal Twitch_Panel panel;

        public Twitch_Property()
        {
            this.twitch = new Twitch();
            this.panel = new Twitch_Panel();
            //twitch_Chat_Message = new Twitch_Chat_Message(this.twitch);
            //twitch_Play_Ad = new Twitch_Play_Ad(this.twitch);
        }
    }

    public class Twitch_Panel : System.Windows.Forms.Panel
    {
        Message message;
        public Twitch_Panel()
        {
            this.Visible = false;
            this.message = new Message();


        }

        
        class Message : TextBox
        {
            private Boolean firstChange = true;

            public Message()
            {
                this.Text = "ABC";
                this.TextChanged += new EventHandler(Obs_Send_Message_Name_TextChanged);
            }

            private void Obs_Send_Message_Name_TextChanged(object sender, EventArgs e)
            {
                if (firstChange)
                {
                    firstChange = false;
                    Console.WriteLine(sender);
                }

            }
        }
        
    }

    class Twitch_Chat_Message : Twitch_Property
    {
        private string chatMessage;

        public Twitch_Chat_Message()
        {
            this.chatMessage = "Test!";
        }

        public void Activate()
        {
            this.twitch.bot.SendMessage(this.chatMessage);
        }
    }

    class Twitch_Play_Ad : Twitch_Property
    {
        public int duration = 30;

        public Twitch_Play_Ad()
        {
        }

        public void Activate()
        {
            this.twitch.PlayAd(duration);
        }
    }

    class Twitch_Slow_Chat : Twitch_Property
    {
        private bool active;
        private TimeSpan messageCooldown;

        public Twitch_Slow_Chat()
        {
            active = false;
        }

        public Twitch_Slow_Chat(TimeSpan _messageCooldown)
        {
            active = false;
            messageCooldown = _messageCooldown;
        }

        public void Activate()
        {
            active = !active;
            this.twitch.SlowChat(active, messageCooldown);
        }
    }

    class Twitch_Sub_Chat : Twitch_Property
    {
        private bool active;

        public Twitch_Sub_Chat()
        {
            active = false;
        }

        public void Activate()
        {
            active = !active;
            this.twitch.SubChat(active);
        }
    }
}
