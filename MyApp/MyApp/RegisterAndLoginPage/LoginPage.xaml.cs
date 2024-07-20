using MyApp.RegisterAndLoginPage;
using MyApp.RegisterAndLoginPage.EmployeeSetting;
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
    public partial class LoginPage : ContentPage
    {
        UserRepository _userRepository=new UserRepository();
        SaveEmailOnTxt saveEmailOnTxt = new SaveEmailOnTxt();
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void BtnSignIn_Clicked(object sender, EventArgs e)
        {
            LoadingEnabled();
            try
            {
                string email = TxtEmail.Text;
                string password = TxtPassword.Text;
                if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
                {
                    LoadingFalse();
                    await DisplayAlert("Внимание", "Некоторые поля не заполнены", "ок");
                    return;
                }
                var auth = Authorization.GetInstance(new UserRepository());
                await auth.SignIn(email, password);
                if (auth.IsLogin())
                {
                    string txtEmail = email.Replace('.', '_');
                    saveEmailOnTxt.SaveEmail(txtEmail);
                    LoadingFalse();
                    await Navigation.PushAsync(new TaskList());
                }
                else
                {
                    LoadingFalse();
                    await DisplayAlert("Ошибка", "Введен неправильный логин или пароль", "ок");
                }
            }
            catch(Exception exception)
            {
                if (exception.Message.Contains("INVALID_EMAIL"))
                {
                    LoadingFalse();
                    await DisplayAlert("Ошибка", "Электронная почта не найдена", "ок");
                }
                else if (exception.Message.Contains("INVALID_PASSWORD"))
                {
                    LoadingFalse();
                    await DisplayAlert("Ошибка", "Введен неправильный логин или пароль", "ок");
                }
                else if (exception.Message.Contains("TOO_MANY_ATTEMPTS_TRY_LATER"))
                {

                    LoadingFalse();
                    await DisplayAlert("Не верно", "Попробуйте восстановить пароль", "ок");
                }
                else if (exception.Message.Contains("EMAIL_NOT_FOUND"))
                {

                    LoadingFalse();
                    await DisplayAlert("Не верно", "Введен неправильный логин или пароль", "ок");
                }
            }

        }

        private async void RegisterTap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterUser());
        }

        private async void ForgotTap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPasswordPage());
        }
        private void LoadingEnabled()
        {
            loadingView.IsVisible = true;
            BtnSignIn.IsEnabled = false;
        }
        private void LoadingFalse()
        {
            loadingView.IsVisible = false;
            BtnSignIn.IsEnabled = true;
        }
    }
}