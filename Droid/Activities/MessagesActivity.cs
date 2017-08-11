using Android.App;
using Android.Widget;
using Android.OS;

namespace PushStarterXamainApp.Droid
{
    [Activity(
        Label = "@string/app_name",
        MainLauncher = true,
        Icon = "@mipmap/icon"
    )]
    public class MessagesActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            TextView text = FindViewById<TextView>(Resource.Id.text);

            text.Text = "Hello!";
        }
    }
}

