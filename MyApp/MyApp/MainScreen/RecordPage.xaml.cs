using Firebase.Auth;
using Firebase.Database;
using MyApp.RegisterAndLoginPage.EmployeeSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Graphics.ColorSpace;

namespace MyApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecordPage : ContentPage
    {
        List < EmployeeModel > users = new FirebaseClient("https://myapp-7f8d5-default-rtdb.firebaseio.com/")
                .Child("EmployeeModel")
                .OnceAsync<EmployeeModel>()
                .Result
                .Select(firebaseObject => firebaseObject.Object)
                .ToList();

        public RecordPage ()
		{
            InitializeComponent ();
            DescendingSortPuzzleGame();
        }

        private async void BtnGamingClicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TaskList());
        }
        private async void UserProfil_Clicked1(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ProfilePage());
        }


        private void BtnMemoryGameRecord_Clicked(object sender, EventArgs e)
        {
            DescendingSortMemoryGame();
            RecordTxt.Text = "Игра на память";
        }

        private void BtnMathGameRecord_Clicked(object sender, EventArgs e)
        {
            DescendingSortMathGame();
            RecordTxt.Text = "Сложение чисел";
        }

        private void BtnPuzzleGameRecord_Clicked(object sender, EventArgs e)
        {
            DescendingSortPuzzleGame();
            RecordTxt.Text = "Игра пятнашки";
        }

        private void BtnMathGameMinusRecord_Clicked(object sender, EventArgs e)
        {
            DescendingSortMathGameMinus();
            RecordTxt.Text = "Вычитание чисел";
        }
        public void DescendingSortMathGameMinus()
        {
            List<EmployeeModel> employee = users.OrderByDescending(user => user.RecordMathGameMinus).ToList();
            Top1Name.Text = employee[0].Name;
            Top1Score.Text = Convert.ToString(employee[0].RecordMathGameMinus);
            Top2Name.Text = employee[1].Name;
            Top2Score.Text = Convert.ToString(employee[1].RecordMathGameMinus);
            Top3Name.Text = employee[2].Name;
            Top3Score.Text = Convert.ToString(employee[2].RecordMathGameMinus);
            Top4Name.Text = employee[3].Name;
            Top4Score.Text = Convert.ToString(employee[3].RecordMathGameMinus);
            Top5Name.Text = employee[4].Name;
            Top5Score.Text = Convert.ToString(employee[4].RecordMathGameMinus);
        }
        public void DescendingSortMemoryGame()
        {
            List<EmployeeModel> employee = users.OrderByDescending(user => user.RecordMemoryGame).ToList();
            Top1Name.Text = employee[0].Name;
            Top1Score.Text = Convert.ToString(employee[0].RecordMemoryGame);
            Top2Name.Text = employee[1].Name;
            Top2Score.Text = Convert.ToString(employee[1].RecordMemoryGame);
            Top3Name.Text = employee[2].Name;
            Top3Score.Text = Convert.ToString(employee[2].RecordMemoryGame);
            Top4Name.Text = employee[3].Name;
            Top4Score.Text = Convert.ToString(employee[3].RecordMemoryGame);
            Top5Name.Text = employee[4].Name;
            Top5Score.Text = Convert.ToString(employee[4].RecordMemoryGame);
        }
        public void DescendingSortMathGame()
        {
            List<EmployeeModel> employee = users.OrderByDescending(user => user.RecordMathGame).ToList();
            Top1Name.Text = employee[0].Name;
            Top1Score.Text = Convert.ToString(employee[0].RecordMathGame);
            Top2Name.Text = employee[1].Name;
            Top2Score.Text = Convert.ToString(employee[1].RecordMathGame);
            Top3Name.Text = employee[2].Name;
            Top3Score.Text = Convert.ToString(employee[2].RecordMathGame);
            Top4Name.Text = employee[3].Name;
            Top4Score.Text = Convert.ToString(employee[3].RecordMathGame);
            Top5Name.Text = employee[4].Name;
            Top5Score.Text = Convert.ToString(employee[4].RecordMathGame);
        }
        public void DescendingSortPuzzleGame()
        {
            List<EmployeeModel> employee = users.Where(users => users.RecordPuzzleGame > 0).OrderBy(user => user.RecordPuzzleGame).ToList();
            Top1Name.Text = employee[0].Name;
            Top1Score.Text = Convert.ToString(employee[0].RecordPuzzleGame);
            Top2Name.Text = employee[1].Name;
            Top2Score.Text = Convert.ToString(employee[1].RecordPuzzleGame);
            Top3Name.Text = employee[2].Name;
            Top3Score.Text = Convert.ToString(employee[2].RecordPuzzleGame);
            Top4Name.Text = employee[3].Name;
            Top4Score.Text = Convert.ToString(employee[3].RecordPuzzleGame);
            Top5Name.Text = employee[4].Name;
            Top5Score.Text = Convert.ToString(employee[4].RecordPuzzleGame);
        }

        private void BtnRecords_Clicked1(object sender, EventArgs e)
        {

        }
    }
}