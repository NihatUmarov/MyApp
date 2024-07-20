using MyApp.RegisterAndLoginPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            InitializeComponent();

            try
            {
                var auth = Authorization.GetInstance(new UserRepository());

                var userInitTask = Task.Run(() => auth.InitUser());
                userInitTask.Wait();


                if (auth.IsLogin())
                {
                    Navigation.PushAsync(new TaskList()).Wait();
                }
                else
                {
                    Navigation.PushAsync(new LoginPage()).Wait();
                }
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("INVALID_ID_TOKEN"))
                {
                    Navigation.PushAsync(new TaskList()).Wait();
                }
            }

        }


    }
}