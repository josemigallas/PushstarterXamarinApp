using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Common;
using Firebase.Messaging;
using Firebase.Iid;
using Android.Util;

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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            text = FindViewById<TextView>(Resource.Id.text);

            IsPlayServicesAvailable();
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

