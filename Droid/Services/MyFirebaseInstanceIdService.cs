using System;

using Android.App;
using Android.Content;
using Android.Util;
using Firebase.Iid;

namespace PushStarterXamainApp.Droid.Services
{
    [Service]
    [IntentFilter(new String[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseInstanceIdService : FirebaseInstanceIdService
    {
        public override void OnTokenRefresh()
        {
            base.OnTokenRefresh();

            var refreshedToken = FirebaseInstanceId.Instance.Token;

            SendRegistrationToServer(refreshedToken);
        }

        private void SendRegistrationToServer(string refreshedToken)
        {
            Log.Debug("FirebaseApp", "Refreshed token: " + refreshedToken);
        }
    }
}
