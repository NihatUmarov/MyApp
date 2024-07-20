using Android.Views;
using Firebase.Auth;
using MyApp.RegisterAndLoginPage;
using MyApp.RegisterAndLoginPage.EmployeeSetting;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{
    public partial class App : Application
    {
        SaveEmailOnTxt saveEmailOnTxt = new SaveEmailOnTxt();
        public App()
        {
            if (File.ReadAllText(saveEmailOnTxt.fileName) == "")
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new TaskList());
            }

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
