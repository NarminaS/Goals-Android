using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Goals.Droid
{
    [Activity(MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Loading")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SplashScreen);
            StartActivity(new Intent(this, typeof(MainActivity)));
            OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);
            Finish();
            // Create your application here
        }

        protected override void OnResume()
        {
            base.OnResume();
            //StartActivity(new Intent(this, typeof(MainActivity)));
        }
    }
}