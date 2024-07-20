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
    public partial class ForgotPasswordPage : ContentPage
    {
        UserRepository _userRepository=new UserRepository();
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private async void ButtonSendLink_Clicked(object sender, EventArgs e)
        {
            LoadingEnabled();
            try
            {
                string email = TxtEmail.Text;
                if (string.IsNullOrEmpty(email))
                {
                    LoadingFalse();
                    await DisplayAlert("Внимание", "Введите свой адрес электронной почты", "ок");
                    return;
                }
                bool isSend = await _userRepository.ResetPassword(email);
                if (isSend)
                {
                    LoadingFalse();
                    await DisplayAlert("Сброс пароля", "Ссылка отправлена на вашу электронную почту", "ок");
                    await Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    LoadingFalse();
                    await DisplayAlert("Сброс пароля", "Ссылка не отправлена", "ок");
                }
            }
            catch (Exception exception)
            {
                if (exception.Message.Contains("PASSWORD_RESET"))
                {
                    LoadingFalse();
                    await DisplayAlert("Внимание", "Введите свой адрес электронной почты", "ок");
                }

            }
            
        }

        private async void ForgotTap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        private void LoadingEnabled()
        {
            loadingView.IsVisible = true;
            ButtonSendLink.IsEnabled = false;
        }
        private void LoadingFalse()
        {
            loadingView.IsVisible = false;
            ButtonSendLink.IsEnabled = true;
        }
    }
}