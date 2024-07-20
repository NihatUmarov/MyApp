using MyApp.RegisterAndLoginPage.EmployeeSetting;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        SaveEmailOnTxt txtEmail = new SaveEmailOnTxt();
        public ProfilePage()
        {
            InitializeComponent();
            
            Name.Text = RegisterAndLoginPage.EmployeeSetting.PlayerData.Name;
            MathGameMinusRecord.Text = Convert.ToString(RegisterAndLoginPage.EmployeeSetting.PlayerData.RecordMathGameMinus);
            MathGameRecord.Text = Convert.ToString(RegisterAndLoginPage.EmployeeSetting.PlayerData.RecordMathGame);
            MemoryGameRecord.Text = Convert.ToString(RegisterAndLoginPage.EmployeeSetting.PlayerData.RecordMemoryGame);
            PuzzleGameRecord.Text = Convert.ToString(RegisterAndLoginPage.EmployeeSetting.PlayerData.RecordPuzzleGame);
        }

        private async void BtnRecords_Clicked2(object sender, EventArgs e)
        {
            
            await Navigation.PushAsync(new RecordPage());
        }

        private async void BtnGamingClicked2(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new TaskList());
        }

        private void UserProfil_Clicked2(object sender, EventArgs e)
        {

        }

        private async void ChangeUserTap_Tapped(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Подтвердить действие", "Вы хотите сменить пользователя?", "Да", "Нет");
            if(result)
            {
                txtEmail.DeleteEmail();
                await Navigation.PushAsync(new LoginPage());
            }
        }
    }
}