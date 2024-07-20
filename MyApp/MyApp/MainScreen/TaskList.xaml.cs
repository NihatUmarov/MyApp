
using Android.Views;
using Android.Widget;
using MyApp.RegisterAndLoginPage;
using MyApp.RegisterAndLoginPage.EmployeeSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Media.Session.MediaSession;

namespace MyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TaskList : ContentPage
    {
        RegisterUser _userRepository = new RegisterUser();
        EmployeeSaveAndGet employeeGet = new EmployeeSaveAndGet();
        public TaskList()
        {
            employeeGet.GetEmployee();
            InitializeComponent();
        }
        private void BtnTask2_Clicked(object sender, EventArgs e)
        {
            txtText.Text = "Игра на память";
        }

        private void BtnTask3_Clicked(object sender, EventArgs e)
        {
            txtText.Text = "Сложение чисел";
        }

        private void BtnTask4_Clicked(object sender, EventArgs e)
        {
            txtText.Text = "Вычитание чисел";
        }

        private async void BtnGame_Clicked(object sender, EventArgs e)
        {
            if (txtText.Text == "Игра на память")
            {
                await Navigation.PushAsync(new MemoryGame());
            }

            if (txtText.Text == "Игра пятнашки")
            {
                await Navigation.PushAsync(new PuzzleGame());
            }
            if (txtText.Text == "Вычитание чисел")
            {
                await Navigation.PushAsync(new MathGameMinus());
            }
            if (txtText.Text == "Сложение чисел")
            {
                await Navigation.PushAsync(new MathGame());
            }
        }

        private void BtnTask1_Clicked(object sender, EventArgs e)
        {
            txtText.Text = "Игра пятнашки";
        }
        private async void BtnCross_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Выход из игры", "Вы хотите выйти из игры?", "Да", "Нет");

            if (result)
            {
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            }
        }

        private void BtnAccount_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnRecords_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecordPage());
        }

        private void BtnGamingClicked(object sender, EventArgs e)
        {

        }

        private async void UserProfil_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        private void ResultWhiteButton()
        {
            UsersProfil.BackgroundColor = Color.Transparent;
            Gaming.BackgroundColor = Color.Transparent;
            Records.BackgroundColor = Color.Transparent;
            UsersProfil.TextColor = Color.White;
            Gaming.TextColor = Color.White;
            Records.TextColor = Color.White;
        }
        
    }
}