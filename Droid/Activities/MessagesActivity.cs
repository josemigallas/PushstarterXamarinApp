using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;
using Firebase;
using System.Net;

namespace PushStarterXamainApp.Droid
{
    [Activity(
        Label = "@string/app_name",
        MainLauncher = true,
        Icon = "@mipmap/icon"
    )]
    public class MessagesActivity : Activity
    {
        private TextView text;
        private Button logTokenButton;
        private Button subscribeButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            FindViews();

            logTokenButton.Click += delegate
            {
                Log.Debug("FirebaseApp", $"InstanceID token: {FirebaseInstanceId.Instance.Token}");
            };

            subscribeButton.Click += delegate
            {
                FirebaseMessaging.Instance.SubscribeToTopic("topix");
                Log.Debug("FirebaseApp", "Subscribed to remote notifications");
            };

            IsPlayServicesAvailable();
        }

        private void FindViews()
        {
            text = FindViewById<TextView>(Resource.Id.text);
            logTokenButton = FindViewById<Button>(Resource.Id.logTokenButton);
            subscribeButton = FindViewById<Button>(Resource.Id.subscribeButton);
        }

        public bool IsPlayServicesAvailable()
        {
            int resultCode = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (resultCode != ConnectionResult.Success)
            {
                if (GoogleApiAvailability.Instance.IsUserResolvableError(resultCode))
                {
                    text.Text = GoogleApiAvailability.Instance.GetErrorString(resultCode);
                }
                else
                {
                    text.Text = "This device is not supported";
                    Finish();
                }
                return false;
            }

            text.Text = "Google Play Services is available.";
            return true;
        }
    }

}

