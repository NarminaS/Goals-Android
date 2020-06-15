using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Gms.Auth.Api;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Goals.Droid.Helpers;
using Goals.Localization;
using Goals.Services.Repositories.Abstract;
using ImageCircle.Forms.Plugin.Droid;
using Plugin.LocalNotifications;
using Plugin.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Goals.Droid
{
    [Activity(Label = "Goals", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity, GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener
    {
        private GoogleApiClient mGoogleApiClient;
        public int SIGN_ID_ID = 9001;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            DependencyService.Register<ILocalize, Localize>();
            DependencyService.Register<IAuthRepository, AuthRepository>();

            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);

            LocalNotificationsImplementation.NotificationIconId = Resource.Drawable.ic_stat_futurelife;
            ImageCircleRenderer.Init();
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);

            GoogleSignInAccount account = GoogleSignIn.GetLastSignedInAccount(this);
            if (account == null)
            {
                ConfigureGoogleSignIn();
                GoogleSignInLaunch();
            }
            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void GoogleSignInLaunch()
        {
            var signInIntent = Auth.GoogleSignInApi.GetSignInIntent(mGoogleApiClient);
            StartActivityForResult(signInIntent, SIGN_ID_ID);
        }

        private void ConfigureGoogleSignIn()
        {
            GoogleSignInOptions gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
                                                                    .RequestEmail()
                                                                    .Build();

            mGoogleApiClient = new GoogleApiClient.Builder(this)
                                    .EnableAutoManage(this, this)
                                    .AddApi(Auth.GOOGLE_SIGN_IN_API, gso)
                                    .AddConnectionCallbacks(this)
                                    .Build();
        }

        public void OnConnected(Bundle connectionHint)
        {
            //throw new System.NotImplementedException();
        }

        public void OnConnectionSuspended(int cause)
        {
            //throw new System.NotImplementedException();
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            Toast.MakeText(this, result.ErrorMessage, ToastLength.Long);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == SIGN_ID_ID)
            {
                var result = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
                HandleSignInResult(result);
            }
        }

        private void HandleSignInResult(GoogleSignInResult result)
        {
            if (result.IsSuccess)
            {
                var accountDetails = result.SignInAccount;
            }
        }
    }
}