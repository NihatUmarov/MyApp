using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyApp.Audio;
using MyApp.RegisterAndLoginPage.EmployeeSetting;

namespace MyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MathGameMinus : ContentPage
	{
        

        private int num1 = 0;
        private int num2 = 0;
        private int correct = 0;
        private int resultCorrect = 0;

        Random random = new Random();
        EmployeeSaveAndGet employeeSave = new EmployeeSaveAndGet();
        public MathGameMinus()
        {
			InitializeComponent();
            employeeSave.GetEmployee();
            correct = Convert.ToInt32(App.Current.Properties["RecordMathGameMinus"]);
            CorrectText.Text = correct.ToString();
            updateView();
        }

        private void updateView()
        {
            employeeSave.SaveEmployee();
            randomNumbers.BackgroundColor = Color.White;
            RandomsNumbers();
            CorrectText.Text = "Счет : " + correct;
        }
        private async void ButtonCorrect(string value)
        {
            randomNumbers.Text = num1 + " - " + num2;
            if (resultCorrect == Convert.ToInt32(value))
            {
                DependencyService.Get<IAudio>().PlayAudioFile("CorrectAudio.mp3");
                correct++;
                randomNumbers.BackgroundColor = Color.GreenYellow;
                App.Current.Properties["RecordMathGameMinus"] = correct;
            }
            else
            {
                DependencyService.Get<IAudio>().PlayAudioFile("NotCorrectAudio.mp3");
                randomNumbers.BackgroundColor = Color.Red;
            }
            OnOffButton();
            await Task.Delay(1500);
            updateView();
        }
        private void RandomsNumbers()
        {
            num1 = random.Next(501, 999);
            num2 = random.Next(113, 499);

            randomNumbers.Text = num1 + " - " + num2;
            resultCorrect = num1 - num2;
            Button1.Text = Convert.ToString(resultCorrect - 12);
            Button2.Text = Convert.ToString(resultCorrect - 5);
            Button3.Text = Convert.ToString(resultCorrect + 10);
            Button4.Text = Convert.ToString(resultCorrect + 8);
            RandomLocationCorrect();
        }
        private void RandomLocationCorrect()
        {
            int rand = random.Next(1, 4);
            if (rand == 1)
                Button1.Text = Convert.ToString(resultCorrect);
            if (rand == 2)
                Button2.Text = Convert.ToString(resultCorrect);
            if (rand == 3)
                Button3.Text = Convert.ToString(resultCorrect);
            if (rand == 4)
                Button4.Text = Convert.ToString(resultCorrect);
        }
        public async void OnOffButton()
        {
            Button1.IsEnabled = false;
            Button2.IsEnabled = false;
            Button3.IsEnabled = false;
            Button4.IsEnabled = false;
            await Task.Delay(1500);

            Button1.IsEnabled = true;
            Button2.IsEnabled = true;
            Button3.IsEnabled = true;
            Button4.IsEnabled = true;
        }
        private void Button1_Clicked(object sender, EventArgs e)
        {
            ButtonCorrect(Button1.Text);
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            ButtonCorrect(Button2.Text);
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            ButtonCorrect(Button3.Text);
        }

        private void Button4_Clicked(object sender, EventArgs e)
        {
            ButtonCorrect(Button4.Text);
        }
    }
}