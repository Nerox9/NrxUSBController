using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using NeroxUSBController.source.Forms;

namespace NeroxUSBController
{
    class Account
    {
        private string username { get; set; }
        private string password { get; set; }
        private string accessToken { get; set; }
        private string token { get; set; }
    }

    class Account_Choose : Control
    {
        private Account_Choose_Box choose_Box;
        private Account_Add_Button add_Button;

        public Account_Choose()
        {
            choose_Box = new Account_Choose_Box();
            add_Button = new Account_Add_Button();

            choose_Box.DrawMode = DrawMode.OwnerDrawVariable;
            choose_Box.ItemHeight = 25;
            choose_Box.DropDownStyle = ComboBoxStyle.DropDownList;
            choose_Box.FlatStyle = FlatStyle.Standard;
            choose_Box.BackColor = Color.FromArgb(18,18,18);
            choose_Box.ForeColor = Color.White;

            Controls.Add(choose_Box);
            Controls.Add(add_Button);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            add_Button.Location = new Point(this.Size.Width - 25, 0);
            add_Button.Size = new Size(25, this.Size.Height);
        }
    }

    class Account_Choose_Box : ComboBox
    {
        public Account_Choose_Box()
        {
            account_type twitch = new account_type();
            twitch.Text = "Twitch";
            twitch.Logo = Properties.Resources.twitch_logo;

            account_type twitter = new account_type();
            twitter.Text = "Twitter";
            twitter.Logo = Properties.Resources.twitter_logo;

            Items.Add(twitch);
            Items.Add(twitter);

        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();

            if (e.Index >= 0 && e.Index < Items.Count)
            {
                account_type item = (account_type)Items[e.Index];
                e.Graphics.DrawImage(item.Logo, e.Bounds.Left, e.Bounds.Top, 24, 24);
                e.Graphics.DrawString(item.Text, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + 34, e.Bounds.Top + 4);
            }

            base.OnDrawItem(e);
        }

        public class account_type
        {
            public string Text { get; set; }
            public Image Logo { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
    }

    class Account_Add_Button : Button
    {
        TwitchConnection twitchForm;

        public Account_Add_Button()
        {
            twitchForm = new TwitchConnection();
            twitchForm.InitializeComponent();

            Text = "+";

            Click += Account_Add_Button_Click;
        }

        private void Account_Add_Button_Click(object sender, EventArgs e)
        {

            try
            {
                twitchForm.Show();
                twitchForm.setSize();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Connection Error.");

            }

            Console.WriteLine(sender);
        }
    }

   
}
