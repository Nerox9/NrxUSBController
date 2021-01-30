using System;
using System.Collections.Generic;
using TwitchLib;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Api.Models.v5.Users;
using System.Resources;
using NeroxUSBController.Form;

namespace NeroxUSBController.Wrapper
{
    public class Twitch
    {
        readonly ConnectionCredentials credentials;
        TwitchClient client;
        public TwitchBot bot;
        private Account account;

        Dictionary<int, CommercialLength> commercialDuration = new Dictionary<int, CommercialLength>();

        public Twitch()
        {
            try
            { credentials = new ConnectionCredentials(data.TwitchInfo.BotUsername, data.TwitchInfo.BotAccessToken); }
            catch
            { Console.WriteLine("Twitch Bot can not connected to Twitch."); }
            
            client = new TwitchClient();
            bot = new TwitchBot(client);

            CommercialDuration();
            Connect();
            bot.Connect();
        }

        internal void Connect()
        {
            try
            {
                client.Initialize(credentials, data.TwitchInfo.ChannelName);
                client.Connect();
            }
            
            catch
            {
                Console.WriteLine("Twitch Bot can not connected to Twitch.");
            }
        }

        internal void PlayAd(int duration)
        {
            client.StartCommercial(data.TwitchInfo.ChannelName, commercialDuration[duration]);
        }

        internal void SlowChat(bool active, TimeSpan messageCooldown)
        {
            if (active == true)
                client.SlowModeOn(data.TwitchInfo.ChannelName, messageCooldown);
            else
                client.SlowModeOff(data.TwitchInfo.ChannelName);
        }

        internal void SubChat(bool active)
        {
            if (active == true)
                client.SubscribersOnlyOn(data.TwitchInfo.ChannelName);
            else
                client.SubscribersOnlyOff(data.TwitchInfo.ChannelName);
        }

        private void CommercialDuration()
        {
            commercialDuration.Add(30, CommercialLength.Seconds30);
            commercialDuration.Add(60, CommercialLength.Seconds60);
            commercialDuration.Add(90, CommercialLength.Seconds90);
            commercialDuration.Add(120, CommercialLength.Seconds120);
            commercialDuration.Add(150, CommercialLength.Seconds150);
            commercialDuration.Add(180, CommercialLength.Seconds180);
        }

    }

    public class TwitchBot
    {
        private TwitchClient client;

        public TwitchBot(TwitchClient _client)
        {
            this.client = _client;
        }

        internal void Connect()
        {
            Console.WriteLine("Connecting to Twitch");
            client.OnJoinedChannel += onJoinedChannel;
            client.OnMessageReceived += onMessageReceived;
            client.OnWhisperReceived += onWhisperReceived;
            client.OnNewSubscriber += onNewSubscriber;
            client.OnConnected += Client_OnConnected;
            //client.OnLog += onLog;

            
            //client.Connect();
        }

        internal void SendMessage(String message)
        {
            client.SendMessage(data.TwitchInfo.ChannelName, message);
        }

        internal void Disconnect()
        {
            Console.WriteLine("Disconnecting");
            client.Disconnect();
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }

        private void onLog(object sender, OnLogArgs e)
        {
            Console.WriteLine($"{e.BotUsername}: {e.Data} @ {e.DateTime}");
        }

        private void onJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            string[] messageList = {"Hey guys!I am a bot connected via TwitchLib!",
                                    "Hey guys!I am a bot connected via TwitchLib!",
                                    "Hey guys!I am a bot connected via TwitchLib!"};

            int random_integer = new Random().Next(messageList.Length);

            string message = messageList[random_integer];
            Console.Write("Chat Message: ");
            Console.WriteLine(message);
            client.SendMessage(e.Channel, message);
        }

        private void onMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.Message.Contains("badword"))
                client.TimeoutUser(e.ChatMessage.Channel, e.ChatMessage.Username, TimeSpan.FromMinutes(30), "Bad word! 30 minute timeout!");
        }

        private void onWhisperReceived(object sender, OnWhisperReceivedArgs e)
        {
            if (e.WhisperMessage.Username == "my_friend")
                client.SendWhisper(e.WhisperMessage.Username, "Hey! Whispers are so cool!!");
        }

        private void onNewSubscriber(object sender, OnNewSubscriberArgs e)
        {
            if (e.Subscriber.SubscriptionPlan == SubscriptionPlan.Prime)
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points! So kind of you to use your Twitch Prime on this channel!");
            else
                client.SendMessage(e.Channel, $"Welcome {e.Subscriber.DisplayName} to the substers! You just earned 500 points!");
        }
    }
}
