using Android.Widget;
using Plugin.Connectivity;
using Plugin.LocalNotifications;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Goals.Helpers
{
    public class ConnectivityHelper<T> where T:class
    {
        private static bool IsInternetEnabled => CrossConnectivity.Current.IsConnected;

        public async Task<T> MakeRemoteCall(Func<Task<T>> callback, Action onDisableInternetCallback)
        {
            if (IsInternetEnabled)
            {
                return await callback();
            }
            else
            {
                CrossLocalNotifications.Current.Show("Warning", "Internet is turned off!");
                //Toast.MakeText(Android.App.Application.Context, "Internet is off!", ToastLength.Long).Show(); 
                //TODO:move to UI
                onDisableInternetCallback();
                return Activator.CreateInstance<T>();
            }
        }
    }
}
