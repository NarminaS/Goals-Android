using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Auth.Api.SignIn;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Goals.Services.Repositories.Abstract;
using Goals.Utils;

namespace Goals.Droid.Helpers
{
    class AuthRepository : IAuthRepository
    {
        private readonly Context Context = Application.Context;

        public ApplicationUser GetUser()
        {
            GoogleSignInAccount account = GoogleSignIn.GetLastSignedInAccount(Context);
            if (account != null)
            {
                return new ApplicationUser
                {
                    DisplayName = account.DisplayName,
                    Email = account.Email,
                    PhotoUrl = account.PhotoUrl.ToString()
                };
            }
            return null;
        }
    }
}