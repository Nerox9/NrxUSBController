using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OBSWebsocketDotNet;


namespace NeroxUSBController
{
    class Obs
    {
        protected OBSWebsocket obs_websocket;

        public Obs()
        {
            obs_websocket = new OBSWebsocket();

            obs_websocket.Connected += onConnect;
            obs_websocket.Disconnected += onDisconnect;

            obs_websocket.SceneChanged += onSceneChange;
            obs_websocket.SceneCollectionChanged += onSceneColChange;
            obs_websocket.ProfileChanged += onProfileChange;
            obs_websocket.TransitionChanged += onTransitionChange;
            obs_websocket.TransitionDurationChanged += onTransitionDurationChange;

            obs_websocket.StreamingStateChanged += onStreamingStateChange;
            obs_websocket.RecordingStateChanged += onRecordingStateChange;

            obs_websocket.StreamStatus += onStreamData;
        }

        private void onConnect(object sender, EventArgs e)
        {
        }

        private void onDisconnect(object sender, EventArgs e)
        {
        }

        private void onSceneChange(OBSWebsocket sender, string newSceneName)
        {
        }

        private void onSceneColChange(object sender, EventArgs e)
        {
        }

        private void onProfileChange(object sender, EventArgs e)
        {
        }

        private void onTransitionChange(OBSWebsocket sender, string newTransitionName)
        { }

        private void onTransitionDurationChange(OBSWebsocket sender, int newDuration)
        { }

        private void onStreamingStateChange(OBSWebsocket sender, OutputState newState)
        { }

        private void onRecordingStateChange(OBSWebsocket sender, OutputState newState)
        { }

        private void onStreamData(OBSWebsocket sender, StreamStatus data)
        { }

    }
}
