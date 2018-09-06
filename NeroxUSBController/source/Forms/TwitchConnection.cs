using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using RestSharp;

namespace NeroxUSBController.source.Forms
{
    class TwitchConnection : Form
    {
        private WebBrowser twitchWebBrowser;

        internal void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TwitchConnection));
            this.twitchWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // twitchWebBrowser
            // 
            this.twitchWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.twitchWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.twitchWebBrowser.Name = "twitchWebBrowser";
            this.twitchWebBrowser.ScriptErrorsSuppressed = true;
            this.twitchWebBrowser.Size = new System.Drawing.Size(292, 273);
            this.twitchWebBrowser.TabIndex = 0;
            this.twitchWebBrowser.Url = new System.Uri("https://id.twitch.tv/oauth2/authorize?response_type=code&client_id=" + data.TwitchInfo.ClientID + "&redirect_uri=http://localhost/&scope=chat_login", System.UriKind.Absolute);
            // 
            // TwitchConnection
            // 
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.twitchWebBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TwitchConnection";
            this.ResumeLayout(false);

        }


        private void TwitchConnection_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //setSize();
            try
            {
                var username = twitchWebBrowser.Document.GetElementById("username");
                Console.WriteLine(username);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        internal Account GetAccount()
        {
            Account account = new Account();

            string url = "https://id.twitch.tv/oauth2/authorize?response_type=code&client_id=" + data.TwitchInfo.ClientID + "&redirect_uri=http://localhost/&scope=chat_login";


            return account;
        }
        internal void setSize() { Size twitch_size = twitchWebBrowser.Document.Body.ScrollRectangle.Size; this.Size = twitch_size; this.twitchWebBrowser.Size = twitch_size; }
    }
}
