using System;

using Android.App;
using Android.Content;
using Android.Util;
using Firebase.Messaging;

namespace PushStarterXamainApp.Droid.Services
{
    [Service]
    [IntentFilter(new String[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);

            Log.Debug("FirebaseApp", $"Notification received: {message}");
        }
    }
}
