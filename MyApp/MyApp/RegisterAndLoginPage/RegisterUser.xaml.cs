using Firebase.Database;
using MyApp.RegisterAndLoginPage.EmployeeSetting;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterUser : ContentPage
    {
        UserRepository userRepository = new UserRepository();
        SaveEmailOnTxt saveEmailOnTxt = new SaveEmailOnTxt();
        EmployeeSaveAndGet employee = new EmployeeSaveAndGet();
        EmployeeModel employeeModel = new EmployeeModel();
        public RegisterUser()
        {
            InitializeComponent();
        }
        FirebaseClient firebaseClient = new FirebaseClient("https://myapp-7f8d5-default-rtdb.firebaseio.com/");
        public async void ButtonRegister_Clicked(object sender, EventArgs e)
        {
            LoadingEnabled();
            try
            {
                string email = TxtEmail.Text;
                string name = TxtName.Text;
                string password = TxtPassword.Text;
                string confirmPassword = TxtConfirmPass.Text;
                int correctEmailCount = 0; 
                if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(confirmPassword))
                {
                    LoadingFalse();
                    await DisplayAlert("Внимание", "Некоторые поля не заполнены", "ок");
                    return;
                }
                foreach (char c in email)
                {
                    if (c == '@')
                    {
                        correctEmailCount++;
                    }
                }
                if(correctEmailCount == 0 || correctEmailCount > 1)
                {
                    LoadingFalse();
                    await DisplayAlert("Внимание", "Введите верную электронную почту", "ок");
                }
                if (password != confirmPassword)
                {
                    LoadingFalse();
                    await DisplayAlert("Ошибка", "Пароли не совпадают", "ок");
                    return;
                }
                if (password.Length < 6)
                {
                    LoadingFalse();
                    await DisplayAlert("Внимание", "пароль не может содержать менее 6 символов", "ок");
                    return;
                }
                bool isSave = await userRepository.Register(email, name, password);
                if (isSave)
                {
                    RegisterEmployee(email, name);
                    LoadingFalse();
                    await DisplayAlert("Регистрация пользователя", "Регистрация завершена", "ок");
                    await Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    LoadingFalse();
                    await DisplayAlert("Регистрация пользователя", "Регистрация не удалась", "ок");
                }
            }
            catch(Exception exception)
            {
                if (exception.Message.Contains("EMAIL_EXISTS"))
                {
                    LoadingFalse();
                    await DisplayAlert("Внимание", "Электронная почта уже зарегистрирована", "ок");
                }
            }
        }

        private async void LoginTap_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        private void LoadingEnabled()
        {
            loadingView.IsVisible = true;
            ButtonRegister.IsEnabled = false;
        }
        private void LoadingFalse()
        {
            loadingView.IsVisible = false;
            ButtonRegister.IsEnabled = true;
        }
        private async void RegisterEmployee(string eemail, string nname)
        {
            string email = eemail.Replace('.', '_');
            employeeModel.Email = email;
            employeeModel.Name = nname;
            RegisterAndLoginPage.EmployeeSetting.PlayerData.Email = email;
            RegisterAndLoginPage.EmployeeSetting.PlayerData.Name = nname;
            RegisterAndLoginPage.EmployeeSetting.PlayerData.RecordMathGameMinus = 0;
            RegisterAndLoginPage.EmployeeSetting.PlayerData.RecordMathGame = 0;
            RegisterAndLoginPage.EmployeeSetting.PlayerData.RecordPuzzleGame = 0;
            RegisterAndLoginPage.EmployeeSetting.PlayerData.RecordMemoryGame = 0;
            await employee.AddOrUpdateEmployee(employeeModel);
            saveEmailOnTxt.SaveEmail(email);
        }

    }
}
