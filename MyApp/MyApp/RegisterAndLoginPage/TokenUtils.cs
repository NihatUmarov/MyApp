
using Xamarin.Essentials;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyApp.RegisterAndLoginPage
{
    internal class TokenUtils
    {

        public static void Save(string token)
        {
           Preferences.Set("TOKEN", token);
        }

        public static string GetToken() {

            return Preferences.Get("TOKEN", null);
        }
    }
}
